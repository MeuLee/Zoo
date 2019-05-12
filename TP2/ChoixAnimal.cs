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

namespace TP2
{
    public partial class ChoixAnimal : Form
    {
        public Animal.TypeAnimal Selection;

        public ChoixAnimal()
        {
            InitializeComponent();
        }

        private void BtnLicorne_Click(object sender, EventArgs e)
        {
            Selection = Animal.TypeAnimal.Licorne;
            this.Close();
        }

        private void BtnMouton_Click(object sender, EventArgs e)
        {
            Selection = Animal.TypeAnimal.Mouton;
            this.Close();
        }
    }
}
