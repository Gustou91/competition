using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Data;

namespace Competition
{
    class Dao
    {


        private static Dao _instance = null;

        private String _strAppDir;
        private String _strFullPathDB;
        private SQLiteConnection _dbConnection = new SQLiteConnection("Data Source=USM-JUJITSO-COMPET.sqlite;Version=3;");
        private SQLiteDataAdapter _DB;


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
            }

            return true;
        }


        public Boolean openBase()
        {

            try
            {
                if (_dbConnection.State != System.Data.ConnectionState.Open)
                {
                    _dbConnection.Open();
                }
                return true;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public Boolean closeBase()
        {

            try
            {
                if (_dbConnection.State == System.Data.ConnectionState.Open)
                {
                    _dbConnection.Close();
                }

                return true;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public string existsActiveCompetition()
        {

            string name = String.Empty;

            openBase();

            string sql = "SELECT com_nom FROM competition WHERE com_active = 1";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    name = reader.GetString(0);
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

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
            {
                cmd.ExecuteNonQuery();

                // Ajout de la nouvelle compétition.
                sql = "INSERT INTO competition (com_nom, com_active, com_creation) values ('"
                    + name + "', 1, DATETIME('NOW'))";

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

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _dbConnection))
                {
                    cmd.ExecuteNonQuery();

                }


                closeBase();

            }

            return true;
        }

        public Boolean updateCategorie(Categorie categ)
        {

            openBase();

            string sql = "UPDATE categorie SET cat_nom = '" + categ.getName() + "', cat_agemin = " + categ.getAgeMin().ToString()
                 + ", cat_agemax = " + categ.getAgeMax().ToString() + ", sexe = '" + categ.getSexe() + "', cat_poidsmin = "
                 + categ.getPoidsMin().ToString() + ", cat_poidsmax = " + categ.getPoidsMax().ToString()
                 + "', cat_modification = DATETIME('NOW')))"
                + " WHERE cat_id = " + categ.getId();

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
            _DB = new SQLiteDataAdapter("SELECT cat_id, cat_nom, cat_agemin, cat_agemax, cat_sexe, cat_poidsmin, cat_poidsmax FROM categorie", _dbConnection);
            dsCateg.Reset();
            _DB.Fill(dsCateg, "Categorie");
            dtCateg = dsCateg.Tables["Categorie"];

            //_DB.DeleteCommand = new SQLiteCommand("DELETE FROM categorie where cat_id=@Id");
            //_DB.DeleteCommand.Parameters.Add("@Id");


            return dtCateg;

        }

    }
}
