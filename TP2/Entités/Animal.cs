﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.LeReste;

namespace TP2.Entités
{
    public class Animal : Entite
    {
        public TypeAnimal Type { get; set; }
        public int JoursGestation { get; set; }
        public int JoursJusquaAdulte { get; set; }
        public int MinutesPourNourrir { get; set; }//en temps reel, ou on peut changer ca pour des jours (*60)
        public DateTime DerniereFoisNourri { get; set; }
        public AgeAnimal Age { get; set; }
        public bool Enceinte { get; set; }
        public Enclos Enclos { get; set; }
        public bool AFaim { get; set; }
        public SexeEntite Sexe { get; set; }

        public double Prix { get; set; }

        public const double PRIX_MOUTON = 20;
        public const double PRIX_GRIZZLY = 30;
        public const double PRIX_LION = 35;
        public const double PRIX_LICORNE = 50;

        public enum TypeAnimal
        {
            Mouton,
            Grizzly,
            Lion,
            Licorne,
            Inexistant
        }

        public enum AgeAnimal
        {
            Bebe,
            Adulte
        }

        /// <summary>
        /// Creation de l'animal, selon le type en parametre
        /// </summary>
        /// <param name="position"></param>
        /// <param name="type"></param>
        /// <param name="enclos"></param>
        /// <param name="age"></param>
        public Animal(TuileZoo position, TypeAnimal type, Enclos enclos = null, AgeAnimal age = AgeAnimal.Adulte)
        {
            Type = type;
            switch (type)
            {
                case TypeAnimal.Grizzly:
                    JoursGestation = 220;
                    JoursJusquaAdulte = 220;
                    MinutesPourNourrir = 2;
                    Prix = PRIX_GRIZZLY;
                    Zoo.Heros.Argent -= PRIX_GRIZZLY;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.GRIZZLY);
                    Enclos = Zoo.ListeEnclos[3];
                    break;
                case TypeAnimal.Lion:
                    JoursGestation = 110;
                    JoursJusquaAdulte = 110;
                    MinutesPourNourrir = 2;
                    Prix = PRIX_LION;
                    Zoo.Heros.Argent -= PRIX_LION;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.LION);
                    Enclos = Zoo.ListeEnclos[2];
                    break;
                case TypeAnimal.Mouton:
                    JoursGestation = 150;
                    JoursJusquaAdulte = 150;
                    MinutesPourNourrir = 2;
                    Prix = PRIX_MOUTON;
                    Zoo.Heros.Argent -= PRIX_MOUTON;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.MOUTON);
                    Enclos = enclos;
                    break;
                case TypeAnimal.Licorne:
                    JoursGestation = 360;
                    JoursJusquaAdulte = 360;
                    MinutesPourNourrir = 3;
                    Prix = PRIX_LICORNE;
                    Zoo.Heros.Argent -= PRIX_LICORNE;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.LICORNE);
                    Enclos = enclos;
                    break;
            }

            DerniereFoisNourri = DateTime.Now;
            AFaim = false;
            Age = age;
            Enceinte = false;
            Sexe = (SexeEntite)_r.Next(0, 2);
            Position = position;
            Zoo.ListeEntites.Add(this);
        }

        #region Déplacement
        /// <summary>
        /// L'animal se déplace sur une case au hasard, parmi celles où il peut se déplacer
        /// </summary>
        internal void Deplacer()
        {
            List<TuileZoo> casesDisponibles = DeterminerCasesDisponibles();
            if (casesDisponibles.Count != 0)
            {
                var actuelle = casesDisponibles[_r.Next(0, casesDisponibles.Count)];
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
            try
            {
                AjouterCaseAListe(Zoo.Terrain[Position.X - 1, Position.Y], casesDisponibles);
                AjouterCaseAListe(Zoo.Terrain[Position.X, Position.Y - 1], casesDisponibles);
                AjouterCaseAListe(Zoo.Terrain[Position.X + 1, Position.Y], casesDisponibles);
                AjouterCaseAListe(Zoo.Terrain[Position.X, Position.Y + 1], casesDisponibles);
            }
            catch (IndexOutOfRangeException e) { }
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
        protected override bool PeutSeDeplacer(TuileZoo possibilite)
        {
            foreach (Entite e in Zoo.ListeEntites)
                if (e.Position == possibilite)
                    return false;

            return (possibilite.Tuile == TuileZoo.TypeTuile.Enclos ||
                   possibilite.Tuile == TuileZoo.TypeTuile.Glace ||
                   possibilite.Tuile == TuileZoo.TypeTuile.Sable ||
                   possibilite.Tuile == TuileZoo.TypeTuile.Terre ||
                   possibilite.Tuile == TuileZoo.TypeTuile.Eau ||
                   possibilite.Tuile == TuileZoo.TypeTuile.Decoration ||
                   possibilite.Tuile == TuileZoo.TypeTuile.Gazon) &&
                   possibilite.Tuile != TuileZoo.TypeTuile.Interdit;
        }
        #endregion

    }
}
