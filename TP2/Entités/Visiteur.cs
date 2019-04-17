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

        public DateTime QuandEntreZoo { get; set; }
        public SexeEntite SexeVisiteur { get; set; }
        public string Nom { get; set; }
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
            Nom = DeterminerNomComplet(SexeVisiteur);
        }

        private string DeterminerNomComplet(SexeEntite sexeVisiteur)
        {
            return DeterminerPrenom(sexeVisiteur) + " " + DeterminerNom();
        }

        private string DeterminerPrenom(SexeEntite sexeVisiteur)
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
        
        private string DeterminerNom()
        {
            return _noms[_r.Next(0, 15)];
        }
    }

}
