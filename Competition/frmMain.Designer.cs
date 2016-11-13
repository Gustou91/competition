namespace Competition
{
    partial class frm_main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.competitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gérerLesCompétitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créerLesPoulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gérerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gérerLesPoulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.résultatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableauDeBordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.competitionToolStripMenuItem,
            this.gérerToolStripMenuItem,
            this.résultatsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1204, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            // 
            // competitionToolStripMenuItem
            // 
            this.competitionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gérerLesCompétitionsToolStripMenuItem,
            this.inscriptionToolStripMenuItem,
            this.créerLesPoulesToolStripMenuItem});
            this.competitionToolStripMenuItem.Name = "competitionToolStripMenuItem";
            this.competitionToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.competitionToolStripMenuItem.Text = "Competition";
            // 
            // gérerLesCompétitionsToolStripMenuItem
            // 
            this.gérerLesCompétitionsToolStripMenuItem.Name = "gérerLesCompétitionsToolStripMenuItem";
            this.gérerLesCompétitionsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.gérerLesCompétitionsToolStripMenuItem.Text = "Nouvelle compétition";
            this.gérerLesCompétitionsToolStripMenuItem.Click += new System.EventHandler(this.gérerLesCompétitionsToolStripMenuItem_Click);
            // 
            // inscriptionToolStripMenuItem
            // 
            this.inscriptionToolStripMenuItem.Name = "inscriptionToolStripMenuItem";
            this.inscriptionToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.inscriptionToolStripMenuItem.Text = "Inscription";
            this.inscriptionToolStripMenuItem.Click += new System.EventHandler(this.inscriptionToolStripMenuItem_Click);
            // 
            // créerLesPoulesToolStripMenuItem
            // 
            this.créerLesPoulesToolStripMenuItem.Name = "créerLesPoulesToolStripMenuItem";
            this.créerLesPoulesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.créerLesPoulesToolStripMenuItem.Text = "Répartir dans les poules";
            this.créerLesPoulesToolStripMenuItem.Click += new System.EventHandler(this.créerLesPoulesToolStripMenuItem_Click);
            // 
            // gérerToolStripMenuItem
            // 
            this.gérerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gérerLesPoulesToolStripMenuItem,
            this.paramètresToolStripMenuItem});
            this.gérerToolStripMenuItem.Name = "gérerToolStripMenuItem";
            this.gérerToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.gérerToolStripMenuItem.Text = "Gérer";
            // 
            // gérerLesPoulesToolStripMenuItem
            // 
            this.gérerLesPoulesToolStripMenuItem.Name = "gérerLesPoulesToolStripMenuItem";
            this.gérerLesPoulesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.gérerLesPoulesToolStripMenuItem.Text = "Gérer les poules";
            this.gérerLesPoulesToolStripMenuItem.Click += new System.EventHandler(this.gérerLesPoulesToolStripMenuItem_Click);
            // 
            // résultatsToolStripMenuItem
            // 
            this.résultatsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableauDeBordToolStripMenuItem});
            this.résultatsToolStripMenuItem.Name = "résultatsToolStripMenuItem";
            this.résultatsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.résultatsToolStripMenuItem.Text = "Résultats";
            // 
            // tableauDeBordToolStripMenuItem
            // 
            this.tableauDeBordToolStripMenuItem.Name = "tableauDeBordToolStripMenuItem";
            this.tableauDeBordToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.tableauDeBordToolStripMenuItem.Text = "Tableau de bord";
            // 
            // paramètresToolStripMenuItem
            // 
            this.paramètresToolStripMenuItem.Name = "paramètresToolStripMenuItem";
            this.paramètresToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.paramètresToolStripMenuItem.Text = "Paramètres";
            this.paramètresToolStripMenuItem.Click += new System.EventHandler(this.paramètresToolStripMenuItem_Click);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 481);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_main";
            this.Text = "USM - JU JIT SO: Gestion des compétitions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem competitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gérerLesCompétitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem créerLesPoulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem résultatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableauDeBordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gérerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gérerLesPoulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramètresToolStripMenuItem;
    }
}

