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

        #region Décor
        public static int ENTREE = 0;
        public static int SORTIE = 1;
        public static int GAZON = 2;
        public static int PLANTE = 3;
        public static int TL_CLOTURE_ZOO = 4;
        public static int BL_CLOTURE_ZOO = 5;
        public static int TR_CLOTURE_ZOO = 6;
        public static int BR_CLOTURE_ZOO = 7;
        public static int T_CLOTURE_ZOO = 8;
        public static int L_CLOTURE_ZOO = 9;
        public static int B_CLOTURE_ZOO = 10;
        public static int R_CLOTURE_ZOO = 11;
        public static int ALLEE = 12;
        public static int WATER = 13;
        public static int ROCK = 14;
        public static int TB_CLOTURE_ENCLOS = 15;
        public static int RL_CLOTURE_ENCLOS = 16;
        public static int BR_CLOTURE_ENCLOS = 17;
        public static int FLEUR = 18;
        public static int NOURRITURE = 19;
        public static int TERRE = 20;
        public static int TERRE_VERTE = 21;
        public static int SABLE = 22;
        public static int PALMIER = 23;
        public static int GLACE_BLANCHE = 24;
        public static int GLACE_BLEU = 25;
        public static int NEIGE = 26;
        public static int SABLE_GAZON = 27;
        public static int FLAQUE = 28;
        public static int TRONC = 29;
        public static int PUIT = 30;
        #endregion

        #region Personnages
        //M
        public static int V1_DOWN_IDLE = 31;
        public static int V1_DOWN_WALK = 32;
        public static int V1_UP_IDLE = 33;
        public static int V1_UP_WALK = 34;
        public static int V1_LEFT_IDLE = 35;
        public static int V1_LEFT_WALK1 = 36;
        public static int V1_LEFT_WALK2 = 37;
        public static int V1_RIGHT_IDLE = 38;
        public static int V1_RIGHT_WALK1 = 39;
        public static int V1_RIGHT_WALK2 = 40;

        //M
        public static int V2_DOWN_IDLE = 41;
        public static int V2_DOWN_WALK = 42;
        public static int V2_UP_IDLE = 43;
        public static int V2_UP_WALK = 44;
        public static int V2_LEFT_IDLE = 45;
        public static int V2_LEFT_WALK1 = 46;
        public static int V2_LEFT_WALK2 = 47;
        public static int V2_RIGHT_IDLE = 48;
        public static int V2_RIGHT_WALK1 = 49;
        public static int V2_RIGHT_WALK2 = 50;

        //F
        public static int V3_DOWN_IDLE = 51;
        public static int V3_DOWN_WALK = 52;
        public static int V3_UP_IDLE = 53;
        public static int V3_UP_WALK = 54;
        public static int V3_LEFT_IDLE = 55;
        public static int V3_LEFT_WALK1 = 56;
        public static int V3_LEFT_WALK2 = 57;
        public static int V3_RIGHT_IDLE = 58;
        public static int V3_RIGHT_WALK1 = 59;
        public static int V3_RIGHT_WALK2 = 60;

        //F
        public static int V4_DOWN_IDLE = 61;
        public static int V4_DOWN_WALK = 62;
        public static int V4_UP_IDLE = 66;
        public static int V4_UP_WALK = 64;
        public static int V4_LEFT_IDLE = 65;
        public static int V4_LEFT_WALK1 = 66;
        public static int V4_LEFT_WALK2 = 67;
        public static int V4_RIGHT_IDLE = 68;
        public static int V4_RIGHT_WALK1 = 69;
        public static int V4_RIGHT_WALK2 = 70;
        #endregion

        #region Animaux
        public static int GRIZZLY = 71;
        public static int LICORNE = 72;
        public static int LION = 73;
        public static int MOUTON = 74;
        #endregion

        #region Concierge
        public static int C_DOWN_IDLE = 75;
        public static int C_DOWN_WALK = 76;
        public static int C_UP_IDLE = 77;
        public static int C_UP_WALK = 78;
        public static int C_LEFT_IDLE = 79;
        public static int C_LEFT_WALK1 = 80;
        public static int C_LEFT_WALK2 = 81;
        public static int C_RIGHT_IDLE = 82;
        public static int C_RIGHT_WALK1 = 83;
        public static int C_RIGHT_WALK2 = 84;
        #endregion

        #region Déchets
        public static int DECHET_1 = 85;
        public static int DECHET_2 = 86;
        #endregion
        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static TileSetGenerator()
        {
            #region Décor
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 13 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, ENTREE, 160, 96));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 30 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, SORTIE, 160, 96));
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 0 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, GAZON, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 11, Colonne = 19 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, PLANTE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 30 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TL_CLOTURE_ZOO, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 30 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, BL_CLOTURE_ZOO, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 23 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TR_CLOTURE_ZOO, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 23 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, BR_CLOTURE_ZOO, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 31 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, T_CLOTURE_ZOO, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 30 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, L_CLOTURE_ZOO, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 22 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, B_CLOTURE_ZOO, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 12, Colonne = 23 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, R_CLOTURE_ZOO, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 17 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, ALLEE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 2 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, WATER, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 29 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, ROCK, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 22 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TB_CLOTURE_ENCLOS, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 18 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, RL_CLOTURE_ENCLOS, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 31});
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, BR_CLOTURE_ENCLOS, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 12 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, FLEUR, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 22 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, NOURRITURE, 64, 32));
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 6 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TERRE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 6 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TERRE_VERTE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 4 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, SABLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 10 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, PALMIER, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 5 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, GLACE_BLANCHE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 4 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, GLACE_BLEU, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 30 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, NEIGE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 3 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, SABLE_GAZON, 96, 96));
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 0 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, FLAQUE, 96, 96));
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 25 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TRONC, 64, 64));
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 24 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, PUIT, 96, 96));
            #endregion

            #region Visiteurs
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 0 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V1_DOWN_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 3 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V1_DOWN_WALK, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 1 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V1_UP_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 4 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V1_UP_WALK, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 2 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V1_LEFT_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 5 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V1_LEFT_WALK1, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 6 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V1_LEFT_WALK2, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 7 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V1_RIGHT_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 8 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V1_RIGHT_WALK1, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 9 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V1_RIGHT_WALK2, 32, 32));

            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 0 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V2_DOWN_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 3 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V2_DOWN_WALK, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 1 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V2_UP_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 4 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V2_UP_WALK, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 2 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V2_LEFT_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 5 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V2_LEFT_WALK1, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 6 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V2_LEFT_WALK2, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 7 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V2_RIGHT_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 8 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V2_RIGHT_WALK1, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 9 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V2_RIGHT_WALK2, 32, 32));

            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 0 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_DOWN_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 3 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_DOWN_WALK, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 1 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_UP_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 4 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_UP_WALK, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 2 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_LEFT_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 5 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_LEFT_WALK1, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 6 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_LEFT_WALK2, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 7 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_RIGHT_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 8 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_RIGHT_WALK1, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 9 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_RIGHT_WALK2, 32, 32));

            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 0 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_DOWN_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 3 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_DOWN_WALK, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 1 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_UP_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 4 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_UP_WALK, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 2 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_LEFT_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 5 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_LEFT_WALK1, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 6 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_LEFT_WALK2, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 7 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_RIGHT_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 8 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_RIGHT_WALK1, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 9 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, V3_RIGHT_WALK2, 32, 32));
            #endregion

            #region Animaux
            listeCoord.Add(new TileCoord() { Ligne = 20, Colonne = 16 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, GRIZZLY, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 16 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, LICORNE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 24 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, LION, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 19, Colonne = 8 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, MOUTON, 32, 32));
            #endregion

            #region Concierge
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 0 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, C_DOWN_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 3 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, C_DOWN_WALK, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 1 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, C_UP_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 4 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, C_UP_WALK, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 2 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, C_LEFT_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 5 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, C_LEFT_WALK1, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 6 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, C_LEFT_WALK2, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 7 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, C_RIGHT_IDLE, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 8 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, C_RIGHT_WALK1, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 9 });
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, C_RIGHT_WALK2, 32, 32));
            #endregion

            #region Déchet
            listeCoord.Add(new TileCoord() { Ligne = 23, Colonne = 0 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, DECHET_1, 32, 32));
            listeCoord.Add(new TileCoord() { Ligne = 23, Colonne = 1 });
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, DECHET_2, 32, 32));
            #endregion

        }

        private static Bitmap LoadTile(Image source, int posListe, int width, int height)
        {
            TileCoord coord = listeCoord[posListe];
            Rectangle crop = new Rectangle(coord.Colonne * IMAGE_WIDTH, coord.Ligne * IMAGE_HEIGHT, width, height);

            var bmp = new Bitmap(crop.Width, crop.Height);

            using (var gr = Graphics.FromImage(bmp))
                gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);

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
