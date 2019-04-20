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
            //pour tester avec les animaux, sera à changer plus tard
            for (int i = 0; i < 3; i++)
            {
                Animal a = new Animal(Animal.TypeAnimal.Grizzly, Zoo.ListeEnclos[0]);
            }
            zoo.CreerEtLancerThreadAnimaux();
        }

        
    }
}
