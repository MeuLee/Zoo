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
        private Size DesiredSize = new Size(1025, 513);
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

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            DessinerCoins(g);
            //DessinerBordures(g);
            //DessinerCentre(g);
            //DessinerEnclos(g);
        }

        private void DessinerEnclos(Graphics g)
        {
            throw new NotImplementedException();
        }

        private void DessinerCentre(Graphics g)
        {
            throw new NotImplementedException();
        }

        private void DessinerBordures(Graphics g)
        {
            throw new NotImplementedException();
        }

        private void DessinerCoins(Graphics g)
        {
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TL_ALLEE), 0, 0);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.TR_ALLEE), 31 * 32, 0);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BL_ALLEE), 0, 15 * 32);
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.BR_ALLEE), 31 * 32, 15 * 32);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Zoo
            // 
            this.Size = new System.Drawing.Size(1024, 512);
            this.ResumeLayout(false);

        }
    }
}
