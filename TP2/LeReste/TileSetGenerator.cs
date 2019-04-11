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
        public static int ENTREE = 19;
        public static int GRIZZLI = 20;
        public static int LICORNE = 21;
        public static int MOUTON = 22;

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
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 12 });
            listeCoord.Add(new TileCoord() { Ligne = 20, Colonne = 16 });
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 16 });
            listeCoord.Add(new TileCoord() { Ligne = 20, Colonne = 8 });

            listeBitmap.Add(LoadTile(TL_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(T_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(TR_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(CL_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(C_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(CR_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(BL_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(B_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(BR_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(TL_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(T_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(TR_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(CL_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(C_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(CR_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(BL_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(B_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(BR_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(CLOTURE_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(ENTREE, 128, 160));
            listeBitmap.Add(LoadTile(GRIZZLI, 32, 32));
            listeBitmap.Add(LoadTile(LICORNE, 32, 32));
            listeBitmap.Add(LoadTile(MOUTON, 32, 32));
        }

        private static Bitmap LoadTile(int posListe, int width, int height)
        {
            Image source = Properties.Resources.zoo_tileset;
            TileCoord coord = listeCoord[posListe];
            Rectangle crop = new Rectangle(coord.Colonne * IMAGE_WIDTH, coord.Ligne * IMAGE_HEIGHT, width, height);

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

