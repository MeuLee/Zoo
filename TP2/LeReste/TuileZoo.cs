using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.LeReste
{
    public class TuileZoo
    {
        public bool ContientDechet { get; set; }
        public bool EstSortie { get; set; }
        public TypeTuile Tuile { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool ContientHumain { get; set; }
        public bool ContientAnimal { get; set; }

        public enum TypeTuile
        {
            Allee,
            Cloture,
            Enclos,
            Gazon,
            Fleur,
            Plante,
            Terre,
            Eau,
            Sable,
            Glace,
        }

        public TuileZoo(TypeTuile tuile, bool estSortie, int x, int y)
        {
            EstSortie = estSortie;
            Tuile = tuile;
            X = x;
            Y = y;
        }
    }
}
