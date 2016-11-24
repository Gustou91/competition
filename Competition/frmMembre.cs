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
    public partial class frmMembre : Form
    {

        private Dao dao = Dao.Instance;
        private object _selectedMembreId;

        private static readonly ILog logger = LogManager.GetLogger(typeof(frm_main));


        public frmMembre()
        {
            InitializeComponent();
        }

        private void frmMembre_Load(object sender, EventArgs e)
        {
            // Chargement de la liste des clubs.
            List<Club> lstClub = dao.getClub();

            // Alimentation de la combobox des clubs.
            foreach( Club club in lstClub)
            {
                ComboboxItem item = new ComboboxItem();
                item.Value = club.getId();
                item.Text = club.getNom();
                cblstClub.Items.Add(item);
            }

            loadListMembre();
        }


        private void loadListMembre()
        {
            logger.Info("loadListMembre: Chargement de la liste des poules.");

            dao.openBase();

            dgvMembre.DataSource = dao.loadMembres();
            // Resize the DataGridView columns to fit the newly loaded content.
            dgvMembre.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        
            dao.closeBase();
        }

        private void clearForm()
        {
            logger.Info("frmMembre.clearForm: Remise à blanc du formulaire.");

            tb_nom.Text = "";
            tb_prenom.Text = "";
            nudAge.Value = 0;
            cbSexe.ResetText();
            nudPoids.Value = 0;
            cblstClub.Text = "";

            _selectedMembreId = null;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            logger.Info("frmMembre.btnOk_Click: Validation du formulaire.");
            Categorie.Sexe sexe = cbSexe.SelectedItem == "Fille" ? Categorie.Sexe.FEMALE : Categorie.Sexe.MALE;
            Membre membre = new Membre();

            ComboboxItem cbItem = (ComboboxItem)cblstClub.SelectedItem;

            int clubId = (int) cbItem.Value;

            if (_selectedMembreId != null)
            {
                logger.Info("frmMembre.btnOk_Click: L'identifiant est connu.");
                membre = new Membre(Convert.ToInt32(_selectedMembreId), tb_nom.Text, tb_prenom.Text, sexe, (int)nudAge.Value, (int)nudPoids.Value, clubId);
            }
            else
            {
                logger.Info("frmMembre.btnOk_Click: L'identifiant n'est pas connu.");
                membre = new Membre(tb_nom.Text, tb_prenom.Text, sexe, (int)nudAge.Value, (int)nudPoids.Value, clubId);
            }
            membre.insert();
            _selectedMembreId = null;

            // Mise à jour de la liste.
            loadListMembre();

            clearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            logger.Info("frmMembre.btnCancel_Click: Annulation du formulaire.");

            clearForm();
        }


        private void dgvMembre_SelectionChanged(object sender, EventArgs e)
        {
            logger.Info("dgvMembre_SelectionChanged: Changement de ligne.");
            foreach (DataGridViewRow row in dgvMembre.SelectedRows)
            {
                _selectedMembreId = row.Cells[0].Value;
            }
        }

        private void dgvMembre_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            logger.Info("dgvMembre_RowsRemoved: Suppression d'une ligne.");
            if (_selectedMembreId != null)
            {
                int membreId = Convert.ToInt32(_selectedMembreId);
                dao.deleteMembre(membreId);
            }
        }

        private void dgvMembre_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            logger.Info("dgvMembre_CellDoubleClick: Sélection d'une ligne.");
            foreach (DataGridViewRow row in dgvMembre.SelectedRows)
            {
                _selectedMembreId = row.Cells[0].Value;
                tb_nom.Text = row.Cells[1].Value.ToString();
                tb_prenom.Text = row.Cells[2].Value.ToString();
                cbSexe.SelectedIndex = row.Cells[3].Value.ToString() == "F" ? 1 : 0;
                nudAge.Value = Convert.ToInt32(row.Cells[4].Value);
                nudPoids.Value = Convert.ToInt32(row.Cells[5].Value);
                cblstClub.SelectedIndex = cblstClub.FindString(row.Cells[6].Value.ToString());
            }
            
        }

        private void dgvMembre_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            /*dao.updatePouleMembre(int.Parse(dgvMembre.CurrentRow.Cells[0].Value.ToString()), 
                                  int.Parse(dgvMembre.CurrentRow.Cells[6].Value.ToString()));*/
        }

        private void dgvMembre_SizeChanged(object sender, EventArgs e)
        {
            //dgvMembreDisplay();
        }

        private void frmMembre_ResizeEnd(object sender, EventArgs e)
        {
            //dgvMembreDisplay();
        }

        // Adaptation de la taille du DataGridView à la taille de la fenêtre.
        private void dgvMembreDisplay()
        {
            dgvMembre.Height = this.Size.Height - (dgvMembre.Top + 20 );
            dgvMembre.Width = this.Size.Width - 27;
            this.Width = 780;

        }

        private void frmMembre_ClientSizeChanged(object sender, EventArgs e)
        {
            dgvMembreDisplay();
        }


    }


    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
