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

        public enum TypeAnimal
        {
            Mouton,
            Grizzly,
            Licorne
        }

        public enum AgeAnimal
        {
            Bebe,
            Adulte
        }

        public Animal(TypeAnimal type, DateTime derniereFoisNourrri, AgeAnimal age, Enclos enclos)
        {
            Type = type;
            switch (type)
            {
                case TypeAnimal.Grizzly:
                    JoursGestation = 220;
                    JoursJusquaAdulte = 220;
                    MoisPourNourrir = 1;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.GRIZZLI);//pas testé si c'est la bonne image
                    break;
                case TypeAnimal.Licorne:
                    JoursGestation = 360;
                    JoursJusquaAdulte = 360;
                    MoisPourNourrir = 2;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.LICORNE);//pas testé si c'est la bonne image
                    break;
                case TypeAnimal.Mouton:
                    JoursGestation = 150;
                    JoursJusquaAdulte = 150;
                    MoisPourNourrir = 1;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.MOUTON);//pas testé si c'est la bonne image
                    break;
            }
            derniereFoisNourrri = DateTime.Now;
            AFaim = false;
            Age = age;
            Enceinte = false;
            Enclos = enclos;
            Sexe = (SexeEntite)_r.Next(0, 2);
            //Position = soit quelque part dans l'enclos ou ils ont un spawn point precis
            
        }


    }
}
