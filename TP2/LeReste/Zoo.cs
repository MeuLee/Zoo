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

        public List<Entite>  EntitesPresentes { get; set; }

        public Enclos[] ListeEnclos { get; set; }

        #region OnPaint
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            DessinerCoins(g);
            DessinerBordures(g);
            DessinerCentre(g);
            DessinerEnclos(g);
            DessinerCiel(g);
            DessinerEntree(g);
        }

        private void DessinerCiel(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(153, 204, 255));
            g.FillRectangle(brush, 0, 0, 32, 32);
        }

        private void DessinerEntree(Graphics g)
        {
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.ENTREE), 14*32, 0);
        }

        private void DessinerUneImageEtInitialiserTerrain(Graphics g, Bitmap image, int x, int y, TuileZoo.TypeTuile typeTuile)
        {
            g.DrawImage(image, x * 32, y * 32 + 160);//160 pour décaler de 5 cases vers le bas, soit ça ou on déplace chaque Y où cette méthode est appelée
            Terrain[x, y] = new TuileZoo(typeTuile, x == 16 && y == 0);
        }

        private void DessinerCoins(Graphics g)
        {
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TL_ALLEE), 0, 0, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TR_ALLEE), 31, 0, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_ALLEE), 0, 23, TuileZoo.TypeTuile.Allee);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_ALLEE), 31, 23, TuileZoo.TypeTuile.Allee);
        }

        private void DessinerBordures(Graphics g)
        {
            for (int i = 1; i < 23; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CL_ALLEE), 0, i, TuileZoo.TypeTuile.Allee);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CR_ALLEE), 31, i, TuileZoo.TypeTuile.Allee);
            }

            for (int i = 1; i < 31; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.T_ALLEE), i, 0, TuileZoo.TypeTuile.Allee);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.B_ALLEE), i, 23, TuileZoo.TypeTuile.Allee);
            }
        }

        private void DessinerCentre(Graphics g)
        {
            for (int i = 1; i < 31; i++)
                for (int j = 1; j < 23; j++)
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.C_ALLEE), i, j, TuileZoo.TypeTuile.Allee);
        }

        private void DessinerEnclos(Graphics g)
        {
            DessinerCloturesEnclos(g);
            DessinerCentreEnclos(g);
            DessinerContoursEnclos(g);
            DessinerEntreesEnclos(g);
        }

        private void DessinerCloturesEnclos(Graphics g)
        {
            #region Haut/bas
            for (int i = 3; i < 14; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), i, 3, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), i, 10, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), i, 13, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), i, 20, TuileZoo.TypeTuile.Cloture);
            }

            for (int i = 18; i < 29; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), i, 3, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), i, 10, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), i, 13, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), i, 20, TuileZoo.TypeTuile.Cloture);
            }
            #endregion

            #region Cote
            for (int i = 4; i < 10; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), 3, i, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), 13, i, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), 18, i, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), 28, i, TuileZoo.TypeTuile.Cloture);
            }

            for (int i = 14; i < 20; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), 3, i, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), 13, i, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), 18, i, TuileZoo.TypeTuile.Cloture);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CLOTURE_ENCLOS), 28, i, TuileZoo.TypeTuile.Cloture);
            }
            #endregion
        }

        private void DessinerCentreEnclos(Graphics g)
        {
            for (int i = 5; i < 12; i++)
            {
                for (int j = 5; j < 9; j++)
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i, j, TuileZoo.TypeTuile.Enclos);
                for (int j = 15; j < 19; j++)
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i, j, TuileZoo.TypeTuile.Enclos);
            }


            for (int i = 20; i < 27; i++)
            {
                for (int j = 5; j < 9; j++)
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i, j, TuileZoo.TypeTuile.Enclos);
                for (int j = 15; j < 19; j++)
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i, j, TuileZoo.TypeTuile.Enclos);
            }

        }

        private void DessinerContoursEnclos(Graphics g)
        {
            #region Coins
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TL_ENCLOS), 4, 4, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TL_ENCLOS), 19, 4, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TL_ENCLOS), 4, 14, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TL_ENCLOS), 19, 14, TuileZoo.TypeTuile.Enclos);

            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TR_ENCLOS), 12, 4, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TR_ENCLOS), 27, 4, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TR_ENCLOS), 12, 14, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TR_ENCLOS), 27, 14, TuileZoo.TypeTuile.Enclos);

            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 4, 9, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 19, 9, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 4, 19, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 19, 19, TuileZoo.TypeTuile.Enclos);

            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 12, 9, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 27, 9, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 12, 19, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 27, 19, TuileZoo.TypeTuile.Enclos);
            #endregion

            #region Bordures
            for (int i = 5; i < 12; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.T_ENCLOS), i, 4, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.T_ENCLOS), i, 14, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), i, 9, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), i, 19, TuileZoo.TypeTuile.Enclos);
            }

            for (int i = 20; i < 27; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.T_ENCLOS), i, 4, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.T_ENCLOS), i, 14, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), i, 9, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), i, 19, TuileZoo.TypeTuile.Enclos);
            }

            for (int i = 5; i < 9; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CL_ENCLOS), 4, i, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CL_ENCLOS), 19, i, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CR_ENCLOS), 12, i, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CR_ENCLOS), 27, i, TuileZoo.TypeTuile.Enclos);
            }

            for (int i = 15; i < 19; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CL_ENCLOS), 4, i, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CL_ENCLOS), 19, i, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CR_ENCLOS), 12, i, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.CR_ENCLOS), 27, i, TuileZoo.TypeTuile.Enclos);
            }
            #endregion
        }

        private void DessinerEntreesEnclos(Graphics g)
        {
            for (int i = 7; i < 10; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i, 9, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i, 19, TuileZoo.TypeTuile.Enclos);
            }

            for (int i = 22; i < 25; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i, 9, TuileZoo.TypeTuile.Enclos);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i, 19, TuileZoo.TypeTuile.Enclos);
            }

            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 7, 10, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 22, 10, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 7, 20, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 22, 20, TuileZoo.TypeTuile.Enclos);

            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), 8, 10, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), 23, 10, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), 8, 20, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), 23, 20, TuileZoo.TypeTuile.Enclos);

            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 9, 10, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 24, 10, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 9, 20, TuileZoo.TypeTuile.Enclos);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 24, 20, TuileZoo.TypeTuile.Enclos);
        }
        #endregion

        public void InitializeComponent()
        {
            SuspendLayout();
            //
            // Zoo
            //
            Size = new Size(1024, 512);
            ResumeLayout(false);
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
