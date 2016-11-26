using System;
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
        Dictionary<string, int> lstNomsPoules = new Dictionary<string, int>();

        private static readonly ILog logger = LogManager.GetLogger(typeof(frm_main));
       

        public frm_main()
        {
            InitializeComponent();

            Logger.Setup();
            logger.Info("======> Démarrage de l'application.");

            lstParam = dao.loadParam();

        }

        private void frm_main_Load(object sender, EventArgs e)
        {


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

            creerPoules();
            MessageBox.Show("Affectation terminée", "Affectation des membres", MessageBoxButtons.OK);
        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParam frm = new frmParam();
            //frm.MdiParent = this;
            frm.ShowDialog();

            lstParam.Clear();
            lstParam = dao.loadParam();
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


        // Création des poules.
        private void creerPoules()
        {
            logger.Info("creerPoules: Chargement de la liste des membres");
            List<Membre> lstMembres = dao.getMembres();

            int deltaPoid = int.Parse(lstParam["POIDS-DELTA"]);
            int pouleDim = int.Parse(lstParam["POULE-DIM"]);
            bool pouleCreated = true;

            logger.Info("creerPoules: Gigue poids: " + deltaPoid.ToString());
            logger.Info("creerPoules: Nombre de membre(s) à affecter: " + lstMembres.Count.ToString());

            // Tant qu'il y a des membres à caser.
            while (lstMembres.Count > 0 && pouleCreated)
            {

                pouleCreated = false;

                // Création de la liste des membres de la poule.
                List<Membre> lstMembrePoule = new List<Membre>();

                string lstClub = String.Empty;
                string lastSexe = "";
                int lastPoids = -1;
                int noMembre = 1;

                logger.Info("creerPoules: Nombre de membre(s) à affecter: " + lstMembres.Count.ToString());

                foreach (Membre membre in lstMembres)
                {

                    if (lastPoids == -1)
                    {
                        #region Premier membre de la poule.
                        logger.Info("creerPoules: Ajout du premier membre " + membre.getPrenom() + " " + membre.getNom() 
                            + " club = " + membre.getClub().ToString() + "(" + membre.getPoids().ToString() + " kg)");

                        // C'est le premier membre de la poule, on l'ajoute.                    
                        lstClub = lstClub + membre.getClub().ToString() + "/";
                        lstMembrePoule.Add(membre);

                        // Mémorisation des caractéristiques de référence de la poule.
                        lastPoids = membre.getPoids();
                        lastSexe = membre.getSexe();
                        #endregion
                    }
                    else
                    {
                        // Est-ce que le membre peut être ajouté à la poule courante?
                        // Conditions:
                        //    - Même sexe.
                        //    - Le poids dans la fourchette.
                        //    - Le club est différent.
                        if (membre.getSexe() == lastSexe
                            && membre.getPoids() >= lastPoids - deltaPoid && membre.getPoids() <= lastPoids + deltaPoid
                            && lstClub.IndexOf(membre.getClub().ToString()) == -1)
                        {
                            #region Nouveau membre de la poule.
                            // Ajout du membre.
                            logger.Info("creerPoules: Membre " + membre.getPrenom() + " " + membre.getNom()
                                + " club = " + membre.getClub().ToString() + "(" + membre.getPoids().ToString() + " kg) - OK.");
                            lstMembrePoule.Add(membre);
                            lstClub = lstClub + membre.getClub().ToString() + "/";
                            #endregion
                        }
                        else
                        {
                            logger.Info("creerPoules: Membre " + membre.getPrenom() + " " + membre.getNom()
                                + " club = " + membre.getClub().ToString() + "(" + membre.getPoids().ToString() + " kg) - HS.");

                        }
                    }

                    #region Création de la poule.
                    // A-t'on assez de membres pour la poule?
                    if (lstMembrePoule.Count == pouleDim || noMembre >= lstMembres.Count)
                    { 
                        // Création de la poule.
                        int pouleId = createPoule(lastSexe, lastPoids);
                        
                        // Ajout des membres.
                        foreach (Membre membreOk in lstMembrePoule)
                        {
                            dao.updatePouleMembre(membreOk.getId(), pouleId);

                            // Retrait de la liste des membres pour ne pas le traiter plusieurs fois.
                            lstMembres.Remove(membreOk);

                        }

                        // Nettoyage de la liste des membres de la poule.
                        lstMembrePoule.Clear();

                        // Sortie de boucle et on recommence.
                        pouleCreated = true;
                        break;
                    }
                    #endregion

                    noMembre ++;
                }

            }

        }


        // Création d'une poule.
        private int createPoule(string sexe, int poids)
        {

            // Création du nom de la poule.
            string nomPoule = sexe + "-" + poids;
            int noPoule = 1;

            if (lstNomsPoules.ContainsKey(nomPoule))
            {
                // La racine du nom existe. On incrémente.
                noPoule = lstNomsPoules[nomPoule];
                lstNomsPoules[nomPoule]++;
            }
            else
            {
                // La racine du nom n'existe pas. On l'ajoute.
                lstNomsPoules.Add(nomPoule, 1);
            }

            char lettrePoule = (char)(64 + noPoule);
            nomPoule = nomPoule + "-" + lettrePoule;


            // Création de la nouvelle poule.
            logger.Info("createPoule: Création de la poule " + nomPoule);
            Poule poule = new Poule(nomPoule);
            poule.insert();

            return poule.getId();
        }
    }
}
