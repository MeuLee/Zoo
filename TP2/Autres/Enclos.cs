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
        public double prixEspece { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get { return 11; } }
        public int Height { get { return 8; } }

        public Enclos(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
