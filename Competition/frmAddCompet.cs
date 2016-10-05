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
    public partial class frmAddCompet : Form
    {

        private Dao dao = Dao.Instance;

        public frmAddCompet()
        {
            InitializeComponent();
        }

        private void bnAddCompet_Click(object sender, EventArgs e)
        {

            string activeCompetname = dao.existsActiveCompetition();
            DialogResult response = DialogResult.No;

            if (activeCompetname != String.Empty)
            {
                // Il y a déjà une compétition active. Demande de confirmation.
                response = MessageBox.Show("Il y a déjà une compétition active (" + activeCompetname 
                    + "). Pour ajouter et activer la nouvelle compétition, cliquez sur Oui. "
                    + "Pour abandonner et conserver la compétion courante active, cliquez sur Non", "Attention", MessageBoxButtons.YesNo);
            }

            if (activeCompetname == String.Empty || response == DialogResult.Yes )
            {
                // S'il n'y a pas de compétition active ou que l'utilisateur a confirmé la nouvelle.
                Competition compet = new Competition(tbCompetName.Text);
                compet.insert();
            }
            this.Close();
        }
    }
}
