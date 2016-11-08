using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Competition
{
    public partial class frm_main : Form
    {

        SQLiteConnection m_dbConnection;

        public frm_main()
        {
            InitializeComponent();

            Dao dao = Dao.Instance;

        }




        private void gérerLesCompétitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCompet frm = new frmAddCompet();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gérerLesCatégoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCateg frm = new frmCateg();
            frm.MdiParent = this;
            frm.Show();
        }

        private void inscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMembre frm = new frmMembre();
            frm.MdiParent = this;
            frm.Show();

        }
    }
}
