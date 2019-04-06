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

        public enum Sexe
        {
            M,
            F
        }
    }
}
