using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using TP2.LeReste;

namespace TP2.Entités
{
    public class Animal : Entite
    {
        public TypeAnimal Type { get; set; }

        /// <summary>
        /// Constant, représente le nombre de jours que l'animal doit gestationner avant de donner naissance
        /// </summary>
        public int JoursGestation { get; }

        /// <summary>
        /// Pas constant, agit comme compteur qui est décrémenté à chaque jour 
        /// jusqu'à 0 puis remis == à JoursGestation lors de la naissance
        /// </summary>
        public int JoursAvantNaissance { get; set; }
        public int JoursJusquaAdulte { get; set; }
        public int MinutesPourNourrir { get; set; }
        public DateTime DerniereFoisNourri { get; set; }
        public AgeAnimal Age { get; set; }
        public bool Enceinte { get; set; }
        public Enclos Enclos { get; set; }//sert à rien?
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
        /// Création de l'animal, selon le type en paramètre. Un sexe est assigné au hasard
        /// </summary>
        /// <param name="position">La position où l'animal débutera</param>
        /// <param name="type">Le type de l'animal (enum, soit Licorne, Lion, Mouton ou Grizzly</param>
        /// <param name="enclos"></param>
        /// <param name="age">Enum, soit Bebe ou Adulte</param>
        public Animal(TuileZoo position, TypeAnimal type, Enclos enclos = null, AgeAnimal age = AgeAnimal.Adulte)
        {
            Type = type;
            switch (type)
            {
                case TypeAnimal.Grizzly:
                    JoursGestation = 220;
                    JoursJusquaAdulte = 220;
                    JoursAvantNaissance = 220;
                    MinutesPourNourrir = 2;
                    Prix = PRIX_GRIZZLY;
                    Zoo.Heros.Argent -= PRIX_GRIZZLY;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.GRIZZLY);
                    Enclos = Zoo.ListeEnclos[3];
                    break;
                case TypeAnimal.Lion:
                    JoursGestation = 110;
                    JoursJusquaAdulte = 110;
                    JoursAvantNaissance = 110;
                    MinutesPourNourrir = 2;
                    Prix = PRIX_LION;
                    Zoo.Heros.Argent -= PRIX_LION;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.LION);
                    Enclos = Zoo.ListeEnclos[2];
                    break;
                case TypeAnimal.Mouton:
                    JoursGestation = 150;
                    JoursJusquaAdulte = 150;
                    JoursAvantNaissance = 150;
                    MinutesPourNourrir = 2;
                    Prix = PRIX_MOUTON;
                    Zoo.Heros.Argent -= PRIX_MOUTON;
                    Image = TileSetGenerator.GetTile(TileSetGenerator.MOUTON);
                    Enclos = enclos;
                    break;
                case TypeAnimal.Licorne:
                    JoursGestation = 360;
                    JoursJusquaAdulte = 360;
                    JoursAvantNaissance = 360;
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
            Zoo.InstanceForm.AjusterLblAnimaux();
        }

        #region Déplacement
        /// <summary>
        /// L'animal se déplace sur une case au hasard, parmi celles où il peut se déplacer
        /// </summary>
        internal void Deplacer()
        {
            List<TuileZoo> casesDisponibles = DeterminerCasesDisponibles();
            if (casesDisponibles.Count != 0)
                Position = casesDisponibles[_r.Next(0, casesDisponibles.Count)];
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
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
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
            if (Zoo.ListeEntites.Where(e => e.Position == possibilite).Count() > 0)
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

        #region Son des animaux
        /// <summary>
        /// Selon le type de l'animal, fait jouer le son approprié
        /// </summary>
        internal void EmettreSon()
        {
            switch (Type)
            {
                case TypeAnimal.Mouton:
                    PlayMoutonSound();
                    break;
                case TypeAnimal.Licorne:
                    PlayLicorneSound();
                    break;
                case TypeAnimal.Lion:
                    PlayLionSound();
                    break;
                case TypeAnimal.Grizzly:
                    PlayGrizzlySound();
                    break;
            }
        }
        /// <summary>
        /// Son du lion
        /// </summary>
        private void PlayLionSound()
        {
            new SoundPlayer(Properties.Resources.lion).Play();
        }

        /// <summary>
        /// Son du grizzly
        /// </summary>
        private void PlayGrizzlySound()
        {
            new SoundPlayer(Properties.Resources.ours).Play();
        }

        /// <summary>
        /// Son de la licorne
        /// </summary>
        private void PlayLicorneSound()
        {
            new SoundPlayer(Properties.Resources.licorne).Play();
        }

        /// <summary>
        /// Son du mouton
        /// </summary>
        private void PlayMoutonSound()
        {
            new SoundPlayer(Properties.Resources.mouton).Play();
        }
        #endregion

        /// <summary>
        /// Crée un nouvel animal et réinitalise les properties JoursAvantNaissance et Enceinte
        /// </summary>
        public void DonnerNaissance()
        {
            new Animal(Position, Type, Enclos, AgeAnimal.Bebe);
            JoursAvantNaissance = JoursGestation;
            Enceinte = false;
        }
    }
}
