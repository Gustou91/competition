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
    public partial class frmCateg : Form
    {

        private Dao dao = Dao.Instance;

        public frmCateg()
        {
            InitializeComponent();
        }

        private void frmCateg_Load(object sender, EventArgs e)
        {
            dao.openBase();

            dgvCateg.DataSource = dao.loadCategories();

            dao.closeBase();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Categorie.Sexe sexe = cbSexe.SelectedItem == "F" ? Categorie.Sexe.FEMALE : Categorie.Sexe.MALE;
            Categorie categ = new Categorie(tb_nom.Text, (int)nudAgeMin.Value, (int)nudAgeMax.Value, sexe, (int)nudPoidsMin.Value, (int) nudPoidsMax.Value);
            categ.insert();
        }
    }
}
