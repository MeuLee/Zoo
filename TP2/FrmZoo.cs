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
            _date = DateTime.Now;
        }

        private void FrmZoo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
            {
                Zoo.Heros.DeplacerEtModifierImage(e.KeyCode);
                zoo1.Refresh();
            }
        }

        private void BtnNouvellePartie_Click(object sender, EventArgs e)
        {
            new Partie(zoo1, this);

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Ajoute un jour et re-set le texte des labels
        /// </summary>
        private void TmrTemps_Tick(object sender, EventArgs e)
        {
            AjusterLblDate();
            LblArgent.Text = Zoo.Heros.Argent.ToString() + "$";
            AjusterLblAnimaux();
            AjusterLblDechets();
        }

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

        private void AjusterLblDate()
        {
            _date = _date.AddDays(1);
            LblJour.Text = _date.ToLongDateString();
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

        private void TmrMinute_Tick(object sender, EventArgs e)
        {
            Zoo.Heros.AjouterArgentSelonAnimauxEtDechets();
        }
    }
}
