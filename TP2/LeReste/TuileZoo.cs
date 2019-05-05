using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Entités;

namespace TP2.LeReste
{
    public class TuileZoo
    {
        public TypeTuile Tuile { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool ContientHumain { get; set; }
        public bool ContientAnimal { get; set; }
        //public bool ContientDechet { get; set; }


        public enum TypeTuile
        {
            Allee,
            Enclos,
            Gazon,
            Terre,
            Eau,
            Sable,
            Glace,
            Decoration,
            Interdit
        }

        public TuileZoo(TypeTuile tuile, int x, int y)
        {
            Tuile = tuile;
            X = x;
            Y = y;
        }

        /// <summary>
        /// Compare les positions de deux TuileZoos et indique si elles ont la même.
        /// </summary>
        public static bool operator == (TuileZoo left, TuileZoo right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator != (TuileZoo left, TuileZoo right)
        {
            return left.X != right.X || left.Y != right.Y;
        }

        /// <summary>
        /// Indique si une tuile figure dans une liste de tuiles
        /// </summary>
        internal bool EstDans(List<TuileZoo> listeTuiles)
        {
            foreach (TuileZoo tuile in listeTuiles)
                if (tuile == this)
                    return true;
            return false;
        }

        /// <summary>
        /// Indique si une TuileZoo contient un déchet ou non.
        /// </summary>
        /// <returns></returns>
        internal bool ContientDechet()
        {
            foreach (Dechet d in Zoo.ListeEntites.OfType<Dechet>())
                if (d.Position == this)
                    return true;
            return false;
        }
    }
}
