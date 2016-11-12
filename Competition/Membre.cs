using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Competition
{
    class Membre
    {

        private int _id;
        private string _nom;
        private string _prenom;
        private Categorie.Sexe _sexe;
        private int _age;
        private int _poids;
        private DateTime _creation;

        private Boolean _init = false;
        private Dao dao = Dao.Instance;



        public Membre()
        {
        }

        public Membre(int id, string name, string firstName, Categorie.Sexe sexe, int age, int poids)
        {
            if (id != null)
                _id = id;
            else
                throw new System.ArgumentException("L'identifiant doit être initialisé.");

            createMembre(name, firstName, sexe, age, poids);

        }

        public Membre(string name, string firstName, Categorie.Sexe sexe, int age, int poids)
        {

            createMembre(name, firstName, sexe, age, poids);

        }

        private void createMembre(string name, string firstName, Categorie.Sexe sexe, int age, int poids)
        {

            if (name != null && name != String.Empty)
                _nom = name;
            else
                throw new System.ArgumentException("Le nom ne peut être vide");

            if (firstName != null && firstName != String.Empty)
                _prenom = firstName;
            else
                throw new System.ArgumentException("Le prénom ne peut être vide");

            if (age >= 3)
            {
                _age = age;
            }
            else
                throw new System.ArgumentException("L'age minimal doit être >= 3.");

            if (poids >= 10)
            {
                _poids = poids;
            }
            else
                throw new System.ArgumentException("Le poids minimal doit être >= 10.");

            _sexe = sexe;
            _init = true;
        }



        public int getId()
        {
            return _id;
        }

        public string getNom()
        {
            return _nom;
        }

        public string getPrenom()
        {
            return _prenom;
        }

        public int getAge()
        {
            return _age;
        }

        public string getSexe()
        {
            string sSexe;
            sSexe = _sexe == Categorie.Sexe.MALE ? "M" : "F";
            return sSexe;
        }

        public int getPoids()
        {
            return _poids;
        }


        public void insert()
        {
            if (_init)
                dao.insertMembre(this);
        }

        public void update()
        {
            if (_init)
                dao.updateMembre(this);
        }

        public void delete()
        {
            if (_init)
                dao.deleteMembre(this);
        }


    }
}
