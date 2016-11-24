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
    public partial class frmClub : Form
    {


        private Dao dao = Dao.Instance;
        private object _selectedClubId;

        private static readonly ILog logger = LogManager.GetLogger(typeof(frm_main));


        public frmClub()
        {
            InitializeComponent();
        }

        private void frmClub_Load(object sender, EventArgs e)
        {
            loadListClub();
        }

        private void loadListClub()
        {

            logger.Info("loadListPoule: Chargement de la liste des poules.");

            dao.openBase();

            dgvClub.DataSource = dao.loadClub();
            // Resize the DataGridView columns to fit the newly loaded content.
            dgvClub.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dao.closeBase();
        }


        private void clearForm()
        {
            logger.Info("clearForm: Remise à blanc du formulaire.");

            tb_nom.Text = "";

            _selectedClubId = null;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            logger.Info("frmClub.btnOk_Click: Validation du formulaire.");

            Club club = new Club();

            if (_selectedClubId != null)
            {
                logger.Info("frmClub.btnOk_Click: L'identifiant est connu.");
                club = new Club(Convert.ToInt32(_selectedClubId), tb_nom.Text);
            }
            else
            {
                logger.Info("frmClub.btnOk_Click: L'identifiant n'est pas connu.");
                club = new Club(tb_nom.Text);
            }
            club.insert();
            _selectedClubId = null;

            // Mise à jour de la liste.
            loadListClub();

            clearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            logger.Info("frmClub.btnCancel_Click: Annulation du formulaire.");

            clearForm();
        }


        private void dgvClub_SelectionChanged(object sender, EventArgs e)
        {
            logger.Info("dgvClub_SelectionChanged: Changement de ligne.");
            foreach (DataGridViewRow row in dgvClub.SelectedRows)
            {
                _selectedClubId = row.Cells[0].Value;
            }
        }

        private void dgvClub_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            logger.Info("dgvClub_RowsRemoved: Suppression d'une ligne.");
            if (_selectedClubId != null)
            {
                int clubId = Convert.ToInt32(_selectedClubId);
                dao.deleteClub(clubId);
            }
        }

        private void dgvClub_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            logger.Info("dgvClub_CellDoubleClick: Sélection d'une ligne.");
            foreach (DataGridViewRow row in dgvClub.SelectedRows)
            {
                _selectedClubId = row.Cells[0].Value;
                tb_nom.Text = row.Cells[1].Value.ToString();
            }
        }


    }
}
