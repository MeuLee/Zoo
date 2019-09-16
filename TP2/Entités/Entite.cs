using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.LeReste;

namespace TP2.Entités
{
    public abstract class Entite
    {
        public TuileZoo Position { get; set; }
        public Bitmap Image { get; set; }
        

        protected static Random _r = new Random();

        public enum SexeEntite
        {
            M,
            F
        }

        /// <summary>
        /// Utilisé pour donner une image aux déplacements AI
        /// </summary>
        public enum Direction
        {
            Left,
            Up,
            Right,
            Down
        }
        
        /// <summary>
        /// Les entités ne peuvent pas se déplacer sur le même type de tuile
        /// </summary>
        /// <param name="tuile">La tuile où l'entité veut se déplacer</param>
        /// <returns>True si l'entité peut s'y déplacer</returns>
        protected abstract bool PeutSeDeplacer(TuileZoo tuile);
    }
}
