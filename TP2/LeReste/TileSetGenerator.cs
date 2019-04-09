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
        private const int IMAGE_WIDTH = 32, IMAGE_HEIGHT = 32;

        //T = top, C = center, B = bottom, L = left, R = right
        public static int TL_ALLEE = 0;
        public static int T_ALLEE = 1;
        public static int TR_ALLEE = 2;
        public static int CL_ALLEE = 3;
        public static int C_ALLEE = 4;
        public static int CR_ALLEE = 5;
        public static int BL_ALLEE = 6;
        public static int B_ALLEE = 7;
        public static int BR_ALLEE = 8;
        public static int TL_ENCLOS = 9;
        public static int T_ENCLOS = 10;
        public static int TR_ENCLOS = 11;
        public static int CL_ENCLOS = 12;
        public static int C_ENCLOS = 13;
        public static int CR_ENCLOS = 14;
        public static int BL_ENCLOS = 15;
        public static int B_ENCLOS = 16;
        public static int BR_ENCLOS = 17;
        public static int CLOTURE_ENCLOS = 18;

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
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 9 });
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 10 });
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 11 });
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 9 });
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 10 });
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 11 });
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 9 });
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 10 });
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 11 });
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 9 });

            listeBitmap.Add(LoadTile(TL_ALLEE));
            listeBitmap.Add(LoadTile(T_ALLEE));
            listeBitmap.Add(LoadTile(TR_ALLEE));
            listeBitmap.Add(LoadTile(CL_ALLEE));
            listeBitmap.Add(LoadTile(C_ALLEE));
            listeBitmap.Add(LoadTile(CR_ALLEE));
            listeBitmap.Add(LoadTile(BL_ALLEE));
            listeBitmap.Add(LoadTile(B_ALLEE));
            listeBitmap.Add(LoadTile(BR_ALLEE));
            listeBitmap.Add(LoadTile(TL_ENCLOS));
            listeBitmap.Add(LoadTile(T_ENCLOS));
            listeBitmap.Add(LoadTile(TR_ENCLOS));
            listeBitmap.Add(LoadTile(CL_ENCLOS));
            listeBitmap.Add(LoadTile(C_ENCLOS));
            listeBitmap.Add(LoadTile(CR_ENCLOS));
            listeBitmap.Add(LoadTile(BL_ENCLOS));
            listeBitmap.Add(LoadTile(B_ENCLOS));
            listeBitmap.Add(LoadTile(BR_ENCLOS));
            listeBitmap.Add(LoadTile(CLOTURE_ENCLOS));
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

