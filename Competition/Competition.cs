using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Competition
{

    class Competition
    {

        private int _id;
        private string _name;
        private DateTime _creation;

        private Dao dao = Dao.Instance;



        public Competition(string name)
        {
            _name = name;
        }

        public Competition(int id, string name, DateTime creation)
        {
            _id = id;
            _name = name;
            _creation = creation;
        }


        public void insert()
        {
            dao.insertCompetition(_name);
        }

        public void update()
        {
            dao.updateCompetition(_id, _name);
        }
    }
}
