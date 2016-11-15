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
            this.cbPoule = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvMembre = new System.Windows.Forms.ListView();
            this.ilIcon = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // cbPoule
            // 
            this.cbPoule.FormattingEnabled = true;
            this.cbPoule.Location = new System.Drawing.Point(53, 9);
            this.cbPoule.Name = "cbPoule";
            this.cbPoule.Size = new System.Drawing.Size(113, 21);
            this.cbPoule.TabIndex = 0;
            this.cbPoule.SelectedIndexChanged += new System.EventHandler(this.cbPoule_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Poule";
            // 
            // lvMembre
            // 
            this.lvMembre.Location = new System.Drawing.Point(16, 47);
            this.lvMembre.Name = "lvMembre";
            this.lvMembre.Size = new System.Drawing.Size(547, 182);
            this.lvMembre.TabIndex = 2;
            this.lvMembre.UseCompatibleStateImageBehavior = false;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 241);
            this.Controls.Add(this.lvMembre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPoule);
            this.Name = "frmAffectation";
            this.Text = "Gestion des affectations";
            this.Load += new System.EventHandler(this.frmAffectation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPoule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvMembre;
        private System.Windows.Forms.ImageList ilIcon;
    }
}