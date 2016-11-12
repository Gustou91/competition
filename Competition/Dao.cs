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

                // Table des compétitons.
                string sql = "CREATE TABLE competition (com_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                    + "com_nom STRING (50) NOT NULL, com_active BOOLEAN NOT NULL, com_creation DATETIME NOT NULL)";
                SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();

                // Table des catégories.
                sql = "CREATE TABLE categorie ( cat_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, " 
                    + "cat_nom STRING (50) NOT NULL, cat_agemin INT NOT NULL, cat_agemax INT NOT NULL, "
                    + "cat_sexe CHAR (1) NOT NULL, cat_poidsmin INT NOT NULL, cat_poidsmax INT NOT NULL, "
                    + "cat_creation DATETIME NOT NULL, cat_modification DATETIME )";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();

                // Table des membres.
                sql = "CREATE TABLE membre (mem_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                    + "mem_nom STRING (50) NOT NULL,mem_prenom STRING (50) NOT NULL,mem_sexe CHAR (1) NOT NULL, "
                    + "mem_age INT (2) NOT NULL,mem_poids INT (3) NOT NULL,mem_creation DATETIME NOT NULL)";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();

                // Table des poules.
                sql = "CREATE TABLE poule (pou_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                    + "pou_name STRING (10) NOT NULL, pou_position INTEGER UNIQUE ON CONFLICT ROLLBACK)";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();

                // Table des randori.
                sql = "CREATE TABLE randori ( ran_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                    + "ran_membre1 INTEGER REFERENCES membre (mem_id), ran_membre2 INTEGER REFERENCES membre (mem_id) )";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();

                // Table des résultats.
                sql = "CREATE TABLE resultat ( res_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, "
                    + "res_membre INTEGER REFERENCES membre (mem_id), "
                    + "res_randori INTEGER REFERENCES randori (ran_id), res_victoire BOOLEAN NOT NULL, "
                    + "res_points INT NOT NULL)";
                command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();

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
                    reader.Read();
                    name = reader.GetString(0);
                    logger.Info("existsActiveCompetition: name = " + name);

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

            //_DB.DeleteCommand = new SQLiteCommand("DELETE FROM categorie where cat_id=@Id");
            //_DB.DeleteCommand.Parameters.Add("@Id");


            return dtCateg;

        }




        public Boolean insertMembre(Membre mbr)
        {

            Membre membre = getMembre(mbr.getId());

            if (membre.getNom() == null)
            {

                openBase();

                // Insertion de le nouveau membre.
                string sql = "INSERT INTO membre (mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation)"
                    + "values ('" + mbr.getNom() + "', '" + mbr.getPrenom() + "', '" + mbr.getSexe()
                    + "', " + mbr.getAge().ToString() + ", " + mbr.getPoids().ToString() + ", DATETIME('NOW'))";
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
                 + ", mem_sexe = '" + membre.getSexe() + "', mem_age = " + membre.getAge().ToString() 
                 + ", mem_poids = " + membre.getPoids().ToString() + ", mem_modification = DATETIME('NOW')"
                + " WHERE mem_id = " + membre.getId();
            logger.Info("updateMembre: requête = " + sql);

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

            string sql = "SELECT mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids FROM membre WHERE mem_id = " + id;
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
                                                (int)reader.GetInt16(5));
                    }
                }
            }



            closeBase();

            return membre;
        }

        public DataTable loadMembres()
        {

            DataSet dsMembre = new DataSet();
            DataTable dtMembre = new DataTable();
            string sql = "SELECT mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation FROM membre;";
            logger.Info("loadMembres: requête = " + sql);

            _DB = new SQLiteDataAdapter(sql, _dbConnection);

            dsMembre.Reset();
            _DB.Fill(dsMembre, "Membre");
            dtMembre = dsMembre.Tables["Membre"];

            //_DB.DeleteCommand = new SQLiteCommand("DELETE FROM categorie where cat_id=@Id");
            //_DB.DeleteCommand.Parameters.Add("@Id");


            return dtMembre;

        }




        public Boolean insertPoule(Poule p)
        {

            Poule poule = getPoule(p.getId());

            if (poule.getNom() == null)
            {

                openBase();

                // Insertion de la nouvelle poule.
                string sql = "INSERT INTO poule (pou_nom, pou_creation)"
                    + " values ('" + p.getNom()  + "', DATETIME('NOW'))";
                logger.Info("insertPoule: requête = " + sql);

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
                {
                    cmd.ExecuteNonQuery();

                }


                closeBase();

            }
            else
            {
                updatePoule(p);
            }

            return true;
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

        public DataTable loadPoules()
        {

            DataSet dsPoule = new DataSet();
            DataTable dtPoule = new DataTable();
            string sql = "SELECT pou_id, pou_nom, pou_creation, pou_modification FROM poule;";
            logger.Info("loadPoules: requête = " + sql);

            _DB = new SQLiteDataAdapter(sql, _dbConnection);

            dsPoule.Reset();
            _DB.Fill(dsPoule, "Poule");
            dtPoule = dsPoule.Tables["Poule"];

            return dtPoule;

        }
    }
}
