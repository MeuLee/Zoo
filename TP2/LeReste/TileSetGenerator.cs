using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.LeReste
{
    class TileSetGenerator
    {
        // Différentes tailles concernant les images dans le fichier de tuiles de jeu
        public const int IMAGE_WIDTH = 32, IMAGE_HEIGHT = 32;

        // La valeur entière correspond "par hasard" à la position de l'image dans la List<TileCoord>
        public static int TL_ALLEE = 0;
        public static int T_ALLEE = 1;
        public static int TR_ALLEE = 2;
        public static int CL_ALLEE = 3;
        public static int C_ALLEE = 4;
        public static int CR_ALLEE = 5;
        public static int BL_ALLEE = 6;
        public static int B_ALLEE = 7;
        public static int BR_ALLEE = 8;

        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static TileSetGenerator()
        {
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 6 });
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 7 });
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 8 });
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 6 });
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 7 });
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 8 });
            listeCoord.Add(new TileCoord() { Ligne = 11, Colonne = 6 });
            listeCoord.Add(new TileCoord() { Ligne = 11, Colonne = 7 });
            listeCoord.Add(new TileCoord() { Ligne = 11, Colonne = 8 });

            listeBitmap.Add(LoadTile(TL_ALLEE));
            listeBitmap.Add(LoadTile(T_ALLEE));
            listeBitmap.Add(LoadTile(TR_ALLEE));
            listeBitmap.Add(LoadTile(CL_ALLEE));
            listeBitmap.Add(LoadTile(C_ALLEE));
            listeBitmap.Add(LoadTile(CR_ALLEE));
            listeBitmap.Add(LoadTile(BL_ALLEE));
            listeBitmap.Add(LoadTile(B_ALLEE));
            listeBitmap.Add(LoadTile(BR_ALLEE));
        }

        private static Bitmap LoadTile(int posListe)
        {
            Image source = TP2.Properties.Resources.zoo_tileset;
            TileCoord coord = listeCoord[posListe];
            Rectangle crop = new Rectangle(coord.Colonne * IMAGE_WIDTH, coord.Ligne * IMAGE_HEIGHT, IMAGE_WIDTH, IMAGE_HEIGHT);

            var bmp = new Bitmap(crop.Width, crop.Height);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        public static Bitmap GetTile(int posListe)
        {
            return listeBitmap[posListe];
        }

    }

    public class TileCoord
    {
        public int Ligne { get; set; }
        public int Colonne { get; set; }
    };
}

