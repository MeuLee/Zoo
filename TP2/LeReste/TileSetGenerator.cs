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
        public static int HEROS_UP_IDLE = 23;

        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static TileSetGenerator()
        {
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 6 });//TL_ALLEE
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 7 });//T_ALLEE
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 8 });//TR_ALLEE
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 6 });//CL_ALLEE
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 7 });//C_ALLEE
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 8 });//CR_ALLEE
            listeCoord.Add(new TileCoord() { Ligne = 11, Colonne = 6 });//BL_ALLEE
            listeCoord.Add(new TileCoord() { Ligne = 11, Colonne = 7 });//B_ALLEE
            listeCoord.Add(new TileCoord() { Ligne = 11, Colonne = 8 });//BR_ALLEE
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 9 });//TL_ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 10 });//T_ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 11 });//TR_ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 9 });//CL_ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 10 });//C_ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 11 });//CR_ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 9 });//BL_ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 10 });//B_ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 11 });//BR_ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 9 });//CLOTURE_ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 12 });//ENTREE
            listeCoord.Add(new TileCoord() { Ligne = 20, Colonne = 16 });//GRIZZLI
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 16 });//LICORNE
            listeCoord.Add(new TileCoord() { Ligne = 20, Colonne = 8 });//MOUTON
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 1 });//HEROS_UP_IDLE
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 4 });//HEROS_UP_WALK
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 0 });//HEROS_DOWN_IDLE
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 3 });//HEROS_DOWN_WALK
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 2 });//HEROS_LEFT_IDLE
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 5 });//HEROS_LEFT_WALK_1
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 6 });//HEROS_LEFT_WALK_2
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 9 });//HEROS_RIGHT_IDLE
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 7 });//HEROS_RIGHT_WALK_1
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 8 });//HEROS_RIGHT_WALK_2
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 1 });//V1_UP_IDLE
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 4 });//V1_UP_WALK
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 0 });//V1_DOWN_IDLE
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 3 });//V1_DOWN_WALK
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 2 });//V1_LEFT_IDLE
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 5 });//V1_LEFT_WALK_1
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 6 });//V1_LEFT_WALK_2
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 9 });//V1_RIGHT_IDLE
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 7 });//V1_RIGHT_WALK_1
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 8 });//V1_RIGHT_WALK_2


            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TL_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, T_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TR_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, CL_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, C_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, CR_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, BL_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, B_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, BR_ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TL_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, T_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TR_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, CL_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, C_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, CR_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, BL_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, B_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, BR_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, CLOTURE_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, ENTREE, 128, 160));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, GRIZZLI, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, LICORNE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, MOUTON, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, HEROS_UP_IDLE, 32, 32));
        }

        private static Bitmap LoadTile(Image source, int posListe, int width, int height)
        {
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

