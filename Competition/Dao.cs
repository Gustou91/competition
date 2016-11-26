using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Data;
using log4net;
using log4net.Config;

namespace Competition
{
    class Dao
    {


        private static Dao _instance = null;

        private String _strAppDir;
        private String _strFullPathDB;
        private SQLiteConnection _dbConnection = new SQLiteConnection("Data Source=USM-JUJITSO-COMPET.sqlite;Version=3;");
        private SQLiteDataAdapter _DB;

        private static readonly ILog logger = LogManager.GetLogger(typeof(Dao));

        private Dao ()
        {
            //_strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            //_strFullPathDB = Path.Combine(_strAppDir, "USM-JUJITSO-COMPET.sqlite");
            _strFullPathDB = "USM-JUJITSO-COMPET.sqlite";

            createDatabase();
            
        }

        public static Dao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Dao();
                }
                return _instance;
            }
        }


        private Boolean createDatabase()
        {

            if (!File.Exists(_strFullPathDB))
            {
                logger.Info("Création de la base de données.");

                SQLiteConnection.CreateFile(_strFullPathDB);

                openBase();

                #region Table des paramètres.
                string sql = "CREATE TABLE parametre ( par_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                             + "par_nom VARCHAR (30) UNIQUE, par_valeur VARCHAR (255) )";
                SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();

                sql = "INSERT INTO parametre (par_nom, par_valeur) VALUES ('POIDS-DELTA', 1)";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();

                sql = "INSERT INTO parametre (par_nom, par_valeur) VALUES ('AGE-DELTA', 1)";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();

                sql = "INSERT INTO parametre (par_nom, par_valeur) VALUES ('POULE-DIM', 4)";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();
                #endregion

                #region Table des compétitons.
                sql = "CREATE TABLE competition (com_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                     + "com_nom STRING (50) NOT NULL, com_active BOOLEAN NOT NULL, com_creation DATETIME NOT NULL)";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();
                #endregion

                #region Table des catégories.
                sql = "CREATE TABLE categorie ( cat_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, " 
                    + "cat_nom STRING (50) NOT NULL, cat_agemin INT NOT NULL, cat_agemax INT NOT NULL, "
                    + "cat_sexe CHAR (1) NOT NULL, cat_poidsmin INT NOT NULL, cat_poidsmax INT NOT NULL, "
                    + "cat_creation DATETIME NOT NULL, cat_modification DATETIME )";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();
                #endregion

                #region Table des clubs.
                sql = "CREATE TABLE club (clu_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                    + "clu_nom STRING (50) UNIQUE NOT NULL, "
                    + "clu_creation DATETIME NOT NULL, clu_modification DATETIME)";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();
                #endregion

                #region Table des membres.
                sql = "CREATE TABLE membre (mem_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                    + "mem_nom STRING (50) NOT NULL, mem_prenom STRING (50) NOT NULL, mem_sexe CHAR (1) NOT NULL, "
                    + "mem_age INT (2) NOT NULL, mem_poids INT (3) NOT NULL, mem_club INTEGER REFERENCES club (clu_id), "
                    + "mem_poule INT REFERENCES poule (pou_id), mem_creation DATETIME NOT NULL, mem_modification DATETIME)";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();
                #endregion

                #region Table des poules.
                sql = "CREATE TABLE poule (pou_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                    + "pou_nom STRING (10) NOT NULL UNIQUE, pou_competition INT REFERENCES competition (com_id) ON DELETE CASCADE ON UPDATE CASCADE, "
                    + "pou_creation DATETIME NOT NULL, pou_modification DATETIME)";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();
                #endregion

                #region Table des randori.
                sql = "CREATE TABLE randori ( ran_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                    + "ran_membre1 INTEGER REFERENCES membre (mem_id), ran_membre2 INTEGER REFERENCES membre (mem_id) )";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();
                #endregion

                #region Table des résultats.
                sql = "CREATE TABLE resultat ( res_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                    + "res_membre INTEGER REFERENCES membre (mem_id), "
                    + "res_randori INTEGER REFERENCES randori (ran_id), res_victoire BOOLEAN NOT NULL, "
                    + "res_points INT NOT NULL)";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();
                #endregion

                closeBase();

                logger.Info("base créée.");

            }

            return true;
        }


        public Boolean openBase()
        {

            try
            {
                if (_dbConnection.State != System.Data.ConnectionState.Open)
                {
                    logger.Info("openBase: Ouverture de la base de données.");
                    _dbConnection.Open();
                }
                else
                    logger.Info("openBase: La base est déjà ouverte.");

                return true;
            }

            catch (Exception e)
            {
                logger.Info("openBase: Erreur d'ouverture de la base de données - " + e.Message);
                throw new Exception(e.Message);
            }
        }

        public Boolean closeBase()
        {

            try
            {
                if (_dbConnection.State == System.Data.ConnectionState.Open)
                {

                    logger.Info("closeBase: Fermeture de la base de données.");
                    _dbConnection.Close();
                }
                else logger.Info("closeBase: La base est déjà fermée.");


                return true;
            }

            catch (Exception e)
            {
                logger.Info("openBase: Erreur de fermeture de la base de données - " + e.Message);
                throw new Exception(e.Message);
            }
        }


        #region Gestion des paramètres.
        public Dictionary<string, string> loadParam()
        {
            openBase();

            Dictionary<string, string> lstParam = new Dictionary<string, string>();

            string sql = "SELECT par_nom, par_valeur FROM parametre";
            logger.Info("loadParam: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lstParam.Add(reader.GetString(0), reader.GetString(1));
                    }
                }
            }

            return lstParam;

        }

        public DataTable dtLoadParam()
        {

            DataSet dsCateg = new DataSet();
            DataTable dtCateg = new DataTable();
            string sql = "SELECT par_nom, par_valeur FROM parametre";
            logger.Info("dtLoadParam: requête = " + sql);

            _DB = new SQLiteDataAdapter(sql, _dbConnection);

            dsCateg.Reset();
            _DB.Fill(dsCateg, "Param");
            dtCateg = dsCateg.Tables["Param"];


            return dtCateg;

        }

        public Boolean updateParam(String paramKey, string paramValue)
        {

            openBase();

            string sql = "UPDATE parametre SET par_valeur = '" + paramValue + "' WHERE par_nom = '" + paramKey + "'";
            logger.Info("updateParam: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }
        #endregion


        #region Gestion des compétitions.
        public string existsActiveCompetition()
        {

            string name = String.Empty;

            openBase();

            string sql = "SELECT com_nom FROM competition WHERE com_active = 1";
            logger.Info("existsActiveCompetition: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        name = reader.GetString(0);
                        logger.Info("existsActiveCompetition: name = " + name);
                    }

                }
            }

            closeBase();

            return name;
        }

        public Boolean insertCompetition(string name)
        {

            openBase();

            // Désactive toutes les compétitions actives.
            string sql = "UPDATE competition set com_active = 0 WHERE com_active = 1";
            logger.Info("insertCompetition: requête de désactivation de la competition précédente = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();

                // Ajout de la nouvelle compétition.
                sql = "INSERT INTO competition (com_nom, com_active, com_creation) values ('"
                    + name + "', 1, DATETIME('NOW'))";
                logger.Info("insertCompetition: requête de création de la nouvelle competition = " + sql);

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

            }


            closeBase();

            return true;
        }

        public Boolean updateCompetition(int id, string name)
        {

            openBase();

            string sql = "UPDATE competition SET com_nom = '" + name + "', com_creation = DATETIME('NOW')))" 
                + " WHERE com_id = " + id.ToString();
            logger.Info("updateCompetition: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public int getActiveCompetition()
        { 
            openBase();

            string sql = "SELECT com_id FROM competition WHERE com_active = 1";
            logger.Info("getActiveCompetition: requête = " + sql);

            int comId = -1;

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comId = (int)reader.GetInt16(0);
                    }
                }
            }

            return comId;

        }
        #endregion


        #region Gestion des catégories.
        public Boolean insertCategorie(Categorie categ)
        {

            Categorie categorie = getCategorie(categ.getId());

            if (categorie.getName() == null)
            {

                openBase();

                // Insertion de la nouvelel catégorie.
                string sql = "INSERT INTO categorie (cat_nom, cat_agemin, cat_agemax, cat_sexe, cat_poidsmin, cat_poidsmax, cat_creation)"
                    + "values ('" + categ.getName() + "', " + categ.getAgeMin().ToString() + ", " + categ.getAgeMax().ToString() + ", '"
                    + categ.getSexe() + "', " + categ.getPoidsMin().ToString() + ", " + categ.getPoidsMax().ToString() + ", DATETIME('NOW'))";
                logger.Info("insertCategorie: requête = " + sql);

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
                {
                    cmd.ExecuteNonQuery();

                }


                closeBase();

            }
            else
            {
                updateCategorie(categ);
            }

            return true;
        }

        public Boolean updateCategorie(Categorie categ)
        {

            openBase();

            string sql = "UPDATE categorie SET cat_nom = '" + categ.getName() + "', cat_agemin = " + categ.getAgeMin().ToString()
                 + ", cat_agemax = " + categ.getAgeMax().ToString() + ", cat_sexe = '" + categ.getSexe() + "', cat_poidsmin = "
                 + categ.getPoidsMin().ToString() + ", cat_poidsmax = " + categ.getPoidsMax().ToString()
                 + ", cat_modification = DATETIME('NOW')"
                + " WHERE cat_id = " + categ.getId();
            logger.Info("updateCategorie: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean deleteCategorie(Categorie categ)
        {

            openBase();

            string sql = "DELETE FROM categorie WHERE cat_id = " + categ.getId();
            logger.Info("deleteCategorie: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean deleteCategorie(int id)
        {

            openBase();

            string sql = "DELETE FROM categorie WHERE cat_id = " + id;
            logger.Info("deleteCategorie: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Categorie getCategorie(int id)
        {

            openBase();

            string sql = "SELECT cat_id, cat_nom, cat_agemin, cat_agemax, cat_sexe, cat_poidsmin, cat_poidsmax, cat_creation FROM categorie WHERE cat_id = " + id;
            logger.Info("getCategorie: requête = " + sql);

            Categorie categ = new Categorie();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categorie.Sexe sexe = reader.GetString(4) == "F" ? Categorie.Sexe.FEMALE : Categorie.Sexe.MALE;
                        categ = new Categorie( (int) reader.GetInt16(0), 
                                                reader.GetString(1),
                                                (int) reader.GetInt16(2),
                                                (int) reader.GetInt16(3), 
                                                sexe,
                                                (int) reader.GetInt16(5),
                                                (int) reader.GetInt16(6));
                    }
                }
            }



            closeBase();

            return categ;
        }

        public DataTable loadCategories()
        {

            DataSet dsCateg = new DataSet();
            DataTable dtCateg = new DataTable();
            string sql = "SELECT cat_id, cat_nom, cat_agemin, cat_agemax, cat_sexe, cat_poidsmin, cat_poidsmax FROM categorie";
            logger.Info("loadCategories: requête = " + sql);

            _DB = new SQLiteDataAdapter(sql, _dbConnection);

            dsCateg.Reset();
            _DB.Fill(dsCateg, "Categorie");
            dtCateg = dsCateg.Tables["Categorie"];


            return dtCateg;

        }
        #endregion


        #region Gestion des clubs
        public int insertClub(Club c)
        {
            int id = -1;
            Club club = getClub(c.getNom());

            if (club.getNom() == null)
            {

                openBase();

                // Insertion de la nouvelle poule.
                string sql = "INSERT INTO club (clu_nom, clu_creation)"
                    + " values ('" + c.getNom() + "', DATETIME('NOW'))";
                logger.Info("insertClub: requête = " + sql);

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
                {
                    cmd.ExecuteNonQuery();

                }

                club = this.getClub(c.getNom());
                id = club.getId();
                closeBase();

            }
            else
            {
                updateClub(c);
                id = club.getId();
            }

            return id;
        }

        public Boolean updateClub(Club club)
        {

            openBase();

            string sql = "UPDATE club SET clu_nom = '" + club.getNom() + "', clu_modification = DATETIME('NOW')"
                + " WHERE clu_id = " + club.getId();
            logger.Info("updateClub: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean deleteClub(Club club)
        {

            openBase();

            string sql = "DELETE FROM club WHERE clu_id = " + club.getId();
            logger.Info("deleteClub: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean deleteClub(int id)
        {

            openBase();

            string sql = "DELETE FROM club WHERE clu_id = " + id;
            logger.Info("deleteClub: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean deleteClub()
        {

            updatePouleMembre();

            openBase();

            string sql = "DELETE FROM club";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Poule getClub(int id)
        {

            openBase();

            string sql = "SELECT clu_id, clu_nom FROM club WHERE clu_id = " + id;
            logger.Info("getClub: requête = " + sql);

            Poule poule = new Poule();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        poule = new Poule((int)reader.GetInt16(0), reader.GetString(1));
                    }
                }
            }



            closeBase();

            return poule;
        }

        public Club getClub(string nom)
        {

            openBase();

            string sql = "SELECT clu_id, clu_nom FROM club WHERE clu_nom = '" + nom + "'";
            logger.Info("getClub: requête = " + sql);

            Club club = new Club();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        club = new Club((int)reader.GetInt16(0), reader.GetString(1));
                    }
                }
            }

            closeBase();

            return club;
        }

        public List<Club> getClub()
        {

            openBase();

            string sql = "SELECT clu_id, clu_nom FROM club ORDER BY clu_nom";
            logger.Info("getClub: requête = " + sql);

            List<Club> lstClub = new List<Club>();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Club club = new Club((int)reader.GetInt16(0),
                                                reader.GetString(1));
                        lstClub.Add(club);
                    }

                }
            }

            closeBase();

            return lstClub;
        }

        public DataTable loadClub()
        {

            DataSet dsClub = new DataSet();
            DataTable dtClub = new DataTable();
            string sql;
            sql = "SELECT clu_id, clu_nom, clu_creation, clu_modification FROM club;";

            logger.Info("loadClub: requête = " + sql);

            _DB = new SQLiteDataAdapter(sql, _dbConnection);

            dsClub.Reset();
            _DB.Fill(dsClub, "Club");
            dtClub = dsClub.Tables["Club"];

            return dtClub;

        }
        #endregion


        #region Gestion des membres.
        public Boolean insertMembre(Membre mbr)
        {

            Membre membre = getMembre(mbr.getId());

            if (membre.getNom() == null)
            {

                openBase();

                // Insertion de le nouveau membre.
                string sql = "INSERT INTO membre (mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_club, mem_creation)"
                    + "values ('" + mbr.getNom() + "', '" + mbr.getPrenom() + "', '" + mbr.getSexe()
                    + "', " + mbr.getAge().ToString() + ", " + mbr.getPoids().ToString() + ", " + mbr.getClub() + ", DATETIME('NOW'))";
                logger.Info("insertMembre: requête = " + sql);

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
                {
                    cmd.ExecuteNonQuery();

                }


                closeBase();

            }
            else
            {
                updateMembre(mbr);
            }

            return true;
        }

        public Boolean updateMembre(Membre membre)
        {

            openBase();

            string sql = "UPDATE membre SET mem_nom = '" + membre.getNom() + "', mem_prenom = '" + membre.getPrenom()
                 + "', mem_sexe = '" + membre.getSexe() + "', mem_age = " + membre.getAge().ToString()
                 + ", mem_poids = " + membre.getPoids().ToString() + ", mem_club = " + membre.getClub() + ", mem_modification = DATETIME('NOW')"
                + " WHERE mem_id = " + membre.getId();
            logger.Info("updateMembre: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean updatePouleMembre(int idMembre, int idPoule)
        {

            openBase();

            string sql = "UPDATE membre SET mem_poule = " + idPoule + " WHERE mem_id = " + idMembre;
            logger.Info("updatePouleMembre: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean updatePouleMembre()
        {

            openBase();

            string sql = "UPDATE membre SET mem_poule = null";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean deleteMembre(Membre membre)
        {

            openBase();

            string sql = "DELETE FROM membre WHERE mem_id = " + membre.getId();
            logger.Info("deleteMembre: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean deleteMembre(int id)
        {

            openBase();

            string sql = "DELETE FROM membre WHERE mem_id = " + id;
            logger.Info("deleteMembre: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Membre getMembre(int id)
        {

            openBase();

            string sql = "SELECT mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_club FROM membre WHERE mem_id = " + id;
            logger.Info("getMembre: requête = " + sql);

            Membre membre = new Membre();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categorie.Sexe sexe = reader.GetString(3) == "F" ? Categorie.Sexe.FEMALE : Categorie.Sexe.MALE;
                        membre = new Membre((int)reader.GetInt16(0),
                                                reader.GetString(1),
                                                reader.GetString(2),
                                                sexe,
                                                (int)reader.GetInt16(4),
                                                (int)reader.GetInt16(5),
                                                (int)reader.GetInt16(6));
                    }
                }
            }



            closeBase();

            return membre;
        }

        public List<Membre> getMembres()
        {

            openBase();

            string sql = "SELECT mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_club "
                        + "FROM membre WHERE mem_poule is null order by mem_sexe, mem_poids";
            logger.Info("getMembres: requête = " + sql);

            List<Membre> lstMembre = new List<Membre>();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categorie.Sexe sexe = reader.GetString(3) == "F" ? Categorie.Sexe.FEMALE : Categorie.Sexe.MALE;
                        Membre membre = new Membre((int)reader.GetInt16(0),
                                                reader.GetString(1),
                                                reader.GetString(2),
                                                sexe,
                                                (int)reader.GetInt16(4),
                                                (int)reader.GetInt16(5),
                                                (int)reader.GetInt16(6));
                        lstMembre.Add(membre);
                    }

                }
            }



            closeBase();

            return lstMembre;
        }

        public List<Membre> getMembres(int pouleId)
        {

            openBase();

            string sql = "SELECT mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_club FROM membre "
                        + "WHERE mem_poule = " + pouleId
                        + " ORDER BY mem_sexe, mem_age, mem_poids";
            logger.Info("getMembres: requête = " + sql);

            List<Membre> lstMembre = new List<Membre>();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categorie.Sexe sexe = reader.GetString(3) == "F" ? Categorie.Sexe.FEMALE : Categorie.Sexe.MALE;
                        Membre membre = new Membre((int)reader.GetInt16(0),
                                                reader.GetString(1),
                                                reader.GetString(2),
                                                sexe,
                                                (int)reader.GetInt16(4),
                                                (int)reader.GetInt16(5),
                                                (int)reader.GetInt16(6));
                        lstMembre.Add(membre);
                    }

                }
            }



            closeBase();

            return lstMembre;
        }

        public List<Membre> getMembres(string sSexe, int age, int poids, int deltaAge, int deltaPoids, string lstClub, string lstDone)
        {

            openBase();

            int AgeMax = age + deltaAge;
            int poidsMax = poids + deltaPoids;
            if (lstDone.EndsWith(",")) lstDone = lstDone.Substring(0, lstDone.Length - 1);

            string sql = "SELECT mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_club FROM membre WHERE mem_sexe = '" + sSexe 
                + "' AND mem_age >= " + age + " AND mem_age <= " + AgeMax
                + " AND mem_poids >= " + poids + " AND mem_poids <= " + poidsMax
                + " AND MEM_POULE is null AND mem_id not in (" + lstDone + ")" + " AND mem_club not in (" + lstClub + ")";

            logger.Info("getMembre: requête = " + sql);

            List<Membre> lstMembre = new List<Membre>();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categorie.Sexe sexe = reader.GetString(3) == "F" ? Categorie.Sexe.FEMALE : Categorie.Sexe.MALE;
                        Membre membre = new Membre((int)reader.GetInt16(0),
                                                reader.GetString(1),
                                                reader.GetString(2),
                                                sexe,
                                                (int)reader.GetInt16(4),
                                                (int)reader.GetInt16(5),
                                                (int)reader.GetInt16(6));
                        lstMembre.Add(membre);
                    }
                }
            }

            closeBase();

            return lstMembre;
        }

        public DataTable loadMembres()
        {

            DataSet dsMembre = new DataSet();
            DataTable dtMembre = new DataTable();
            string sql = "SELECT mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, c.clu_nom, mem_poule, mem_creation, mem_modification "
                       + "FROM membre m LEFT JOIN club c ON m.mem_club = c.clu_id "
                       + "ORDER BY mem_sexe, mem_age, mem_poids;";
            logger.Info("loadMembres: requête = " + sql);

            _DB = new SQLiteDataAdapter(sql, _dbConnection);

            dsMembre.Reset();
            _DB.Fill(dsMembre, "Membre");
            dtMembre = dsMembre.Tables["Membre"];


            return dtMembre;

        }
        #endregion


        #region Gestion des poules.
        public int insertPoule(Poule p)
        {
            int id = -1;
            Poule poule = getPoule(p.getNom());

            if (poule.getNom() == null)
            {

                openBase();

                // Insertion de la nouvelle poule.
                string sql = "INSERT INTO poule (pou_nom, pou_competition, pou_creation)"
                    + " values ('" + p.getNom() + "'," + getActiveCompetition() + ", DATETIME('NOW'))";
                logger.Info("insertPoule: requête = " + sql);

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
                {
                    cmd.ExecuteNonQuery();

                }

                poule = this.getPoule(p.getNom());
                id = poule.getId();
                closeBase();

            }
            else
            {
                updatePoule(p);
                id = poule.getId();
            }

            return id;
        }

        public Boolean updatePoule(Poule poule)
        {

            openBase();

            string sql = "UPDATE poule SET pou_nom = '" + poule.getNom() + "', pou_modification = DATETIME('NOW')"
                + " WHERE pou_id = " + poule.getId();
            logger.Info("updatePoule: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean deletePoule(Poule poule)
        {

            openBase();

            string sql = "DELETE FROM poule WHERE pou_id = " + poule.getId();
            logger.Info("deletePoule: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean deletePoule(int id)
        {

            openBase();

            string sql = "DELETE FROM poule WHERE pou_id = " + id;
            logger.Info("deletePoule: requête = " + sql);

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Boolean deletePoule()
        {

            updatePouleMembre();

            openBase();

            string sql = "DELETE FROM poule";
                
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();
            }
            closeBase();

            return true;
        }

        public Poule getPoule(int id)
        {

            openBase();

            string sql = "SELECT pou_id, pou_nom FROM poule WHERE pou_id = " + id;
            logger.Info("getPoule: requête = " + sql);

            Poule poule = new Poule();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        poule = new Poule((int)reader.GetInt16(0), reader.GetString(1));
                    }
                }
            }



            closeBase();

            return poule;
        }

        public Poule getPoule(string nom)
        {

            openBase();

            string sql = "SELECT pou_id, pou_nom FROM poule WHERE pou_nom = '" + nom + "'";
            logger.Info("getPoule: requête = " + sql);

            Poule poule = new Poule();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        poule = new Poule((int)reader.GetInt16(0), reader.GetString(1));
                    }
                }
            }

            closeBase();

            return poule;
        }

        public DataTable loadPoules(string scope)
        {

            DataSet dsPoule = new DataSet();
            DataTable dtPoule = new DataTable();
            string sql;
            if (scope == "ALL")
                sql = "SELECT pou_id, pou_nom, pou_creation, pou_modification FROM poule;";
            else
                sql = "SELECT pou_id, pou_nom, pou_creation, pou_modification FROM poule "
                    + "WHERE pou_id in (SELECT distinct mem_poule FROM MEMBRE);";

            logger.Info("loadPoules: requête = " + sql);

            _DB = new SQLiteDataAdapter(sql, _dbConnection);

            dsPoule.Reset();
            _DB.Fill(dsPoule, "Poule");
            dtPoule = dsPoule.Tables["Poule"];

            return dtPoule;

        }
        #endregion
    }
}
