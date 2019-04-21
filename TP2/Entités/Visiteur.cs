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
            Position = Zoo.Terrain[15, 0];//sera à changer
            Image = TileSetGenerator.GetTile(TileSetGenerator.V1_DOWN_IDLE);//random entre les 4
            Nom = CreerNomComplet(SexeVisiteur);
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

        internal void DeplacerEtModifierImage()
        {
            List<TuileZoo> casesDisponibles = DeterminerCasesDisponibles();
            if (casesDisponibles.Count != 0)
            {
                var actuelle = casesDisponibles[_r.Next(0, casesDisponibles.Count)];
                actuelle.ContientHumain = true;
                Position = actuelle;
            }
        }

        /// <summary>
        /// Construction d'une liste comprenant les cases immédiates où l'animal peut se déplacer
        /// </summary>
        /// <returns>La liste de cases</returns>
        private List<TuileZoo> DeterminerCasesDisponibles()
        {
            List<TuileZoo> casesDisponibles = new List<TuileZoo>();
            if (Position.X != 0)
                AjouterCaseAListe(Zoo.Terrain[Position.X - 1, Position.Y], casesDisponibles);
            if (Position.Y != 0)
                AjouterCaseAListe(Zoo.Terrain[Position.X, Position.Y - 1], casesDisponibles);
            if (Position.X != Zoo.Terrain.GetLength(0) - 1)
                AjouterCaseAListe(Zoo.Terrain[Position.X + 1, Position.Y], casesDisponibles);
            if (Position.Y != Zoo.Terrain.GetLength(1) - 1)
                AjouterCaseAListe(Zoo.Terrain[Position.X, Position.Y + 1], casesDisponibles);
            return casesDisponibles;
        }

        /// <summary>
        /// Ajout d'une case à la liste si l'animal peut s'y déplacer
        /// </summary>
        /// <param name="possibilite"></param>
        /// <param name="casesDisponibles"></param>
        private void AjouterCaseAListe(TuileZoo possibilite, List<TuileZoo> casesDisponibles)
        {
            if (PeutSeDeplacer(possibilite))
                casesDisponibles.Add(possibilite);
        }

        /// <summary>
        /// </summary>
        /// <param name="possibilite">Une case adjacente à l'animal</param>
        /// <returns>Si la case est libre ou non</returns>
        private bool PeutSeDeplacer(TuileZoo possibilite)
        {
            foreach (Entite e in Zoo.ListeEntites.OfType<Humain>())
            {
                if (e.Position.X == possibilite.X && e.Position.Y == possibilite.Y)
                    return false;
            }
            return possibilite.Tuile == TuileZoo.TypeTuile.Allee;
        }
    }
}
