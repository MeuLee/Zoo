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
        private static Random _r = new Random();

        public DateTime QuandEntreZoo { get; private set; }
        public SexeEntite SexeVisiteur { get; private set; }
        public string Nom { get; private set; }

        /// <summary>
        /// 0-14 prénoms féminins, 15-29 
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

        public Visiteur(TuileZoo position)
        {
            SexeVisiteur = (SexeEntite)_r.Next(0, 2);
            QuandEntreZoo = DateTime.Now;
            Position = position;
            //Image = random entre les 4
            Nom = CreerNomComplet(SexeVisiteur);
        }

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
    }

}
