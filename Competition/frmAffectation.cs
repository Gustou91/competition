using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Competition
{
    public partial class frmAffectation : Form
    {

        private Dao dao = Dao.Instance;

        public frmAffectation()
        {
            InitializeComponent();
        }

        private void frmAffectation_Load(object sender, EventArgs e)
        {
            loadPoules();

            lvMembre.LargeImageList = ilIcon;

        }

        private void loadPoules()
        {
            dao.openBase();

            DataTable dtPoule = dao.loadPoules("ACTIVE");

            cbPoule.DataSource = dtPoule;
            cbPoule.DisplayMember = dtPoule.Columns[1].ToString();
            cbPoule.ValueMember = dtPoule.Columns[0].ToString();

            dao.closeBase();
        }


        private void loadMembres(int pouleId)
        {
            List<Membre> lstMembres = dao.getMembres(pouleId);
            lvMembre.Clear();

            foreach (Membre membre in lstMembres)
            {
                ListViewItem lviMembre = lvMembre.Items.Add(membre.getPrenom() + " " + membre.getNom());
                lviMembre.ImageIndex = membre.getSexe() == "M" ? 0 : 1;
            }
        }


        private void cbPoule_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedValue = cbPoule.SelectedValue;
            if (selectedValue.GetType().Equals(typeof(Int64)))
            {
                Int64 pouleId64 = (Int64)cbPoule.SelectedValue;
                //int pouleId = (int)cbPoule.SelectedValue;
                int pouleId = (int)pouleId64;
                loadMembres(pouleId);
            }
        }
    }
}
