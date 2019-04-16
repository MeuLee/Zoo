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
            Image = TileSetGenerator.GetTile(TileSetGenerator.HEROS_DOWN);
            Argent = 100;
        }

        internal void Deplacer(Keys keyCode, Zoo zoo)
        {
            switch (keyCode)
            {
                case Keys.A:
                    if (Position.X != 0)
                        Deplacer(Position.X - 1, Position.Y);
                    Image = TileSetGenerator.GetTile(TileSetGenerator.HEROS_LEFT);
                    break;
                case Keys.W:
                    if (Position.Y != 0)
                        Deplacer(Position.X, Position.Y - 1);
                    Image = TileSetGenerator.GetTile(TileSetGenerator.HEROS_UP);
                    break;
                case Keys.D:
                    if (Position.X != Zoo.Terrain.GetLength(0) - 1)
                        Deplacer(Position.X + 1, Position.Y);
                    Image = TileSetGenerator.GetTile(TileSetGenerator.HEROS_RIGHT);
                    break;
                case Keys.S:
                    if (Position.Y != Zoo.Terrain.GetLength(1) - 1)
                        Deplacer(Position.X, Position.Y + 1);
                    Image = TileSetGenerator.GetTile(TileSetGenerator.HEROS_DOWN);
                    break;
            }
            
        }

        private void Deplacer (int nouveauX, int nouveauY)
        {
            var typeNouvelleCase = Zoo.Terrain[nouveauX, nouveauY].Tuile;
            if (typeNouvelleCase == TuileZoo.TypeTuile.Allee || typeNouvelleCase == TuileZoo.TypeTuile.Enclos)
            {
                Position.X = nouveauX;
                Position.Y = nouveauY;

            }
        }
    }
}
