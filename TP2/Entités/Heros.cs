using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.LeReste;

namespace TP2.Entités
{
    public class Heros : Humain
    {
        public int Argent { get; set; }

        public Heros(TuileZoo position)
        {
            Position = position;
            Image = TileSetGenerator.GetTile(TileSetGenerator.HEROS);//pas testé si ça marche
            Argent = 100;
        }
    }
}
