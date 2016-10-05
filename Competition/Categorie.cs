using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Competition
{
    class Categorie
    {

        private int _id;
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


        public Categorie()
        {
        }

        public Categorie(int id, string name, int ageMin, int ageMax, Categorie.Sexe sexe, int poidsMin, int poidsMax)
        {
            if (id != null)
                _id = id;
            else
                throw new System.ArgumentException("L'identifiant doit être initialisé.");

            createCategorie(name, ageMin, ageMax, sexe, poidsMin, poidsMax);

        }

        public Categorie(string name, int ageMin, int ageMax, Categorie.Sexe sexe, int poidsMin, int poidsMax)
        {
            createCategorie(name, ageMin, ageMax, sexe, poidsMin, poidsMax);
        }

        private void createCategorie(string name, int ageMin, int ageMax, Categorie.Sexe sexe, int poidsMin, int poidsMax)
        {

            if (name != null && name != String.Empty)
                _name = name;
            else
                throw new System.ArgumentException("Le nom ne peut être vide");

            if (ageMin > 0 && ageMin <= ageMax)
            {
                _ageMin = ageMin;
                _ageMax = ageMax;
            }
            else
                throw new System.ArgumentException("L'age minimal doit être > 0 et <= à l'age max.");

            if (poidsMin > 0 && poidsMin <= poidsMax)
            {
                _poidsMin = poidsMin;
                _poidsMax = poidsMax;
            }
            else
                throw new System.ArgumentException("Le poids minimal doit être > 0 et <= au poids max.");

            _init = true;
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
                dao.insertCategorie(this);
        }

        public void update()
        {
            if (_init)
                dao.updateCategorie(this);
        }

        public void delete()
        {
            if (_init)
                dao.deleteCategorie(this);
        }
    }
}
