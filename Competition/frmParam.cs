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
    public partial class frmParam : Form
    {

        private Dao dao = Dao.Instance;
        private object _selectedParam;

        private static readonly ILog logger = LogManager.GetLogger(typeof(frm_main));

        public frmParam()
        {
            InitializeComponent();
        }

        private void frmParam_Load(object sender, EventArgs e)
        {
            loadListParam();
        }

        private void loadListParam()
        {

            logger.Info("loadListParam: Chargement de la liste des poules.");

            dao.openBase();

            dgvParam.DataSource = dao.dtLoadParam();
            // Resize the DataGridView columns to fit the newly loaded content.
            dgvParam.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dao.closeBase();
        }

        private void dgvParam_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dao.updateParam(dgvParam.CurrentRow.Cells[0].Value.ToString(), dgvParam.CurrentRow.Cells[1].Value.ToString());
        }
    }
}
