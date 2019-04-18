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
        private static Random _r = new Random();

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
            Position = Zoo.Terrain[Enclos.X + 1, Enclos.Y + 1];
            Zoo.ListeEntites.Add(this);
        }

        internal void DeplacerEtModifierImage()
        {
            List<TuileZoo> casesDisponibles = DeterminerCasesDisponibles();
            if (casesDisponibles.Count != 0)
            {
                var actuelle = casesDisponibles[_r.Next(0, casesDisponibles.Count)];
                Position = actuelle;
                actuelle.ContientAnimal = true;
            }
        }

        private List<TuileZoo> DeterminerCasesDisponibles()
        {
            List<TuileZoo> casesDisponibles = new List<TuileZoo>();
            AjouterCaseAListe(Zoo.Terrain[Position.X - 1, Position.Y], ref casesDisponibles);
            AjouterCaseAListe(Zoo.Terrain[Position.X, Position.Y - 1], ref casesDisponibles);
            AjouterCaseAListe(Zoo.Terrain[Position.X + 1, Position.Y], ref casesDisponibles);
            AjouterCaseAListe(Zoo.Terrain[Position.X, Position.Y + 1], ref casesDisponibles);
            return casesDisponibles;
        }

        private void AjouterCaseAListe(TuileZoo possibilite, ref List<TuileZoo> casesDisponibles)
        {
            if (!possibilite.ContientHumain && 
                !possibilite.ContientAnimal && 
                possibilite.Tuile == TuileZoo.TypeTuile.Enclos)
                casesDisponibles.Add(possibilite);
        }
    }
}
