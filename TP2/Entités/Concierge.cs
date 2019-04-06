using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.LeReste;

namespace TP2.Entités
{
    public class Concierge : Humain
    {
        public Concierge(TuileZoo position, Bitmap image)
        {
            Position = position;
            Image = image;
        }
    }
}
