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
        /// <param name="left">La première tuile à comparer</param>
        /// <param name="right">La deuxième tuile à comparer</param>
        /// <returns>True si les deux TuileZoos ont la même position</returns>
        public static bool operator == (TuileZoo left, TuileZoo right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        /// <summary>
        /// N'est pas utilisée, mais l'opérateur == a besoin que l'opérateur != soit redéfini
        /// </summary>
        public static bool operator != (TuileZoo left, TuileZoo right)
        {
            return left.X != right.X || left.Y != right.Y;
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
