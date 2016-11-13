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
    public partial class frmPoule : Form
    {

        private Dao dao = Dao.Instance;
        private object _selectedPouleId;

        private static readonly ILog logger = LogManager.GetLogger(typeof(frm_main));


        public frmPoule()
        {
            InitializeComponent();
        }


        private void frmPoule_Load(object sender, EventArgs e)
        {
            loadListPoule();
        }

        private void loadListPoule()
        {

            logger.Info("loadListPoule: Chargement de la liste des poules.");

            dao.openBase();

            dgvPoule.DataSource = dao.loadPoules();
            // Resize the DataGridView columns to fit the newly loaded content.
            dgvPoule.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dao.closeBase();
        }



        private void clearForm()
        {
            logger.Info("clearForm: Remise à blanc du formulaire.");

            tb_nom.Text = "";

            _selectedPouleId = null;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            logger.Info("frmPoule.btnOk_Click: Validation du formulaire.");

            Poule poule = new Poule();

            if (_selectedPouleId != null)
            {
                logger.Info("frmPoule.btnOk_Click: L'identifiant est connu.");
                poule = new Poule(Convert.ToInt32(_selectedPouleId), tb_nom.Text);
            }
            else
            {
                logger.Info("frmPoule.btnOk_Click: L'identifiant n'est pas connu.");
                poule = new Poule(tb_nom.Text);
            }
            poule.insert();
            _selectedPouleId = null;

            // Mise à jour de la liste.
            loadListPoule();

            clearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            logger.Info("frmPoule.btnCancel_Click: Annulation du formulaire.");

            clearForm();
        }


        private void dgvPoule_SelectionChanged(object sender, EventArgs e)
        {
            logger.Info("dgvPoule_SelectionChanged: Changement de ligne.");
            foreach (DataGridViewRow row in dgvPoule.SelectedRows)
            {
                _selectedPouleId = row.Cells[0].Value;
            }
        }

        private void dgvPoule_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            logger.Info("dgvPoule_RowsRemoved: Suppression d'une ligne.");
            if (_selectedPouleId != null)
            {
                int pouleId = Convert.ToInt32(_selectedPouleId);
                dao.deletePoule(pouleId);
            }
        }

        private void dgvPoule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            logger.Info("dgvPoule_CellDoubleClick: Sélection d'une ligne.");
            foreach (DataGridViewRow row in dgvPoule.SelectedRows)
            {
                _selectedPouleId = row.Cells[0].Value;
                tb_nom.Text = row.Cells[1].Value.ToString();
            }
        }


    }
}
