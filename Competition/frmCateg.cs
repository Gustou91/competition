using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using log4net.Config;

namespace Competition
{
    public partial class frmCateg : Form
    {

        private Dao dao = Dao.Instance;
        private object _selectedCategId;

        private static readonly ILog logger = LogManager.GetLogger(typeof(frm_main));

        public frmCateg()
        {
            InitializeComponent();
        }

        private void frmCateg_Load(object sender, EventArgs e)
        {
            loadListCateg();
        }


        private void loadListCateg()
        {
            logger.Info("loadListCateg: Chargement de la liste des catégories.");

            dao.openBase();

            dgvCateg.DataSource = dao.loadCategories();
            // Resize the DataGridView columns to fit the newly loaded content.
            dgvCateg.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dao.closeBase();
        }


        private void clearForm()
        {
            logger.Info("clearForm: Remise à blanc du formulaire.");

            tb_nom.Text = "";
            nudAgeMin.Value = 0;
            nudAgeMax.Value = 0;
            nudPoidsMin.Value = 0;
            nudPoidsMax.Value = 0;
            //cbSexe.SelectedItem = "";
            cbSexe.ResetText();

            _selectedCategId = null;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            logger.Info("frmCateg.btnOk_Click: Validation du formulaire.");

            Categorie.Sexe sexe = cbSexe.SelectedItem == "Fille" ? Categorie.Sexe.FEMALE : Categorie.Sexe.MALE;
            Categorie categ = new Categorie();

            if (_selectedCategId != null)
            {
                logger.Info("frmCateg.btnOk_Click: L'identifiant est connu.");
                categ = new Categorie(Convert.ToInt32(_selectedCategId), tb_nom.Text, (int)nudAgeMin.Value, (int)nudAgeMax.Value, sexe, (int)nudPoidsMin.Value, (int)nudPoidsMax.Value);
            }
            else
            {
                logger.Info("frmCateg.btnOk_Click: L'identifiant n'est pas connu.");
                categ = new Categorie(tb_nom.Text, (int)nudAgeMin.Value, (int)nudAgeMax.Value, sexe, (int)nudPoidsMin.Value, (int)nudPoidsMax.Value);
            }
            categ.insert();
            _selectedCategId = null;

            // Mise à jour de la liste.
            loadListCateg();

            clearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            logger.Info("frmCateg.btnCancel_Click: Annulation du formulaire.");

            clearForm();
        }


        private void dgvCateg_SelectionChanged(object sender, EventArgs e)
        {
            logger.Info("dgvCateg_SelectionChanged: Changement de ligne.");

            foreach (DataGridViewRow row in dgvCateg.SelectedRows)
            {
                _selectedCategId = row.Cells[0].Value;
            }
        }

        private void dgvCateg_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_selectedCategId != null)
            {
                logger.Info("dgvCateg_RowsRemoved: Suppression d'une ligne.");
                int categId = Convert.ToInt32(_selectedCategId);
                dao.deleteCategorie(categId);
            }
        }

        private void dgvCateg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            logger.Info("dgvCateg_CellDoubleClick: Sélection d'une ligne.");
            foreach (DataGridViewRow row in dgvCateg.SelectedRows)
            {
                _selectedCategId = row.Cells[0].Value;
                tb_nom.Text = row.Cells[1].Value.ToString();
                nudAgeMin.Value = Convert.ToInt32(row.Cells[2].Value);
                nudAgeMax.Value = Convert.ToInt32(row.Cells[3].Value);
                cbSexe.SelectedIndex = row.Cells[4].Value.ToString() == "F" ? 1 : 0;
                nudPoidsMin.Value = Convert.ToInt32(row.Cells[5].Value);
                nudPoidsMax.Value = Convert.ToInt32(row.Cells[6].Value);
            }
            
        }







    }
}
