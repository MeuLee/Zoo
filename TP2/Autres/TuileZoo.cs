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
            return Zoo.ListeEntites.OfType<Dechet>().Where(d => d.Position == this).Count() > 0;
        }

        /// <summary>
        /// Indique si une TuileZoo contient un animal ou non.
        /// </summary>
        /// <returns></returns>
        internal bool ContientAnimal()
        {
            return Zoo.ListeEntites.OfType<Animal>().Where(e => e.Position == Zoo.Terrain[X, Y]).Count() > 0;
        }

        /// <summary>
        /// Indique si une TuileZoo est à côté du Héros ou non (dans un rayon de 1).
        /// </summary>
        /// <returns></returns>
        internal bool EstACoteDuHeros()
        {
            TuileZoo[,] terrain = Zoo.Terrain;
            Heros heros = Zoo.Heros;
            if (heros != null)
                try
                {
                    return terrain[X - 1, Y - 1] == heros.Position
                        || terrain[X, Y + 1] == heros.Position
                        || terrain[X + 1, Y + 1] == heros.Position
                        || terrain[X + 1, Y] == heros.Position
                        || terrain[X + 1, Y - 1] == heros.Position
                        || terrain[X, Y - 1] == heros.Position
                        || terrain[X - 1, Y - 1] == heros.Position
                        || terrain[X - 1, Y] == heros.Position;
                } catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            return false;
        }
    }
}
