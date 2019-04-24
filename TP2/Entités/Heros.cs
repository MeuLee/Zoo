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
        }

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
                possibilite.ContientHumain = true;
                Position = possibilite;
            }
        }

        /// <summary>
        /// Effectue une rotation entre 2 images pour simuler que le héros marche.
        /// </summary>
        /// <param name="bmp1">Première image</param>
        /// <param name="bmp2">Deuxième image</param>
        private void ModifierImageCote(Bitmap bmp1, Bitmap bmp2)
        {
            if (Image == bmp1)
                Image = bmp2;
            else
                Image = bmp1;
        }

        /// <summary>
        /// Effectue une rotation entre 3 images pour simuler que le héros marche.
        /// </summary>
        /// <param name="bmp1">Première image</param>
        /// <param name="bmp2">Deuxième image</param>
        /// <param name="bmp3">Troisième image</param>
        private void ModifierImageHautBas(Bitmap bmp1, Bitmap bmp2, Bitmap bmp3)
        {
            if (Image == bmp1)
                Image = bmp2;
            else if (Image == bmp2)
                Image = bmp3;
            else
                Image = bmp1;
        }

        /// <summary>
        /// </summary>
        /// <param name="possibilite">La case où le héros veut se déplacer</param>
        /// <returns>S'il peut se déplacer sur la case ou non</returns>
        private bool PeutSeDeplacer(TuileZoo possibilite)
        {
            foreach (Entite e in Zoo.ListeEntites)
            {
                if (e.Position.X == possibilite.X && e.Position.Y == possibilite.Y)
                    return false;
            }
            return (possibilite.Tuile == TuileZoo.TypeTuile.Allee || possibilite.Tuile == TuileZoo.TypeTuile.Enclos);
        }
    }
}
