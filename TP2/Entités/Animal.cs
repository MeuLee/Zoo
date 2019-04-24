using System;
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
        public int MoisPourNourrir { get; set; }
        public DateTime DerniereFoisNourri { get; set; }
        public AgeAnimal Age { get; set; }
        public bool Enceinte { get; set; }
        public Enclos Enclos { get; set; }
        public bool AFaim { get; set; }
        public SexeEntite Sexe { get; set; }
        public int Prix { get; set; }

        public enum TypeAnimal
        {
            Mouton,
            Grizzly,
            Lion,
            Rhinoceros
        }

        public enum AgeAnimal
        {
            Bebe,
            Adulte
        }

        public Animal(TypeAnimal type, Enclos enclos, AgeAnimal age = AgeAnimal.Adulte)
        {
            Type = type;
            switch (type)
            {
                case TypeAnimal.Grizzly:
                    JoursGestation = 220;
                    JoursJusquaAdulte = 220;
                    MoisPourNourrir = 1;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.GRIZZLI);
                    Prix = 30;
                    break;
                case TypeAnimal.Lion:
                    JoursGestation = 360;
                    JoursJusquaAdulte = 360;
                    MoisPourNourrir = 2;
                    //Image = TileSetGenerator.GetTile(TileSetGenerator.LICORNE);
                    Prix = 35;
                    break;
                case TypeAnimal.Mouton:
                    JoursGestation = 150;
                    JoursJusquaAdulte = 150;
                    MoisPourNourrir = 1;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.MOUTON);
                    Prix = 20;
                    break;
                case TypeAnimal.Rhinoceros:
                    JoursGestation = 150;
                    JoursJusquaAdulte = 150;
                    MoisPourNourrir = 1;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.MOUTON);
                    Prix = 40;
                    break;
            }
            Enclos = enclos;
            DerniereFoisNourri = DateTime.Now;
            AFaim = false;
            Age = age;
            Enceinte = false;
            Sexe = (SexeEntite)_r.Next(0, 2);
            Position = DeterminerPositionDepart();
            Zoo.ListeEntites.Add(this);
        }

        /// <summary>
        /// S'assure que les animaux commencent tous à une place différente dans l'enclos
        /// </summary>
        /// <returns></returns>
        private TuileZoo DeterminerPositionDepart()
        {
            TuileZoo possibilite;
            do
            {
                possibilite = Zoo.Terrain[_r.Next(Enclos.X + 1, Enclos.X + Enclos.Width - 1), //X compris dans l'enclos de l'animal
                                          _r.Next(Enclos.Y + 1, Enclos.Y + Enclos.Height - 1)];//Y compris dans l'enclos de l'animal
            } while (possibilite.ContientAnimal || possibilite.ContientHumain);
            return possibilite;
        }

        /// <summary>
        /// L'animal se déplace sur une case au hasard, parmi celles où il peut se déplacer
        /// </summary>
        internal void DeplacerEtModifierImage()
        {
            List<TuileZoo> casesDisponibles = DeterminerCasesDisponibles();
            if (casesDisponibles.Count != 0)
            {
                var actuelle = casesDisponibles[_r.Next(0, casesDisponibles.Count)];
                actuelle.ContientAnimal = true;
                Position = actuelle;
            }
            //Modifier image
        }

        /// <summary>
        /// Construction d'une liste comprenant les cases immédiates où l'animal peut se déplacer
        /// </summary>
        /// <returns>La liste de cases</returns>
        private List<TuileZoo> DeterminerCasesDisponibles()
        {
            List<TuileZoo> casesDisponibles = new List<TuileZoo>();
            AjouterCaseAListe(Zoo.Terrain[Position.X - 1, Position.Y], casesDisponibles);
            AjouterCaseAListe(Zoo.Terrain[Position.X, Position.Y - 1], casesDisponibles);
            AjouterCaseAListe(Zoo.Terrain[Position.X + 1, Position.Y], casesDisponibles);
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
            foreach (Entite e in Zoo.ListeEntites)
            {
                if (e.Position.X == possibilite.X && e.Position.Y == possibilite.Y)
                    return false;
            }
            return possibilite.Tuile == TuileZoo.TypeTuile.Enclos;
        }
    }
}
