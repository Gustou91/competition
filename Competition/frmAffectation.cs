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
    public partial class frmAffectation : Form
    {

        private Dao dao = Dao.Instance;

        public frmAffectation()
        {
            InitializeComponent();
        }

        private void frmAffectation_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;

            loadPoules();

            lvMembre1.LargeImageList = ilIcon;
            lvMembre1.AllowDrop = true;

        }

        private void loadPoules()
        {
            dao.openBase();

            DataTable dtPoule = dao.loadPoules("ACTIVE");

            cbPoule1.DataSource = dtPoule;
            cbPoule1.DisplayMember = dtPoule.Columns[1].ToString();
            cbPoule1.ValueMember = dtPoule.Columns[0].ToString();

            dao.closeBase();
        }


        private void loadMembres(int pouleId)
        {
            List<Membre> lstMembres = dao.getMembres(pouleId);
            lvMembre1.Clear();

            foreach (Membre membre in lstMembres)
            {
                ListViewItem lviMembre = lvMembre1.Items.Add(membre.getPrenom() + " " + membre.getNom());
                lviMembre.ImageIndex = membre.getSexe() == "M" ? 0 : 1;
            }
        }


        private void cbPoule_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedValue = cbPoule1.SelectedValue;
            if (selectedValue.GetType().Equals(typeof(Int64)))
            {
                Int64 pouleId64 = (Int64)cbPoule1.SelectedValue;
                //int pouleId = (int)cbPoule.SelectedValue;
                int pouleId = (int)pouleId64;
                loadMembres(pouleId);
            }
        }


        #region Gestion du glisser-déplacer.
        private void lvMembre1_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem item = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
            if (item != null)
            {
                Point pt = this.lvMembre1.PointToClient(new Point(e.X,
                e.Y));
                ListViewItem hoveritem = this.lvMembre1.GetItemAt(pt.X, pt.Y);
            }
        }

        private void lvMembre1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.lvMembre1.DoDragDrop(this.lvMembre1.SelectedItems, DragDropEffects.Copy | DragDropEffects.Move);
            //MessageBox.Show("AllowDrop = " + lvMembre.AllowDrop.ToString());


        }

        private void lvMembre1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            
            //MessageBox.Show("AllowDrop = " + lvMembre.AllowDrop.ToString());

        }


        private void lvMembre2_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem item = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
            if (item != null)
            {
                Point pt = this.lvMembre2.PointToClient(new Point(e.X,
                e.Y));
                ListViewItem hoveritem = this.lvMembre2.GetItemAt(pt.X, pt.Y);
                lvMembre2.Items.Add(hoveritem);
            }

        }

        private void lvMembre2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.lvMembre2.DoDragDrop(this.lvMembre2.SelectedItems, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void lvMembre2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Copy;
            }

        }
        #endregion


    }
}
