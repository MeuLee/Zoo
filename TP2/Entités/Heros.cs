using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2.LeReste;
using TP2.Properties;

namespace TP2.Entités
{
    public class Heros : Humain
    {
        private static Bitmap HEROS_BAS_1 = Resources.bas1;
        private static Bitmap HEROS_BAS_2 = Resources.bas2;
        private static Bitmap HEROS_BAS_3 = Resources.bas3;
        private static Bitmap HEROS_DROITE_1 = Resources.droite1;
        private static Bitmap HEROS_DROITE_2 = Resources.droite2;
        private static Bitmap HEROS_GAUCHE_1 = Resources.gauche1;
        private static Bitmap HEROS_GAUCHE_2 = Resources.gauche2;
        private static Bitmap HEROS_HAUT_1 = Resources.haut1;
        private static Bitmap HEROS_HAUT_2 = Resources.haut2;
        private static Bitmap HEROS_HAUT_3 = Resources.haut3;
        public double Argent { get; set; }

        public Heros()
        {
            Image = HEROS_BAS_1;
            Argent = 100;
            Position = Zoo.Terrain[5, 4];
            Zoo.Heros = this;
        }

        #region Déplacement
        /// <summary>
        /// </summary>
        /// <param name="keyCode">La touche appuyée (w, a, s ou d)</param>
        internal void DeplacerEtModifierImage(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.A:
                    if (Position.X != 0)
                        Deplacer(Position.X - 1, Position.Y);
                    ModifierImageCote(HEROS_GAUCHE_1, HEROS_GAUCHE_2);
                    break;
                case Keys.W:
                    if (Position.Y != 0)
                        Deplacer(Position.X, Position.Y - 1);
                    ModifierImageHautBas(HEROS_HAUT_1, HEROS_HAUT_2, HEROS_HAUT_3);
                    break;
                case Keys.D:
                    if (Position.X != Zoo.Terrain.GetLength(0) - 1)//largeur
                        Deplacer(Position.X + 1, Position.Y);
                    ModifierImageCote(HEROS_DROITE_1, HEROS_DROITE_2);
                    break;
                case Keys.S:
                    if (Position.Y != Zoo.Terrain.GetLength(1) - 1)//hauteur
                        Deplacer(Position.X, Position.Y + 1);
                    ModifierImageHautBas(HEROS_BAS_1, HEROS_BAS_2, HEROS_BAS_3);
                    break;
            }
        }

        /// <summary>
        /// Modifie la position du Héros dans le tableau uniquement. Il sera dessiné par la méthode OnPaint plus loin.
        /// </summary>
        /// <param name="nouveauX">Le nouveau X de la case</param>
        /// <param name="nouveauY">Le nouveau Y de la case</param>
        private void Deplacer(int nouveauX, int nouveauY)
        {
            var possibilite = Zoo.Terrain[nouveauX, nouveauY];

            if (PeutSeDeplacer(possibilite))
            {
                Position = possibilite;
            }
        }

        /// <summary>
        /// Le héros peut se déplacer dans l'allée et dans les enclos.
        /// </summary>
        /// <param name="possibilite">La case où le héros veut se déplacer</param>
        /// <returns>S'il peut se déplacer sur la case ou non</returns>
        protected override bool PeutSeDeplacer(TuileZoo possibilite)
        {
            if (Zoo.ListeEntites.Where(e => e.Position == possibilite).Count() > 0)
                return false;

            return (possibilite.Tuile == TuileZoo.TypeTuile.Allee || 
                    possibilite.Tuile == TuileZoo.TypeTuile.Enclos || 
                    possibilite.Tuile == TuileZoo.TypeTuile.Gazon || 
                    possibilite.Tuile == TuileZoo.TypeTuile.Glace || 
                    possibilite.Tuile == TuileZoo.TypeTuile.Sable || 
                    possibilite.Tuile == TuileZoo.TypeTuile.Terre);
        }
        #endregion

        #region Image
        /// <summary>
        /// Effectue une rotation entre 2 images pour simuler que le héros marche.
        /// </summary>
        /// <param name="bmp1">Première image</param>
        /// <param name="bmp2">Deuxième image</param>
        private void ModifierImageCote(Bitmap bmp1, Bitmap bmp2)
        {
            Image = Image == bmp1
                    ? bmp2
                    : bmp1;
        }

        /// <summary>
        /// Effectue une rotation entre 3 images pour simuler que le héros marche.
        /// </summary>
        /// <param name="bmp1">Première image</param>
        /// <param name="bmp2">Deuxième image</param>
        /// <param name="bmp3">Troisième image</param>
        private void ModifierImageHautBas(Bitmap bmp1, Bitmap bmp2, Bitmap bmp3)
        {
            Image = Image == bmp1
                    ? bmp2
                    : Image == bmp2
                        ? bmp3
                        : bmp1;
        }
        #endregion

        /// <summary>
        /// Ajoute 1 dollar par animal présent dans le zoo, - 10c par déchet présent, par visiteur
        /// </summary>
        internal void AjouterArgentSelonAnimauxEtDechets()
        {
            Argent += Zoo.ListeEntites.OfType<Visiteur>().Count() *
                     (Zoo.ListeEntites.OfType<Animal>().Count() - Zoo.ListeEntites.OfType<Dechet>().Count() * 0.1);
        }

        /// <summary>
        /// Enlève 2 dollars par concierge engagé
        /// </summary>
        internal void RetirerArgentSelonConcierges()
        {
            Argent -= 2 * Zoo.ListeEntites.OfType<Concierge>().Count();
        }

        /// <summary>
        /// Indique si le héros a assez d'argent pour acheter quelque chose.
        /// </summary>
        /// <param name="prix">Le prix du quelque chose</param>
        /// <returns></returns>
        internal bool AAssezDArgent(double prix)
        {
            if (Argent < prix)
                MessageBox.Show("Fonds insuffisants !", "Avertissement");

            return Argent >= prix;
        }
    }
}
