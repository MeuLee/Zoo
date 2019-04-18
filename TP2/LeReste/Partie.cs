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
        public Partie(Zoo zoo)
        {
            Animal a = new Animal(Animal.TypeAnimal.Grizzly, Zoo.ListeEnclos[3]);
            Animal b = new Animal(Animal.TypeAnimal.Grizzly, Zoo.ListeEnclos[3]);
            zoo.CreerEtLancerThreadAnimaux();
        }

        
    }
}
