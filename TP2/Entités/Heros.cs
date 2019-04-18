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

        public Heros()
        {
            Image = TileSetGenerator.GetTile(TileSetGenerator.HEROS_DOWN_IDLE);
            Argent = 100;
        }

        /// <summary>
        /// </summary>
        /// <param name="keyCode">La touche appuyée (w, a, s ou d)</param>
        internal void DeplacerEtModifierImage(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.A:
                    if (Position.X != 0)
                        Deplacer(Position.X - 1, Position.Y);
                    ModifierImageCote(TileSetGenerator.HEROS_LEFT_IDLE);
                    break;
                case Keys.W:
                    if (Position.Y != 0)
                        Deplacer(Position.X, Position.Y - 1);
                    ModifierImageHautBas(TileSetGenerator.HEROS_UP_IDLE);
                    break;
                case Keys.D:
                    if (Position.X != Zoo.Terrain.GetLength(0) - 1)//largeur
                        Deplacer(Position.X + 1, Position.Y);
                    ModifierImageCote(TileSetGenerator.HEROS_RIGHT_IDLE);
                    break;
                case Keys.S:
                    if (Position.Y != Zoo.Terrain.GetLength(1) - 1)//hauteur
                        Deplacer(Position.X, Position.Y + 1);
                    ModifierImageHautBas(TileSetGenerator.HEROS_DOWN_IDLE);
                    break;
            }
        }

        /// <summary>
        /// Modifie la position du Héros dans le tableau uniquement. Il sera dessiné par la méthode OnPaint plus loin.
        /// </summary>
        /// <param name="nouveauX">Le nouveau X de la case</param>
        /// <param name="nouveauY">Le nouveau Y de la case</param>
        private void Deplacer(int nouveauX, int nouveauY)
        {
            var possibilite = Zoo.Terrain[nouveauX, nouveauY];

            if (possibilite.Tuile == TuileZoo.TypeTuile.Allee || 
                possibilite.Tuile == TuileZoo.TypeTuile.Enclos && 
                !possibilite.ContientHumain &&
                !possibilite.ContientAnimal)
            {
                Position = Zoo.Terrain[nouveauX, nouveauY];
                Zoo.Terrain[nouveauX, nouveauY].ContientHumain = true;
            }
        }

        /// <summary>
        /// Effectue une rotation entre l'image du héros pour simuler qu'il marche
        /// </summary>
        /// <param name="offset">
        /// La méthode GetTile accepte un int, il suffit que les 3 images de la même
        /// direction se suivent en ordre (ex. 25-26-27)
        /// </param>
        private void ModifierImageCote(int offset)
        {
            if (Image == TileSetGenerator.GetTile(offset))
                Image = TileSetGenerator.GetTile(offset + 1);
            else if (Image == TileSetGenerator.GetTile(offset + 1))
                Image = TileSetGenerator.GetTile(offset + 2);
            else
                Image = TileSetGenerator.GetTile(offset);
        }

        /// <summary>
        /// Effectue une rotation entre l'image du héros pour simuler qu'il marche
        /// </summary>
        /// <param name="offset">
        /// La méthode GetTile accepte un int, il suffit que les 2 images de la même
        /// direction se suivent en ordre (ex. 23-24)
        /// </param>
        private void ModifierImageHautBas(int offset)
        {
            if (Image == TileSetGenerator.GetTile(offset))
                Image = TileSetGenerator.GetTile(offset + 1);
            else
                Image = TileSetGenerator.GetTile(offset);
        }
    }
}
