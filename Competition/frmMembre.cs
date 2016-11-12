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
    public partial class frmMembre : Form
    {

        private Dao dao = Dao.Instance;
        private object _selectedMembreId;


        public frmMembre()
        {
            InitializeComponent();
        }

        private void frmMembre_Load(object sender, EventArgs e)
        {
            loadListMembre();
        }


        private void loadListMembre()
        {
            dao.openBase();

            dgvMembre.DataSource = dao.loadMembres();
            // Resize the DataGridView columns to fit the newly loaded content.
            dgvMembre.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dao.closeBase();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            Categorie.Sexe sexe = cbSexe.SelectedItem == "Fille" ? Categorie.Sexe.FEMALE : Categorie.Sexe.MALE;
            Membre membre = new Membre();

            if (_selectedMembreId != null)
            {
                membre = new Membre(Convert.ToInt32(_selectedMembreId), tb_nom.Text, tb_prenom.Text, sexe, (int)nudAge.Value, (int)nudPoids.Value);
            }
            else
            {
                membre = new Membre(tb_nom.Text, tb_prenom.Text, sexe, (int)nudAge.Value, (int)nudPoids.Value);
            }
            membre.insert();

            // Mise à jour de la liste.
            loadListMembre();
        }

        private void dgvMembre_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMembre.SelectedRows)
            {
                _selectedMembreId = row.Cells[0].Value;
            }
        }

        private void dgvMembre_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_selectedMembreId != null)
            {
                int membreId = Convert.ToInt32(_selectedMembreId);
                dao.deleteMembre(membreId);
            }
        }

        private void dgvMembre_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMembre.SelectedRows)
            {
                _selectedMembreId = row.Cells[0].Value;
                tb_nom.Text = row.Cells[1].Value.ToString();
                tb_prenom.Text = row.Cells[2].Value.ToString();
                cbSexe.SelectedIndex = row.Cells[3].Value.ToString() == "F" ? 1 : 0;
                nudAge.Value = Convert.ToInt32(row.Cells[4].Value);
                nudPoids.Value = Convert.ToInt32(row.Cells[5].Value);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _selectedMembreId = null;
            tb_nom.Text = "";
            tb_prenom.Text = "";
            nudAge.Value = 0;
            cbSexe.ResetText();
            nudPoids.Value = 0;
        }

    }
}
