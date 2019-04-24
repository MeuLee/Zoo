﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static List<Entite> ListeEntites { get; set; } = new List<Entite>();
        public static Enclos[] ListeEnclos { get; set; } = new Enclos[4];

        public static Heros Heros { get; set; } = new Heros();

        private static Random _r = new Random();
        private const int MILLISEC_SLEEP = 500;


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
            DessinerEntites(g);
        }

        private void DessinerEntites(Graphics g)
        {
            if (Heros.Position == null)
                Heros.Position = Terrain[16, 0];
                
            foreach (Entite e in ListeEntites)
                g.DrawImage(e.Image, e.Position.X * 32, e.Position.Y * 32 + 160);
        }

        private void DessinerCiel(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(153, 204, 255));
            g.FillRectangle(brush, 0, 0, 32*32, 5*32);
        }

        private void DessinerEntree(Graphics g)
        {
            g.DrawImage(TileSetGenerator.GetTile(TileSetGenerator.ENTREE), 14*32, 0);
        }

        private void DessinerUneImageEtInitialiserTerrain(Graphics g, Bitmap image, int x, int y, TuileZoo.TypeTuile typeTuile)
        {
            g.DrawImage(image, x * 32, y * 32 + 160);//160 pour décaler de 5 cases vers le bas, soit ça ou on déplace chaque Y où cette méthode est appelée
            Terrain[x, y] = new TuileZoo(typeTuile, x == 16 && y == 0, x, y);
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
            this.SuspendLayout();
            // 
            // Zoo
            // 
            this.Size = new System.Drawing.Size(1024, 512);
            this.ResumeLayout(false);
        }

        public Zoo()
        {
            Terrain = new TuileZoo[32, 24];
            CreerEnclos();
            ListeEntites.Add(Heros);
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void CreerEnclos()
        {
            //les x et y seront à changer
            ListeEnclos[0] = new Enclos(3, 3);
            ListeEnclos[1] = new Enclos(18, 3);
            ListeEnclos[2] = new Enclos(3, 13);
            ListeEnclos[3] = new Enclos(18, 13);
        }

        public void CreerEtLancerThreadAnimaux()
        {
            Thread thread = new Thread(new ThreadStart(BoucleDeJeu))
            {
                IsBackground = true,
                Name = "Boucle de jeu"
            };
            thread.Start();
        }

        private void BoucleDeJeu()
        {
            for (int nbThreadLoops = 0; true; nbThreadLoops++)
            {
                Thread.Sleep(MILLISEC_SLEEP);

                if (nbThreadLoops * MILLISEC_SLEEP % 60000 == 0)
                {
                    //a chaque minute, seul defaut est si MILLISEC_SLEEP n'est pas un multiple de 60000
                    AjouterArgentSelonAnimauxEtDechets();
                }

                if (MoinsDeVisiteursQueDAnimaux() && _r.Next(0, 10) == 0)//une chance sur 10
                    CreerNouveauVisiteur();
                DeplacerAnimaux();
                DeplacerVisiteurs();
                //deplacer concierges
                //updater temps
                //dechets
                //breed
                Invoke((MethodInvoker)delegate ()
                {
                    Refresh();
                });
            }
        }

        /// <summary>
        /// Ajoute 1 dollar par animal présent dans le zoo, - 10c par déchet présent
        /// </summary>
        private void AjouterArgentSelonAnimauxEtDechets()
        {
            Heros.Argent += ListeEntites.OfType<Animal>().Count() - ListeEntites.OfType<Dechet>().Count() * 0.1;
        }

        /// <summary>
        /// </summary>
        /// <returns>True s'il y a plus d'animaux que de visiteurs, false sinon.</returns>
        private bool MoinsDeVisiteursQueDAnimaux()
        {
            return ListeEntites.OfType<Animal>().Count() > ListeEntites.OfType<Visiteur>().Count();
        }

        /// <summary>
        /// Déplace les visiteurs dans le tableau 2d (Refresh sera call plus tard).
        /// </summary>
        private void DeplacerVisiteurs()
        {
            foreach (Entite e in ListeEntites.OfType<Visiteur>())
            {
                if (e != null)
                {
                    Visiteur v = e as Visiteur;
                    v.DeplacerEtModifierImage();
                }
            }
        }

        /// <summary>
        /// Cree un nouveau visiteur et l'ajoute à la liste de visiteurs.
        /// </summary>
        private void CreerNouveauVisiteur()
        {
            Visiteur v = new Visiteur();
            ListeEntites.Add(v);
        }

        /// <summary>
        /// Déplace les animaux dans le tableau 2d (Refresh sera call plus tard).
        /// </summary>
        private void DeplacerAnimaux()
        {
            foreach (Entite e in ListeEntites.OfType<Animal>())
            {
                if (e != null)
                {
                    Animal a = e as Animal;
                    a.DeplacerEtModifierImage();
                }
            }
        }
    }
}
