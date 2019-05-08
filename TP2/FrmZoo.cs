using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using TP2.Entités;
using TP2.LeReste;

namespace TP2
{
    public partial class FrmZoo : Form
    {
        private DateTime _date = new DateTime();

        public FrmZoo()
        {
            InitializeComponent();
            TmrTemps.Stop();
            TmrMinute.Stop();
            _date = DateTime.Now;
        }

        #region Events
        /// <summary>
        /// Déplace le héros (si possible) dans la direction précisée
        /// </summary>
        private void FrmZoo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
            {
                Zoo.Heros.DeplacerEtModifierImage(e.KeyCode);
                zoo1.Refresh();
            }
        }

        /// <summary>
        /// Crée une partie
        /// </summary>
        private void MnuNouvellePartie_Click(object sender, EventArgs e)
        {
            new Partie(zoo1, this);
        }

        /// <summary>
        /// Ferme l'application
        /// </summary>
        private void MnuQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Affiche l'argent du Héros et ferme l'application (même si le code ne raconte pas ça)
        /// </summary>
        private void FrmZoo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            string argentObtenu = (Zoo.Heros == null ? 0 : Zoo.Heros.Argent).ToString() + "$",
                   titre = "Merci de votre séjour avec nous!";
            MessageBox.Show("Vous avez obtenu " + argentObtenu + " lors de votre visite.\nÀ la prochaine!", titre);
        }
        #endregion

        #region Timer 822
        /// <summary>
        /// Modifie les labels de la form
        /// </summary>
        private void TmrTemps_Tick(object sender, EventArgs e)
        {
            AjusterLblDate();
            LblArgent.Text = Zoo.Heros.Argent.ToString() + "$";
            AjusterLblAnimaux();
            AjusterLblDechets();
        }

        /// <summary>
        /// Modifie LblDechets selon le nombre de déchets présents
        /// </summary>
        private void AjusterLblDechets()
        {
            int nbDechets = Zoo.ListeEntites.OfType<Dechet>().Count();
            switch (nbDechets)
            {
                case 0:
                    LblDechets.Text = "Aucun déchet";
                    break;
                case 1:
                    LblDechets.Text = nbDechets + " déchet";
                    break;
                default:
                    LblDechets.Text = nbDechets + " déchets";
                    break;
            }
        }

        /// <summary>
        /// Modifie LblAnimaux selon le nombre d'animaux présents
        /// </summary>
        private void AjusterLblAnimaux()
        {
            int nbAnimaux = Zoo.ListeEntites.OfType<Animal>().Count();
            switch (nbAnimaux)
            {
                case 0:
                    LblAnimaux.Text = "Aucun animal";
                    break;
                case 1:
                    LblAnimaux.Text = nbAnimaux + " animal";
                    break;
                default:
                    LblAnimaux.Text = nbAnimaux + " animaux";
                    break;
            }
        }

        /// <summary>
        /// Ajoute un jour à la date et modifie LblJour en fonction
        /// </summary>
        private void AjusterLblDate()
        {
            _date = _date.AddDays(1);
            LblJour.Text = _date.ToLongDateString();
        }
        #endregion

        #region Timer 60000
        /// <summary>
        /// À chaque minute, ajoute 1$ par visiteur par (animal -10c par déchet)
        /// Enlève 2$ par concierge
        /// </summary>
        private void TmrMinute_Tick(object sender, EventArgs e)
        {
            Zoo.Heros.AjouterArgentSelonAnimauxEtDechets();
            Zoo.Heros.RetirerArgentSelonConcierges();
        }
        #endregion
    }
}
