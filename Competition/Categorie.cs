using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

namespace Competition
{
    class Categorie
    {

        private int _id = -1;
        private string _name;
        private int _ageMin;
        private int _ageMax;
        private Sexe _sexe;
        private int _poidsMin;
        private int _poidsMax;
        private DateTime _creation;
        private DateTime _modification;
        private Boolean _init = false;

        public enum Sexe { MALE = 0, FEMALE = 1 };

        private Dao dao = Dao.Instance;

        private static readonly ILog logger = LogManager.GetLogger(typeof(frm_main));

        public Categorie()
        {
            logger.Info("Categorie: Création d'une instance.");
        }


        public Categorie(int id, string name, int ageMin, int ageMax, Categorie.Sexe sexe, int poidsMin, int poidsMax)
        {
            if (id != null)
            {
                _id = id;
                logger.Info("Categorie: Création de l'instance " + _id);
            }
            else
            {
                logger.Error("Categorie: L'identifiant doit être initialisé.");
                throw new System.ArgumentException("L'identifiant doit être initialisé.");
            }

            createCategorie(name, ageMin, ageMax, sexe, poidsMin, poidsMax);

        }

        public Categorie(string name, int ageMin, int ageMax, Categorie.Sexe sexe, int poidsMin, int poidsMax)
        {
            logger.Info("Categorie: Création de l'instance " + name);
            createCategorie(name, ageMin, ageMax, sexe, poidsMin, poidsMax);
        }

        private void createCategorie(string name, int ageMin, int ageMax, Categorie.Sexe sexe, int poidsMin, int poidsMax)
        {

            if (name != null && name != String.Empty)
                _name = name;
            else
            {
                logger.Error("createCategorie: Le nom ne peut être vide.");
                throw new System.ArgumentException("Le nom ne peut être vide.");
            }

            if (ageMin > 0 && ageMin <= ageMax)
            {
                _ageMin = ageMin;
                _ageMax = ageMax;
            }
            else
            {
                logger.Error("createCategorie: L'age minimal doit être > 0 et <= à l'age max.");
                throw new System.ArgumentException("L'age minimal doit être > 0 et <= à l'age max.");
            }

            if (poidsMin > 0 && poidsMin <= poidsMax)
            {
                _poidsMin = poidsMin;
                _poidsMax = poidsMax;
            }
            else
            {
                logger.Error("createCategorie: Le poids minimal doit être > 0 et <= au poids max.");
                throw new System.ArgumentException("Le poids minimal doit être > 0 et <= au poids max.");
            }

            _sexe = sexe;
            _init = true;

            logger.Info("createCategorie: nom = " + _name);
            logger.Info("createCategorie: age min =" + _ageMin);
            logger.Info("createCategorie: age max = " + _ageMax);
            logger.Info("createCategorie: poids min = " + _poidsMin);
            logger.Info("createCategorie: poids max = " + _poidsMax);
            logger.Info("createCategorie: sexe = " + _sexe.ToString());
        }


        public int getId()
        {
            return _id;
        }

        public string getName()
        {
            return _name;
        }

        public int getAgeMin()
        {
            return _ageMin;
        }

        public int getAgeMax()
        {
            return _ageMax;
        }

        public string getSexe()
        {
            string sSexe;
            sSexe = _sexe == Sexe.MALE ? "M" : "F";
            return sSexe;
        }

        public int getPoidsMin()
        {
            return _poidsMin;
        }

        public int getPoidsMax()
        {
            return _poidsMax;
        }


        public void insert()
        {
            if (_init)
            {
                logger.Info("Categorie.insert.");
                dao.insertCategorie(this);
            }
        }

        public void update()
        {
            if (_init)
            {
                logger.Info("Categorie.update.");
                dao.updateCategorie(this);
            }
        }

        public void delete()
        {
            if (_init)
            {
                logger.Info("Categorie.delete.");
                dao.deleteCategorie(this);
            }
        }
    }
}
