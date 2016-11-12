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
    public partial class frmPoule : Form
    {

        private Dao dao = Dao.Instance;
        private object _selectedPouleId;


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
            dao.openBase();

            dgvPoule.DataSource = dao.loadPoules();
            // Resize the DataGridView columns to fit the newly loaded content.
            dgvPoule.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dao.closeBase();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            Poule poule = new Poule();

            if (_selectedPouleId != null)
            {
                poule = new Poule(Convert.ToInt32(_selectedPouleId), tb_nom.Text);
            }
            else
            {
                poule = new Poule(tb_nom.Text);
            }
            poule.insert();

            // Mise à jour de la liste.
            loadListPoule();
        }


        private void dgvPoule_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPoule.SelectedRows)
            {
                _selectedPouleId = row.Cells[0].Value;
            }
        }

        private void dgvPoule_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_selectedPouleId != null)
            {
                int pouleId = Convert.ToInt32(_selectedPouleId);
                dao.deletePoule(pouleId);
            }
        }

        private void dgvPoule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPoule.SelectedRows)
            {
                _selectedPouleId = row.Cells[0].Value;
                tb_nom.Text = row.Cells[1].Value.ToString();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            _selectedPouleId = null;
            tb_nom.Text = "";
        }

    }
}
