namespace Competition
{
    partial class frmPoule
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
            this.dgvPoule = new System.Windows.Forms.DataGridView();
            this.gbPoule = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tb_nom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoule)).BeginInit();
            this.gbPoule.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPoule
            // 
            this.dgvPoule.AllowUserToAddRows = false;
            this.dgvPoule.AllowUserToOrderColumns = true;
            this.dgvPoule.AllowUserToResizeColumns = false;
            this.dgvPoule.AllowUserToResizeRows = false;
            this.dgvPoule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoule.Location = new System.Drawing.Point(12, 107);
            this.dgvPoule.MultiSelect = false;
            this.dgvPoule.Name = "dgvPoule";
            this.dgvPoule.Size = new System.Drawing.Size(406, 331);
            this.dgvPoule.TabIndex = 0;
            this.dgvPoule.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPoule_CellDoubleClick);
            this.dgvPoule.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPoule_RowsRemoved);
            this.dgvPoule.SelectionChanged += new System.EventHandler(this.dgvPoule_SelectionChanged);
            // 
            // gbPoule
            // 
            this.gbPoule.Controls.Add(this.btnCancel);
            this.gbPoule.Controls.Add(this.btnOk);
            this.gbPoule.Controls.Add(this.tb_nom);
            this.gbPoule.Controls.Add(this.label1);
            this.gbPoule.Location = new System.Drawing.Point(12, 12);
            this.gbPoule.Name = "gbPoule";
            this.gbPoule.Size = new System.Drawing.Size(406, 89);
            this.gbPoule.TabIndex = 1;
            this.gbPoule.TabStop = false;
            this.gbPoule.Text = "Membre";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(244, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(325, 48);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Enregistrer";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tb_nom
            // 
            this.tb_nom.Location = new System.Drawing.Point(42, 17);
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
            // frmPoule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 450);
            this.Controls.Add(this.gbPoule);
            this.Controls.Add(this.dgvPoule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPoule";
            this.Text = "Gestion des poules";
            this.Load += new System.EventHandler(this.frmPoule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoule)).EndInit();
            this.gbPoule.ResumeLayout(false);
            this.gbPoule.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPoule;
        private System.Windows.Forms.GroupBox gbPoule;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tb_nom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;

    }
}