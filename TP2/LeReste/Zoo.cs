using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2.Entités;

namespace TP2.LeReste
{
    public class Zoo : Control
    {
        #region Taille fixe
        private Size DesiredSize = new Size(1025, 929);
        public override Size MinimumSize
        {
            get { return DesiredSize; }
            set { }
        }
        public override Size MaximumSize
        {
            get { return DesiredSize; }
            set { }
        }
        #endregion

        public static TuileZoo[,] Terrain { get; private set; }

        public List<Entite> EntitesPresentes { get; set; }

        public Enclos[] ListeEnclos { get; set; }

        #region OnPaint
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            DessinerGazon(g);
            DessinerEntreeSortie(g);
            DessinerAllee(g);
            DessinerClotureZoo(g);
            DessinerClotureEnclos(g);
            DessinerInterieurEnclos(g);

        }

        private void DessinerClotureEnclos(Graphics g)
        {

        }

        private void DessinerInterieurEnclos(Graphics g)
        {

        }

        private void DessinerAllee(Graphics g)
        {
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 5, 3, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 26, 3, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 7, 13, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 8, 13, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 9, 13, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 22, 13, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 23, 13, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 24, 13, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 7, 16, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 8, 16, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 9, 16, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 22, 16, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 23, 16, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), 24, 16, TuileZoo.TypeTuile.Allee);


            for (int i = 1; i < 31; i++)
            {
                for (int j = 4; j < 25; j++)
                {
                    if (!((i < 14 && i > 2 && j > 5 && j < 14) || (i < 29 && i > 17 && j > 5 && j < 14) || (i < 14 && i > 2 && j > 15 && j < 24) || (i < 29 && i > 17 && j > 15 && j < 24)))
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ALLEE), i, j, TuileZoo.TypeTuile.Allee);
                    }
                }
            }
        }

        private void DessinerClotureZoo(Graphics g)
        {
            //Les coins
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TL_CLOTURE_ZOO), 1 * 32, 3 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_CLOTURE_ZOO), 1 * 32, 25 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TR_CLOTURE_ZOO), 30 * 32, 3 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ZOO), 30 * 32, 25 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ZOO), 8 * 32, 3 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_CLOTURE_ZOO), 23 * 32, 3 * 32);

            //Le haut
            for (int i = 2; i < 30; i++)
            {
                if (!(i == 5 || i == 26 || (i < 24 && i > 7)))
                {
                    g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.T_CLOTURE_ZOO), i * 32, 3 * 32);
                }
            }

            //La gauche
            for (int j = 4; j < 25; j++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.L_CLOTURE_ZOO), 1 * 32, j * 32);
            }

            for (int j = 0; j < 3; j++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.L_CLOTURE_ZOO), 23 * 32, j * 32);
            }

            //Le bas
            for (int i = 2; i < 30; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.B_CLOTURE_ZOO), i * 32, 25 * 32);
            }

            //La droite
            for (int j = 4; j < 25; j++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.R_CLOTURE_ZOO), 30 * 32, j * 32);
            }

            for (int j = 0; j < 3; j++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.R_CLOTURE_ZOO), 8 * 32, j * 32);
            }
        }

        private void DessinerGazon(Graphics g)
        {
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.GAZON), i * 32, j * 32);
                }
            }

            for (int i = 0; i < 32; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.GAZON), i * 32, 3 * 32);
            }

            for (int i = 0; i < 32; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.GAZON), i * 32, 26 * 32);
            }

            for (int j = 3; j < 26; j++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.GAZON), 0 * 32, j * 32);
            }

            for (int j = 3; j < 26; j++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.GAZON), 31 * 32, j * 32);
            }
        }

        private void DessinerEntreeSortie(Graphics g)
        {
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.ENTREE), 3 * 32, 0 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.SORTIE), 24 * 32, 0 * 32);

            //Mot Zoo écrit avec les plantes
            for (int i = 9; i < 23; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!(i == 9 && j == 1 || i == 9 && j == 2 || i == 10 && j == 1 || i == 11 && j == 2 || i == 12 && j == 1 || i == 12 && j == 2
                        || i == 15 && j == 1 || i == 15 && j == 2 || i == 16 && j == 1 || i == 16 && j == 2 || i == 20 && j == 1 || i == 20 && j == 2
                        || i == 21 && j == 1 || i == 21 && j == 2 || i == 13 || i == 18))
                    {
                        g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.PLANTE), i * 32, j * 32);
                    }
                }
            }
        }

        private void DessinerUneImageEtInitialiserTerrain(Graphics g, Bitmap image, int x, int y, TuileZoo.TypeTuile typeTuile)
        {
            g.DrawImage(image, x * 32, y * 32);
            //Terrain[x, y] = new TuileZoo(typeTuile, x == 16 && y == 0);
        }

        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Zoo
            // 
            this.Size = new System.Drawing.Size(1024, 832);
            this.ResumeLayout(false);

        }

        public Zoo()
        {
            InitializeComponent();
            Terrain = new TuileZoo[32, 24];
            ListeEnclos = new Enclos[4];

            for (int i = 0; i < ListeEnclos.Length; i++)
                ListeEnclos[i] = new Enclos();
        }
    }
}
#endregion
