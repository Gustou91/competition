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
        private object _selectedCategId;


        public frmCateg()
        {
            InitializeComponent();
        }

        private void frmCateg_Load(object sender, EventArgs e)
        {
            dao.openBase();

            dgvCateg.DataSource = dao.loadCategories();
            // Resize the DataGridView columns to fit the newly loaded content.
            dgvCateg.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dao.closeBase();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Categorie.Sexe sexe = cbSexe.SelectedItem == "F" ? Categorie.Sexe.FEMALE : Categorie.Sexe.MALE;
            Categorie categ = new Categorie(tb_nom.Text, (int)nudAgeMin.Value, (int)nudAgeMax.Value, sexe, (int)nudPoidsMin.Value, (int) nudPoidsMax.Value);
            categ.insert();
        }

        private void dgvCateg_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCateg.SelectedRows)
            {
                _selectedCategId = row.Cells[0].Value;
                //string value2 = row.Cells[1].Value.ToString();
                //...
            }
        }

        private void dgvCateg_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_selectedCategId != null)
            {
                int categId = Convert.ToInt32(_selectedCategId);
                dao.deleteCategorie(categId);
            }
        }







    }
}
