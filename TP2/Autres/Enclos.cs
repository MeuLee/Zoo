using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Entités;

namespace TP2.LeReste
{
    /// <summary>
    /// Classe enclos, pour chaque enclos il y a une liste d'animaux, une espece et le prix de l'espece.
    /// </summary>
    public class Enclos
    {
        public List<Animal> AnimauxPresents { get; set; }
        public Animal.TypeAnimal Espece { get; set; }
        public double PrixEspece { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get { return 11; } }
        public int Height { get { return 8; } }

        public Enclos(int x, int y, Animal.TypeAnimal espece)
        {
            AnimauxPresents = new List<Animal>();
            X = x;
            Y = y;
            Espece = espece;
        }

        public Animal ContientDeuxSexesAdultes()
        {
            bool ContientM = false;
            Animal femelle = null;
            foreach (Animal a in AnimauxPresents.Where(a => !a.Enceinte && a.Age == Animal.AgeAnimal.Adulte))
            {
                switch (a.Sexe)
                {
                    case Entite.SexeEntite.M:
                        ContientM = true;
                        break;
                    case Entite.SexeEntite.F:
                        if (femelle == null)
                            femelle = a;
                        break;
                }
            }
            return ContientM ? femelle : null;
        }
    }
}
