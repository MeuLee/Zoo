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
        private DateTime _date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

        public FrmZoo()
        {
            InitializeComponent();
            TmrTemps.Stop();
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
            BtnNouvellePartie.Hide();
        }
    
        /// <summary>
        /// Ajoute un jour et re-set le texte du label
        /// </summary>
        private void TmrTemps_Tick(object sender, EventArgs e)
        {
            _date = _date.AddDays(1);
            LblDate.Text = _date.ToLongDateString();
        }

        private void FrmZoo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            string argentObtenu = (Zoo.Heros == null ? 0 : Zoo.Heros.Argent).ToString() + "$", 
                   titre = "Merci de votre séjour avec nous!";
            MessageBox.Show("Vous avez obtenu " + argentObtenu + " lors de votre visite.\nÀ la prochaine!", titre);
        }
    }
}

