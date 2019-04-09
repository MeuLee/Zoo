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
        #region Locked size
        private Size DesiredSize = new Size(1025, 769);
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

        public TuileZoo[][] Terrain { get; set; }
        public List<Entite> EntitesPresentes { get; set; }

        #region OnPaint
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            DessinerCoins(g);
            DessinerBordures(g);
            DessinerCentre(g);
            DessinerEnclos(g);
        }

        private void DessinerCoins(Graphics g)
        {
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TL_ALLEE), 0, 0);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TR_ALLEE), 31 * 32, 0);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_ALLEE), 0, 23 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_ALLEE), 31 * 32, 23 * 32);
        }

        private void DessinerBordures(Graphics g)
        {
            for (int i = 1; i < 23; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.CL_ALLEE), 0, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.CR_ALLEE), 31 * 32, i * 32);
            }

            for (int i = 1; i < 31; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.T_ALLEE), i * 32, 0);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.B_ALLEE), i * 32, 23 * 32);
            }
        }

        private void DessinerCentre(Graphics g)
        {
            for (int i = 1; i < 31; i++)
                for (int j = 1; j < 23; j++)
                    g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.C_ALLEE), i * 32, j * 32);
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
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), i * 32, 3 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), i * 32, 13 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), i * 32, 10 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), i * 32, 20 * 32);
            }

            for (int i = 18; i < 29; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), i * 32, 3 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), i * 32, 13 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), i * 32, 10 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), i * 32, 20 * 32);
            }
            #endregion

            #region Cote
            for (int i = 4; i < 10; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), 3 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), 18 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), 13 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), 28 * 32, i * 32);
            }

            for (int i = 14; i < 20; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), 18 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), 3 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), 13 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BORDURE_ENCLOS), 28 * 32, i * 32);
            }
            #endregion
        }

        private void DessinerCentreEnclos(Graphics g)
        {
            for (int i = 5; i < 12; i++)
                for (int j = 5; j < 9; j++)
                    g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i * 32, j * 32);

            for (int i = 5; i < 12; i++)
                for (int j = 15; j < 19; j++)
                    g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i * 32, j * 32);

            for (int i = 20; i < 27; i++)
                for (int j = 5; j < 9; j++)
                    g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i * 32, j * 32);

            for (int i = 20; i < 27; i++)
                for (int j = 15; j < 19; j++)
                    g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i * 32, j * 32);
        }

        private void DessinerContoursEnclos(Graphics g)
        {
            #region Coins
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TL_ENCLOS), 4 * 32, 4 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TL_ENCLOS), 19 * 32, 4 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TL_ENCLOS), 4 * 32, 14 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TL_ENCLOS), 19 * 32, 14 * 32);

            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TR_ENCLOS), 12 * 32, 4 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TR_ENCLOS), 27 * 32, 4 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TR_ENCLOS), 12 * 32, 14 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TR_ENCLOS), 27 * 32, 14 * 32);

            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 4 * 32, 9 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 19 * 32, 9 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 4 * 32, 19 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 19 * 32, 19 * 32);

            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 12 * 32, 9 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 27 * 32, 9 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 12 * 32, 19 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 27 * 32, 19 * 32);
            #endregion

            #region Bordures
            for (int i = 5; i < 12; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.T_ENCLOS), i * 32, 4 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.T_ENCLOS), i * 32, 14 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), i * 32, 9 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), i * 32, 19 * 32);
            }

            for (int i = 20; i < 27; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.T_ENCLOS), i * 32, 4 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.T_ENCLOS), i * 32, 14 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), i * 32, 9 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), i * 32, 19 * 32);
            }

            for (int i = 5; i < 9; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.CL_ENCLOS), 4 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.CL_ENCLOS), 19 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.CR_ENCLOS), 12 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.CR_ENCLOS), 27 * 32, i * 32);
            }

            for (int i = 15; i < 19; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.CL_ENCLOS), 4 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.CL_ENCLOS), 19 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.CR_ENCLOS), 12 * 32, i * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.CR_ENCLOS), 27 * 32, i * 32);
            }
            #endregion
        }

        private void DessinerEntreesEnclos(Graphics g)
        {
            for (int i = 7; i < 10; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i * 32, 9 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i * 32, 19 * 32);
            }

            for (int i = 22; i < 25; i++)
            {
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i * 32, 9 * 32);
                g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.C_ENCLOS), i * 32, 19 * 32);
            }

            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 7 * 32, 10 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 22 * 32, 10 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 7 * 32, 20 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_ENCLOS), 22 * 32, 20 * 32);

            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), 8 * 32, 10 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), 23 * 32, 10 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), 8 * 32, 20 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.B_ENCLOS), 23 * 32, 20 * 32);

            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 9 * 32, 10 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 24 * 32, 10 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 9 * 32, 20 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_ENCLOS), 24 * 32, 20 * 32);

        }
        #endregion

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Zoo
            // 
            Size = new System.Drawing.Size(1024, 512);
            ResumeLayout(false);

        }
    }
}
