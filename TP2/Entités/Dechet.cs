using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.LeReste;

namespace TP2.Entités
{
    public class Dechet : Entite
    {
        public Dechet(TuileZoo position)
        {
            Position = position;
            Image = DeterminerImage();
            Zoo.ListeEntites.Add(this);
        }

        private Bitmap DeterminerImage()
        {
            return TileSetGenerator.GetTile(_r.Next(0, 2) + TileSetGenerator.DECHET_1);
        }
    }
}
