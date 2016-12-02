namespace Competition
{
    partial class frmMembre
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
            this.dgvMembre = new System.Windows.Forms.DataGridView();
            this.gbMembre = new System.Windows.Forms.GroupBox();
            this.btnAddClub = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cblstClub = new System.Windows.Forms.ComboBox();
            this.tb_prenom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbSexe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudPoids = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAge = new System.Windows.Forms.NumericUpDown();
            this.tb_nom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembre)).BeginInit();
            this.gbMembre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMembre
            // 
            this.dgvMembre.AllowUserToAddRows = false;
            this.dgvMembre.AllowUserToOrderColumns = true;
            this.dgvMembre.AllowUserToResizeColumns = false;
            this.dgvMembre.AllowUserToResizeRows = false;
            this.dgvMembre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembre.Location = new System.Drawing.Point(342, 19);
            this.dgvMembre.MultiSelect = false;
            this.dgvMembre.Name = "dgvMembre";
            this.dgvMembre.Size = new System.Drawing.Size(991, 479);
            this.dgvMembre.TabIndex = 0;
            this.dgvMembre.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembre_CellDoubleClick);
            this.dgvMembre.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembre_CellValidated);
            this.dgvMembre.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvMembre_RowsRemoved);
            this.dgvMembre.SelectionChanged += new System.EventHandler(this.dgvMembre_SelectionChanged);
            this.dgvMembre.SizeChanged += new System.EventHandler(this.dgvMembre_SizeChanged);
            // 
            // gbMembre
            // 
            this.gbMembre.Controls.Add(this.btnAddClub);
            this.gbMembre.Controls.Add(this.label4);
            this.gbMembre.Controls.Add(this.cblstClub);
            this.gbMembre.Controls.Add(this.tb_prenom);
            this.gbMembre.Controls.Add(this.label3);
            this.gbMembre.Controls.Add(this.btnCancel);
            this.gbMembre.Controls.Add(this.btnOk);
            this.gbMembre.Controls.Add(this.cbSexe);
            this.gbMembre.Controls.Add(this.label5);
            this.gbMembre.Controls.Add(this.nudPoids);
            this.gbMembre.Controls.Add(this.label2);
            this.gbMembre.Controls.Add(this.nudAge);
            this.gbMembre.Controls.Add(this.tb_nom);
            this.gbMembre.Controls.Add(this.label1);
            this.gbMembre.Location = new System.Drawing.Point(12, 12);
            this.gbMembre.Name = "gbMembre";
            this.gbMembre.Size = new System.Drawing.Size(322, 238);
            this.gbMembre.TabIndex = 1;
            this.gbMembre.TabStop = false;
            this.gbMembre.Text = "Membre";
            // 
            // btnAddClub
            // 
            this.btnAddClub.Location = new System.Drawing.Point(291, 158);
            this.btnAddClub.Name = "btnAddClub";
            this.btnAddClub.Size = new System.Drawing.Size(21, 23);
            this.btnAddClub.TabIndex = 17;
            this.btnAddClub.Text = "+";
            this.btnAddClub.UseVisualStyleBackColor = true;
            this.btnAddClub.Click += new System.EventHandler(this.btnAddClub_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Club";
            // 
            // cblstClub
            // 
            this.cblstClub.FormattingEnabled = true;
            this.cblstClub.Location = new System.Drawing.Point(65, 158);
            this.cblstClub.Name = "cblstClub";
            this.cblstClub.Size = new System.Drawing.Size(220, 21);
            this.cblstClub.TabIndex = 15;
            // 
            // tb_prenom
            // 
            this.tb_prenom.Location = new System.Drawing.Point(65, 43);
            this.tb_prenom.Name = "tb_prenom";
            this.tb_prenom.Size = new System.Drawing.Size(220, 20);
            this.tb_prenom.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Prénom";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(84, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(165, 204);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Enregistrer";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbSexe
            // 
            this.cbSexe.FormattingEnabled = true;
            this.cbSexe.Items.AddRange(new object[] {
            "Garçon",
            "Fille"});
            this.cbSexe.Location = new System.Drawing.Point(65, 128);
            this.cbSexe.Name = "cbSexe";
            this.cbSexe.Size = new System.Drawing.Size(121, 21);
            this.cbSexe.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Poids min";
            // 
            // nudPoids
            // 
            this.nudPoids.Location = new System.Drawing.Point(65, 99);
            this.nudPoids.Name = "nudPoids";
            this.nudPoids.Size = new System.Drawing.Size(51, 20);
            this.nudPoids.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Age";
            // 
            // nudAge
            // 
            this.nudAge.Location = new System.Drawing.Point(65, 69);
            this.nudAge.Name = "nudAge";
            this.nudAge.Size = new System.Drawing.Size(51, 20);
            this.nudAge.TabIndex = 2;
            // 
            // tb_nom
            // 
            this.tb_nom.Location = new System.Drawing.Point(65, 17);
            this.tb_nom.Name = "tb_nom";
            this.tb_nom.Size = new System.Drawing.Size(220, 20);
            this.tb_nom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Competition.Properties.Resources.LogoPetit;
            this.pictureBox1.Location = new System.Drawing.Point(12, 256);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 235);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmMembre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 503);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbMembre);
            this.Controls.Add(this.dgvMembre);
            this.Name = "frmMembre";
            this.Text = "Gestion des membres";
            this.Load += new System.EventHandler(this.frmMembre_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMembre_ResizeEnd);
            this.ClientSizeChanged += new System.EventHandler(this.frmMembre_ClientSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembre)).EndInit();
            this.gbMembre.ResumeLayout(false);
            this.gbMembre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMembre;
        private System.Windows.Forms.GroupBox gbMembre;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cbSexe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudPoids;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudAge;
        private System.Windows.Forms.TextBox tb_nom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tb_prenom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cblstClub;
        private System.Windows.Forms.Button btnAddClub;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}