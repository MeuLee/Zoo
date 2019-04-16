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
        private Zoo Zoo;

        public Heros(Zoo zoo)
        {
            Zoo = zoo;
            Position = Zoo.Terrain[15, 0];
            Image = TileSetGenerator.GetTile(TileSetGenerator.HEROS);
            Argent = 100;
        }

        internal void Deplacer(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Left:
                    if (PeutSeDeplacer(Position.X - 1, Position.Y))
                        Position = Zoo.Terrain[Position.X - 1, Position.Y];
                    break;
                case Keys.Up:
                    if (PeutSeDeplacer(Position.X, Position.Y - 1))
                        Position = Zoo.Terrain[Position.X, Position.Y - 1];
                    break;
                case Keys.Right:
                    if (PeutSeDeplacer(Position.X + 1, Position.Y))
                        Position = Zoo.Terrain[Position.X + 1, Position.Y];
                    break;
                case Keys.Down:
                    if (PeutSeDeplacer(Position.X, Position.Y + 1))
                        Position = Zoo.Terrain[Position.X, Position.Y + 1];
                    break;
            }
            Zoo.Refresh();
            
        }

        private bool PeutSeDeplacer(int nouveauX, int nouveauY)
        {
            return nouveauX != -1 && 
                   nouveauX != 32 && 
                   nouveauY != -1 && 
                   nouveauY != 26 && 
                   Zoo.Terrain[nouveauX, nouveauY].Tuile != TuileZoo.TypeTuile.Cloture;
        }
    }
}
