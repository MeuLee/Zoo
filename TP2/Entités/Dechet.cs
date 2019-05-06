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

        /// <summary>
        /// Random entre deux déchets, contenant de lait ou bouteille de plasique.
        /// </summary>
        /// <returns></returns>
        private Bitmap DeterminerImage()
        {
            return TileSetGenerator.GetTile(_r.Next(0, 2) + TileSetGenerator.DECHET_1);
        }

        /// <summary>
        /// Les déchets ne se déplacent pas
        /// </summary>
        /// <param name="tuile"></param>
        /// <returns></returns>
        protected override bool PeutSeDeplacer(TuileZoo tuile)
        {
            return false;
        }
    }
}
