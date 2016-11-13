namespace Competition
{
    partial class frmParam
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
            this.dgvParam = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParam)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvParam
            // 
            this.dgvParam.AllowUserToAddRows = false;
            this.dgvParam.AllowUserToOrderColumns = true;
            this.dgvParam.AllowUserToResizeColumns = false;
            this.dgvParam.AllowUserToResizeRows = false;
            this.dgvParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParam.Location = new System.Drawing.Point(1, 2);
            this.dgvParam.MultiSelect = false;
            this.dgvParam.Name = "dgvParam";
            this.dgvParam.Size = new System.Drawing.Size(206, 256);
            this.dgvParam.TabIndex = 1;
            this.dgvParam.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParam_CellValidated);
            // 
            // frmParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 261);
            this.Controls.Add(this.dgvParam);
            this.Name = "frmParam";
            this.Text = "Gestion des paramètres";
            this.Load += new System.EventHandler(this.frmParam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvParam;
    }
}