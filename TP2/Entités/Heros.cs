using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2.LeReste;

namespace TP2.Entités
{
    public class Heros : Humain
    {
        public int Argent { get; set; }

        public Heros(Zoo zoo)
        {
            Position = Zoo.Terrain[15, 0];
            Image = TileSetGenerator.GetTile(TileSetGenerator.HEROS);//pas testé si ça marche
            Argent = 100;
        }

        internal void Deplacer(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Left:
                    Position = Zoo.Terrain
                    break;
                case Keys.Up:
                    break;
                case Keys.Right:
                    break;
                case Keys.Down:
                    break;
            }
        }
    }
}
