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
        public int Width { get { return 10; } }
        public int Height { get { return 7; } }

        public Enclos(int x, int y, Animal.TypeAnimal espece)
        {
            AnimauxPresents = new List<Animal>();
            X = x;
            Y = y;
            Espece = espece;
        }

        /// <summary>
        /// Indique si un enclos a un adulte mâle et une adulte femelle.
        /// La valeur de retour est utilisée un peu comme booléen, sauf que null = false et la référence de l'animal = true.
        /// </summary>
        /// <returns>Null si l'enclos ne contient pas les deux, la référence de la femelle si l'enclos contient les deux.</returns>
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
