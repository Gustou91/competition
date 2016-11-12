using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using log4net;
using log4net.Config;

namespace Competition
{
    public partial class frm_main : Form
    {

        SQLiteConnection m_dbConnection;

        private static readonly ILog logger = LogManager.GetLogger(typeof(frm_main));
       

        public frm_main()
        {
            InitializeComponent();

            Logger.Setup();
            logger.Info("Démarrage de l'application.");

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
            frmPoule frm = new frmPoule();
            frm.MdiParent = this;
            frm.Show();

        }

        private void gérerLesPoulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPoule frm = new frmPoule();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
