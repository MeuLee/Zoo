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
        public bool ContientAnimal { get; set; }
        public bool ContientVisiteur { get; set; }
        public bool EstSortie { get; set; }
        public TypeTuile Tuile { get; set; }

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
        }

        public TuileZoo(TypeTuile tuile, bool estSortie)
        {
            ContientAnimal = false;
            ContientDechet = false;
            ContientVisiteur = false;
            EstSortie = estSortie;
            Tuile = tuile;
        } 
    }
}
