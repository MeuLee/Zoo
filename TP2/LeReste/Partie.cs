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
            Zoo.ListeEntites.Add(new Heros());
            zoo.CreerEtLancerThreadAnimaux();
            for (int i = 0; i < 3; i++)
            {
                new Animal(Animal.TypeAnimal.Grizzly);
                new Animal(Animal.TypeAnimal.Lion);
                new Concierge();
            }
        }

        
    }
}
