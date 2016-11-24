﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using log4net;
using log4net.Config;

namespace Competition
{
    public partial class frm_main : Form
    {

        Dao dao = Dao.Instance;

        Dictionary<string, string> lstParam;

        private static readonly ILog logger = LogManager.GetLogger(typeof(frm_main));
       

        public frm_main()
        {
            InitializeComponent();

            Logger.Setup();
            logger.Info("Démarrage de l'application.");

            lstParam = dao.loadParam();

        }




        private void gérerLesCompétitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCompet frm = new frmAddCompet();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gérerLesCatégoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCateg frm = new frmCateg();
            frm.MdiParent = this;
            frm.Show();
        }

        private void inscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMembre frm = new frmMembre();
            frm.MdiParent = this;
            frm.Show();

        }

        private void gérerLesPoulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPoule frm = new frmPoule();
            frm.MdiParent = this;
            frm.Show();
        }

        private void créerLesPoulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Récupération de la liste des membres.
            List<Membre> lstMembres = dao.getMembres();
            string lstDone = "";

            // Boucle sur les membres.
            foreach (Membre membre in lstMembres)
            {
                // Récupération de tous les membres compatibles avec la poule.
                List<Membre> lstMembresPoule = dao.getMembres(membre.getSexe(), membre.getAge(), membre.getPoids(), 
                    int.Parse(lstParam["AGE-DELTA"]), int.Parse(lstParam["POIDS-DELTA"]), lstDone);

                int nbMembres = 0;
                Poule poule = new Poule();
                int noPoule = 1;
                foreach (Membre membreOk in lstMembresPoule)
                {
                    logger.Info("créerLesPoulesToolStripMenuItem_Click: nbMembres = " + nbMembres.ToString());
                    if (nbMembres % 4 == 0)
                    {
                        // Création de la nouvelle poule.
                        char lettrePoule = (char) (64 + noPoule);
                        string nomPoule = membreOk.getSexe() + "-" + membreOk.getAge().ToString() + "-" + membreOk.getPoids().ToString() + "-" + lettrePoule;
                        noPoule ++;
                        logger.Info("créerLesPoulesToolStripMenuItem_Click: Création de la poule " + nomPoule);
                        poule = new Poule(nomPoule);
                        poule.insert();
                    }

                    // Affectation du membre à la poule.
                    logger.Info("créerLesPoulesToolStripMenuItem_Click: Affectation du membre " 
                                + membreOk.getId() + " - " + membreOk.getPrenom() + " " + membreOk.getNom() 
                                + " à la poule " + poule.getId());
                    dao.updatePouleMembre(membreOk.getId(), poule.getId());

                    // Mémorisation des id traités.
                    lstDone = lstDone + membreOk.getId() + ",";

                    nbMembres++;
                }

            }
        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParam frm = new frmParam();
            frm.MdiParent = this;
            frm.Show();
        }

        private void affectationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAffectation frm = new frmAffectation();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clubsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClub frm = new frmClub();
            frm.MdiParent = this;
            frm.Show();
        }

        private void réinitialiserLesPoulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Attention, cette action va supprimer toutes les poules. Souhaitez-vous continuer?",
                "Réinitialisation des poules",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dao.deletePoule();
            }
        }

        private void frm_main_Load(object sender, EventArgs e)
        {

            
        }

    }
}
