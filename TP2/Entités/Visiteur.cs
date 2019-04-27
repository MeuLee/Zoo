using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.LeReste;

namespace TP2.Entités
{
    public class Visiteur : Humain
    {

        public DateTime QuandEntreZoo { get; private set; }
        public SexeEntite SexeVisiteur { get; private set; }
        public string Nom { get; private set; }
        public int TileSetSprite { get; private set; }

        /// <summary>
        /// 0-14 prénoms féminins, 15-29 prénoms masculins
        /// </summary>
        private List<string> _prenoms = new List<string>
        {
            "Camille", "Louise", "Ambre", "Agathe", "Jade", "Julia", "Mila", "Alice", "Emma", "Anna", "Lucie", "Eden", "Romane", "Lola", "Emy",
            "Louis", "Gabriel", "Paul", "Hugo", "Valentin", "Gabin", "Arthur", "Jules", "Lucas", "Sacha", "Ethan", "Antoine", "Nathan", "Thomas", "Tom"
        };

        private List<string> _noms = new List<string>
        {
            "Tremblay", "Gagnon", "Roy", "Bouchard", "Gauthier", "Morin", "Lavoie", "Fortin", "Ouellet", "Pelletier", "Bergeron", "Leblanc", "Paquette", "Girard", "Simard"
        };

        public Visiteur()
        {
            SexeVisiteur = (SexeEntite)_r.Next(0, 2);
            QuandEntreZoo = DateTime.Now;
            Position = Zoo.Terrain[5, 4];
            Image = DeterminerImageDepart();
            Nom = CreerNomComplet(SexeVisiteur);
            Zoo.Heros.Argent += Zoo.ListeEntites.OfType<Animal>().Count() * 2;
        }

        /// <summary>
        /// Initialise l'image du visiteur selon son sexe, avec un random 
        /// </summary>
        /// <returns>L'image de base du visiteur</returns>
        private Bitmap DeterminerImageDepart()
        {
            switch (SexeVisiteur)
            {
                case SexeEntite.M:
                    TileSetSprite = _r.Next(1, 3) * 10 + 21;
                    break;
                case SexeEntite.F:
                    TileSetSprite = _r.Next(1, 3) * 10 + 41;
                    break;
            }
            return TileSetGenerator.GetTile(TileSetSprite);
        }

        #region Creation du nom
        /// <summary>
        /// </summary>
        /// <param name="sexeVisiteur">Le sexe du visiteur, M ou F (enum)</param>
        /// <returns>Le nom complet</returns>
        private string CreerNomComplet(SexeEntite sexeVisiteur)
        {
            return CreerPrenom(sexeVisiteur) + " " + CreerNom();
        }

        /// <summary>
        /// Crée un prénom selon le sexe
        /// </summary>
        /// <param name="sexeVisiteur">Le sexe du visiteur, M ou F (enum)</param>
        /// <returns>Le prénom</returns>
        private string CreerPrenom(SexeEntite sexeVisiteur)
        {
            switch (sexeVisiteur)
            {
                case SexeEntite.F:
                    return _prenoms[_r.Next(0, 15)];
                case SexeEntite.M:
                    return _prenoms[_r.Next(15, 30)];
            }
            return "";
        }

        /// <summary>
        /// </summary>
        /// <returns>Le nom de famille</returns>
        private string CreerNom()
        {
            return _noms[_r.Next(0, 15)];
        }
        #endregion

        #region Déplacement
        internal override void DeplacerEtModifierImage()
        {
            List<KeyValuePair<TuileZoo, Direction>> casesDisponibles = DeterminerCasesDisponibles();
            if (casesDisponibles.Count != 0)
            {
                var caseDirection = casesDisponibles[_r.Next(0, casesDisponibles.Count)];
                TuileZoo prochaineTuile = caseDirection.Key;
                prochaineTuile.ContientHumain = true;
                Position = prochaineTuile;
                ModifierImage(caseDirection.Value);
            }
        }

        #region Image
        private void ModifierImage(Direction d)
        {
            switch(d)
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
        
        private void ModifierImageHautBas(int spriteInt)
        {
            if (Image == TileSetGenerator.GetTile(spriteInt))
                Image = TileSetGenerator.GetTile(spriteInt + 1);
            else
                Image = TileSetGenerator.GetTile(spriteInt);
        }

        private void ModifierImageCote(int spriteInt)
        {
            if (Image == TileSetGenerator.GetTile(spriteInt))
                Image = TileSetGenerator.GetTile(spriteInt + 1);
            else if (Image == TileSetGenerator.GetTile(spriteInt + 1))
                Image = TileSetGenerator.GetTile(spriteInt + 2);
            else
                Image = TileSetGenerator.GetTile(spriteInt);
        }
        #endregion

        /// <summary>
        /// Construction d'une liste comprenant les cases immédiates où l'animal peut se déplacer
        /// </summary>
        /// <returns>La liste de cases</returns>
        private List<KeyValuePair<TuileZoo, Direction>> DeterminerCasesDisponibles()
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
        /// Ajout d'une case à la liste si l'animal peut s'y déplacer
        /// </summary>
        /// <param name="possibilite"></param>
        /// <param name="casesDisponibles"></param>
        private void AjouterCaseAListe(TuileZoo possibilite, List<KeyValuePair<TuileZoo, Direction>> casesDisponibles, Direction d)
        {
            if (PeutSeDeplacer(possibilite))
                casesDisponibles.Add(new KeyValuePair<TuileZoo, Direction>(possibilite, d));
        }

        /// <summary>
        /// </summary>
        /// <param name="possibilite">Une case adjacente à l'animal</param>
        /// <returns>Si la case est libre ou non</returns>
        protected override bool PeutSeDeplacer(TuileZoo possibilite)
        {
            foreach (Entite e in Zoo.ListeEntites.OfType<Humain>())
            {
                if (e.Position.X == possibilite.X && e.Position.Y == possibilite.Y)
                    return false;
            }
            return possibilite.Tuile == TuileZoo.TypeTuile.Allee;
        }
        #endregion
    }
}
