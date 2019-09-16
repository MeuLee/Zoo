using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.LeReste;

namespace TP2.Entités
{
    public abstract class Humain : Entite
    {
        /// <summary>
        /// Fait référence aux static integers dans la classe TileSetGenerator, les images des humains ont un ordre précis pour éviter le hardcode.
        /// </summary>
        public int TileSetSprite { get; protected set; }

        #region Déplacement
        /// <summary>
        /// À partir de la liste de TuileZoos disponible, un random détermine la nouvelle position de l'humain et change son image en conséquent.
        /// </summary>
        internal void DeplacerEtModifierImage()
        {
            List<KeyValuePair<TuileZoo, Direction>> casesDisponibles = DeterminerCasesDisponibles();
            if (casesDisponibles.Count != 0)
            {
                var caseDirection = casesDisponibles[_r.Next(0, casesDisponibles.Count)];
                TuileZoo prochaineTuile = caseDirection.Key;
                Position = prochaineTuile;
                ModifierImage(caseDirection.Value);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>Une liste de TuileZoos, autour de l'humain, où il peut s'y déplacer</returns>
        protected List<KeyValuePair<TuileZoo, Direction>> DeterminerCasesDisponibles()
        {
            var casesDisponibles = new List<KeyValuePair<TuileZoo, Direction>>();
            if (Position.X != 0)
                AjouterCaseAListe(Zoo.Terrain[Position.X - 1, Position.Y], casesDisponibles, Direction.Left);
            if (Position.Y != 0)
                AjouterCaseAListe(Zoo.Terrain[Position.X, Position.Y - 1], casesDisponibles, Direction.Up);
            if (Position.X != Zoo.Terrain.GetLength(0) - 1)
                AjouterCaseAListe(Zoo.Terrain[Position.X + 1, Position.Y], casesDisponibles, Direction.Right);
            if (Position.Y != Zoo.Terrain.GetLength(1) - 1)
                AjouterCaseAListe(Zoo.Terrain[Position.X, Position.Y + 1], casesDisponibles, Direction.Down);
            return casesDisponibles;
        }

        /// <summary>
        /// Ajoute une TuileZoo à la liste de cases où l'humain peut se déplacer. 
        /// </summary>
        /// <param name="possibilite">Une TuileZoo autour de l'humain</param>
        /// <param name="casesDisponibles">La liste de TuileZoos autour de l'humain</param>
        /// <param name="d">La direction de la possibilité par rapport à sa case actuelle</param>
        /// <returns></returns>
        protected List<KeyValuePair<TuileZoo, Direction>> AjouterCaseAListe(TuileZoo possibilite, List<KeyValuePair<TuileZoo, Direction>> casesDisponibles, Direction d)
        {
            if (PeutSeDeplacer(possibilite))
                casesDisponibles.Add(new KeyValuePair<TuileZoo, Direction>(possibilite, d));
            return casesDisponibles;
        }
        #endregion

        #region Image
        /// <summary>
        /// Fait une rotation entre 2-3 images pour simuler que l'humain marche, s'il arrive à marcher 3 fois dans la même direction avec l'algorithme bâtard.
        /// La direction sert à savoir quelle image lui donner.
        /// </summary>
        /// <param name="d">La direction choisie par le random</param>
        protected void ModifierImage(Direction d)
        {
            switch (d)
            {
                case Direction.Left:
                    ModifierImageCote(TileSetSprite + 4);
                    break;
                case Direction.Up:
                    ModifierImageHautBas(TileSetSprite + 2);
                    break;
                case Direction.Right:
                    ModifierImageCote(TileSetSprite + 7);
                    break;
                case Direction.Down:
                    ModifierImageHautBas(TileSetSprite);
                    break;
            }
        }

        /// <summary>
        /// Effectue une rotation entre les images de l'humain
        /// </summary>
        /// <param name="spriteInt">La classe TileSetGenerator contient des int qui sont dans un certain ordre. Ce paramètre représente la première image de la séquence</param>
        private void ModifierImageHautBas(int spriteInt)
        {
            Image = Image == TileSetGenerator.GetTile(spriteInt) 
                    ? TileSetGenerator.GetTile(spriteInt + 1) 
                    : TileSetGenerator.GetTile(spriteInt);
        }

        /// <summary>
        /// Effectue une rotation entre les images de l'humain
        /// </summary>
        /// <param name="spriteInt">La classe TileSetGenerator contient des int qui sont dans un certain ordre. Ce paramètre représente la première image de la séquence</param>
        private void ModifierImageCote(int spriteInt)
        {
            Image = Image == TileSetGenerator.GetTile(spriteInt)
                    ? TileSetGenerator.GetTile(spriteInt + 1)
                    : Image == TileSetGenerator.GetTile(spriteInt + 1)
                        ? TileSetGenerator.GetTile(spriteInt + 2)
                        : TileSetGenerator.GetTile(spriteInt);
        }
        #endregion
    }
}
