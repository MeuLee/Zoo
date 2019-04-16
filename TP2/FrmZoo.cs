using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2.Entités;
using TP2.LeReste;

namespace TP2
{
    public partial class FrmZoo : Form
    {
        public FrmZoo()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void FrmZoo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
                Zoo.Heros.DeplacerEtModifierImage(e.KeyCode);

            zoo1.Refresh();
        }
    }
}
