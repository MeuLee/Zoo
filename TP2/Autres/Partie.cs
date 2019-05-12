using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2.Entités;

namespace TP2.LeReste
{
    class Partie
    {
        public Partie(Zoo zoo, FrmZoo instanceForm)
        {
            Zoo.ListeEntites.Add(new Heros());
            zoo.CreerEtLancerThreadAnimaux();
            instanceForm.TmrJour.Start();
            instanceForm.TmrMinute.Start();
        }
    }
}
