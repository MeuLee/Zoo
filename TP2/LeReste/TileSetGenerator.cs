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

        public static int ENTREE = 0;
        public static int SORTIE = 1;
        public static int GRIZZLI = 2;
        public static int LICORNE = 3;
        public static int MOUTON = 4;
        public static int GAZON = 5;
        public static int HEROS = 6;
        public static int PLANTE = 7;

        //Cloture du zoo (T=top, B=bottom, L=left, R=right)
        public static int TL_CLOTURE_ZOO = 8;
        public static int BL_CLOTURE_ZOO = 9;
        public static int TR_CLOTURE_ZOO = 10;
        public static int BR_CLOTURE_ZOO = 11;
        public static int T_CLOTURE_ZOO = 12;
        public static int L_CLOTURE_ZOO = 13;
        public static int B_CLOTURE_ZOO = 14;
        public static int R_CLOTURE_ZOO = 15;

        public static int ALLEE = 16;
        public static int WATER = 17;
        public static int ROCK = 18;
        public static int TB_CLOTURE_ENCLOS = 19;
        public static int RL_CLOTURE_ENCLOS = 20;
        public static int BR_CLOTURE_ENCLOS = 21;
        public static int FLEUR = 22;
        public static int NOURRITURE = 23;
        public static int TERRE = 24;
        public static int TERRE_VERTE = 25;
        public static int SABLE = 26;
        public static int PALMIER = 27;
        public static int GLACE_BLANCHE = 28;
        public static int GLACE_BLEU = 29;
        public static int NEIGE = 30;
        public static int SABLE_GAZON = 31;
        public static int FLAQUE = 32;
        public static int TRONC = 33;
        public static int PUIT = 34;

        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static TileSetGenerator()
        {

            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 13 });
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 30 });
            listeCoord.Add(new TileCoord() { Ligne = 20, Colonne = 16 });
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 16 });
            listeCoord.Add(new TileCoord() { Ligne = 20, Colonne = 8 });
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 0 });
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 0 });
            listeCoord.Add(new TileCoord() { Ligne = 11, Colonne = 19 });

            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 30 });
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 30 });
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 23 });
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 23 });
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 31 });
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 30 });
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 22 });
            listeCoord.Add(new TileCoord() { Ligne = 12, Colonne = 23 });

            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 17 });
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 2 });
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 29 });
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 22 });
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 18 });
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 31});

            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 12 });
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 22 });
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 6 });
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 6 });
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 4 });
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 10 });
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 5 });
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 4 });
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 30 });
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 3 });
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 0 });
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 25 });
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 24 });


            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, ENTREE, 160, 96));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, SORTIE, 160, 96));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, GRIZZLI, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, LICORNE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, MOUTON, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, GAZON, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.personnages, HEROS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, PLANTE, 32, 32));

            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TL_CLOTURE_ZOO, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, BL_CLOTURE_ZOO, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TR_CLOTURE_ZOO, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, BR_CLOTURE_ZOO, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, T_CLOTURE_ZOO, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, L_CLOTURE_ZOO, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, B_CLOTURE_ZOO, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, R_CLOTURE_ZOO, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, ALLEE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, WATER, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, ROCK, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TB_CLOTURE_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, RL_CLOTURE_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, BR_CLOTURE_ENCLOS, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, FLEUR, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, NOURRITURE, 64, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TERRE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TERRE_VERTE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, SABLE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, PALMIER, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, GLACE_BLANCHE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, GLACE_BLEU, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, NEIGE, 32, 32));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, SABLE_GAZON, 96, 96));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, FLAQUE, 96, 96));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, TRONC, 64, 64));
            listeBitmap.Add(LoadTile(Properties.Resources.zoo_tileset, PUIT, 96, 96));
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

