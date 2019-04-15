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
                    if (Position.X != 0)
                    {

                    }
                    break;
                case Keys.Up:
                    if (Position.Y != 0)
                    {

                    }
                    break;
                case Keys.Right:
                    if (Position.X != 31)
                    {

                    }
                    break;
                case Keys.Down:
                    if (Position.Y != 25)
                    {

                    }
                    break;
            }
        }
    }
}
