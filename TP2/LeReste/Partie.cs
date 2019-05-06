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
            for (int i = 0; i < 3; i++)
            {
                new Animal(Animal.TypeAnimal.Grizzly);
                new Animal(Animal.TypeAnimal.Lion);
                new Animal(Animal.TypeAnimal.Licorne, Zoo.ListeEnclos[0]);
                new Animal(Animal.TypeAnimal.Mouton, Zoo.ListeEnclos[1]);
                new Concierge();
            }
            zoo.CreerEtLancerThreadAnimaux();
            instanceForm.TmrTemps.Start();
        }

        
    }
}
