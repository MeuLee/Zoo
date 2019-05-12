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

        /// <summary>
        /// 0-14 prénoms féminins, 15-29 prénoms masculins
        /// </summary>
        private readonly List<string> _prenoms = new List<string>
        {
            "Camille", "Louise", "Ambre", "Agathe", "Jade", "Julia", "Mila", "Alice", "Emma", "Anna", "Lucie", "Eden", "Romane", "Lola", "Emy",
            "Louis", "Gabriel", "Paul", "Hugo", "Valentin", "Gabin", "Arthur", "Jules", "Lucas", "Sacha", "Ethan", "Antoine", "Nathan", "Thomas", "Tom"
        };

        private readonly List<string> _noms = new List<string>
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
            Zoo.ListeEntites.Add(this);
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

        /// <summary>
        /// </summary>
        /// <param name="possibilite">Une case adjacente à l'animal</param>
        /// <returns>Si la case est libre ou non</returns>
        protected override bool PeutSeDeplacer(TuileZoo possibilite)
        {
            if (Zoo.ListeEntites.Where(e => (e is Humain || e is Dechet) && e.Position == possibilite).Count() > 0)
                return false;

            return possibilite.Tuile == TuileZoo.TypeTuile.Allee;
        }
    }
}
