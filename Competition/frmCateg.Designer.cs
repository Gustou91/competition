namespace Competition
{
    partial class frmCateg
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
            this.dgvCateg = new System.Windows.Forms.DataGridView();
            this.gbCateg = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_nom = new System.Windows.Forms.TextBox();
            this.nudAgeMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAgeMax = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudPoidsMax = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudPoidsMin = new System.Windows.Forms.NumericUpDown();
            this.cbSexe = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCateg)).BeginInit();
            this.gbCateg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoidsMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoidsMin)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCateg
            // 
            this.dgvCateg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCateg.Location = new System.Drawing.Point(12, 140);
            this.dgvCateg.Name = "dgvCateg";
            this.dgvCateg.Size = new System.Drawing.Size(795, 189);
            this.dgvCateg.TabIndex = 0;
            // 
            // gbCateg
            // 
            this.gbCateg.Controls.Add(this.btnOk);
            this.gbCateg.Controls.Add(this.cbSexe);
            this.gbCateg.Controls.Add(this.label4);
            this.gbCateg.Controls.Add(this.nudPoidsMax);
            this.gbCateg.Controls.Add(this.label5);
            this.gbCateg.Controls.Add(this.nudPoidsMin);
            this.gbCateg.Controls.Add(this.label3);
            this.gbCateg.Controls.Add(this.nudAgeMax);
            this.gbCateg.Controls.Add(this.label2);
            this.gbCateg.Controls.Add(this.nudAgeMin);
            this.gbCateg.Controls.Add(this.tb_nom);
            this.gbCateg.Controls.Add(this.label1);
            this.gbCateg.Location = new System.Drawing.Point(12, 12);
            this.gbCateg.Name = "gbCateg";
            this.gbCateg.Size = new System.Drawing.Size(795, 122);
            this.gbCateg.TabIndex = 1;
            this.gbCateg.TabStop = false;
            this.gbCateg.Text = "Caégorie";
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
            // tb_nom
            // 
            this.tb_nom.Location = new System.Drawing.Point(42, 17);
            this.tb_nom.Name = "tb_nom";
            this.tb_nom.Size = new System.Drawing.Size(220, 20);
            this.tb_nom.TabIndex = 1;
            // 
            // nudAgeMin
            // 
            this.nudAgeMin.Location = new System.Drawing.Point(338, 17);
            this.nudAgeMin.Name = "nudAgeMin";
            this.nudAgeMin.Size = new System.Drawing.Size(51, 20);
            this.nudAgeMin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Age min";
            // 
            // nudAgeMax
            // 
            this.nudAgeMax.Location = new System.Drawing.Point(466, 17);
            this.nudAgeMax.Name = "nudAgeMax";
            this.nudAgeMax.Size = new System.Drawing.Size(51, 20);
            this.nudAgeMax.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Age max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Poids max";
            // 
            // nudPoidsMax
            // 
            this.nudPoidsMax.Location = new System.Drawing.Point(465, 51);
            this.nudPoidsMax.Name = "nudPoidsMax";
            this.nudPoidsMax.Size = new System.Drawing.Size(51, 20);
            this.nudPoidsMax.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Poids min";
            // 
            // nudPoidsMin
            // 
            this.nudPoidsMin.Location = new System.Drawing.Point(337, 51);
            this.nudPoidsMin.Name = "nudPoidsMin";
            this.nudPoidsMin.Size = new System.Drawing.Size(51, 20);
            this.nudPoidsMin.TabIndex = 6;
            // 
            // cbSexe
            // 
            this.cbSexe.FormattingEnabled = true;
            this.cbSexe.Items.AddRange(new object[] {
            "Garçon",
            "Fille"});
            this.cbSexe.Location = new System.Drawing.Point(557, 20);
            this.cbSexe.Name = "cbSexe";
            this.cbSexe.Size = new System.Drawing.Size(121, 21);
            this.cbSexe.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(644, 87);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Enregistrer";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmCateg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 341);
            this.Controls.Add(this.gbCateg);
            this.Controls.Add(this.dgvCateg);
            this.Name = "frmCateg";
            this.Text = "Gestion des catégories";
            this.Load += new System.EventHandler(this.frmCateg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCateg)).EndInit();
            this.gbCateg.ResumeLayout(false);
            this.gbCateg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoidsMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoidsMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCateg;
        private System.Windows.Forms.GroupBox gbCateg;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cbSexe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPoidsMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudPoidsMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAgeMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudAgeMin;
        private System.Windows.Forms.TextBox tb_nom;
        private System.Windows.Forms.Label label1;

    }
}