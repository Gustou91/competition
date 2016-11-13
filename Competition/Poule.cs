using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Competition
{
    class Poule
    {

        private int _id;
        private string _nom;
        private DateTime _creation;

        private Boolean _init = false;
        private Dao dao = Dao.Instance;

        public Poule()
        { 
        }

        public Poule(int id, string nom)
        {
            if (id != null)
                _id = id;
            else
                throw new System.ArgumentException("L'identifiant doit être initialisé.");

            createPoule(nom);
        }

        public Poule(string nom)
        {
            createPoule(nom);
        }


        private void createPoule(string nom)
        {
            if (nom != null && nom != String.Empty)
                _nom = nom;
            else
                throw new System.ArgumentException("Le nom ne peut être vide");

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


        public void insert()
        {
            if (_init)
                _id = dao.insertPoule(this);
        }

        public void update()
        {
            if (_init)
                dao.updatePoule(this);
        }

        public void delete()
        {
            if (_init)
                dao.deletePoule(this);
        }
    }
}
