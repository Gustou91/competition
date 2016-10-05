namespace Competition
{
    partial class frmAddCompet
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
            this.tbCompetName = new System.Windows.Forms.TextBox();
            this.bnAddCompet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbCompetName
            // 
            this.tbCompetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCompetName.Location = new System.Drawing.Point(8, 5);
            this.tbCompetName.Name = "tbCompetName";
            this.tbCompetName.Size = new System.Drawing.Size(524, 31);
            this.tbCompetName.TabIndex = 0;
            // 
            // bnAddCompet
            // 
            this.bnAddCompet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnAddCompet.Location = new System.Drawing.Point(538, 3);
            this.bnAddCompet.Name = "bnAddCompet";
            this.bnAddCompet.Size = new System.Drawing.Size(117, 34);
            this.bnAddCompet.TabIndex = 1;
            this.bnAddCompet.Text = "Valider";
            this.bnAddCompet.UseVisualStyleBackColor = true;
            this.bnAddCompet.Click += new System.EventHandler(this.bnAddCompet_Click);
            // 
            // frmAddCompet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 42);
            this.Controls.Add(this.bnAddCompet);
            this.Controls.Add(this.tbCompetName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddCompet";
            this.Text = "Nouvelle compétition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCompetName;
        private System.Windows.Forms.Button bnAddCompet;
    }
}