using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Competition
{
    class Club
    {

        private int _id;
        private string _nom;
        private DateTime _creation;
        private DateTime _modification;

        private Boolean _init = false;
        private Dao dao = Dao.Instance;

        public Club()
        { 
        }

        public Club(int id, string nom)
        {
            if (id > -1)
                _id = id;
            else
                throw new System.ArgumentException("L'identifiant doit être initialisé.");

            createClub(nom);
        }

        public Club(string nom)
        {
            createClub(nom);
        }


        private void createClub(string nom)
        {
            if (nom != null && nom != String.Empty)
                _nom = nom;
            else
                throw new System.ArgumentException("Le nom ne peut être vide.");

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
                _id = dao.insertClub(this);
        }

        public void update()
        {
            if (_init)
                dao.updateClub(this);
        }

        public void delete()
        {
            if (_init)
                dao.deleteClub(this);
        }
    }
}
