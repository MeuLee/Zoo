using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2
{
    public partial class ChoixAnimal : Form
    {
        public string selection;

        public ChoixAnimal()
        {
            InitializeComponent();
        }

        private void BtnLicorne_Click(object sender, EventArgs e)
        {
            selection = "Licorne";
            this.Close();
        }

        private void BtnMouton_Click(object sender, EventArgs e)
        {
            selection = "Mouton";
            this.Close();
        }
    }
}
