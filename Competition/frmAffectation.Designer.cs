namespace Competition
{
    partial class frmAffectation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAffectation));
            this.cbPoule1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvMembre1 = new System.Windows.Forms.ListView();
            this.ilIcon = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // cbPoule1
            // 
            this.cbPoule1.FormattingEnabled = true;
            this.cbPoule1.Location = new System.Drawing.Point(57, 9);
            this.cbPoule1.Name = "cbPoule1";
            this.cbPoule1.Size = new System.Drawing.Size(113, 21);
            this.cbPoule1.TabIndex = 0;
            this.cbPoule1.SelectedIndexChanged += new System.EventHandler(this.cbPoule_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Poule 1";
            // 
            // lvMembre1
            // 
            this.lvMembre1.AllowDrop = true;
            this.lvMembre1.Location = new System.Drawing.Point(16, 47);
            this.lvMembre1.Name = "lvMembre1";
            this.lvMembre1.Size = new System.Drawing.Size(547, 182);
            this.lvMembre1.TabIndex = 2;
            this.lvMembre1.UseCompatibleStateImageBehavior = false;
            this.lvMembre1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvMembre1_ItemDrag);
            this.lvMembre1.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvMembre1_DragDrop);
            this.lvMembre1.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvMembre1_DragEnter);
            // 
            // ilIcon
            // 
            this.ilIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcon.ImageStream")));
            this.ilIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.ilIcon.Images.SetKeyName(0, "Garçon.png");
            this.ilIcon.Images.SetKeyName(1, "Fille.png");
            // 
            // frmAffectation
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 241);
            this.Controls.Add(this.lvMembre1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPoule1);
            this.Name = "frmAffectation";
            this.Text = "Gestion des affectations";
            this.Load += new System.EventHandler(this.frmAffectation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPoule1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvMembre1;
        private System.Windows.Forms.ImageList ilIcon;
    }
}