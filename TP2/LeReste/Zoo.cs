using System;
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

        public static TuileZoo[,] Terrain { get; private set; } = new TuileZoo[32, 26];
        public static List<Entite> ListeEntites { get; set; } = new List<Entite>();
        public static Enclos[] ListeEnclos { get; set; } = new Enclos[4];

        public static Heros Heros { get; set; } = new Heros();

        private static Random _r = new Random();
        private const int MILLISEC_SLEEP = 500;


        #region OnPaint
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            DessinerGazon(g);
            DessinerEntreeSortie(g);
            DessinerAllee(g);
            DessinerClotureZoo(g);
            DessinerInterieurEnclos(g);
            DessinerClotureEnclos(g);
            DessinerEntites(g);
        }

        private void DessinerEntites(Graphics g)
        {
            if (Heros.Position == null)
                Heros.Position = Terrain[5,4];
            foreach (Entite e in ListeEntites)
                g.DrawImage(e.Image, e.Position.X * 32, e.Position.Y * 32);
        }

        private void DessinerClotureEnclos(Graphics g)
        {

            //Cloture enclos horizontaux
            for (int i = 3; i < 28; i++)
            {
                if (!(i < 18 && i > 12))
                {
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TB_CLOTURE_ENCLOS), i, 6, TuileZoo.TypeTuile.Interdit);
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TB_CLOTURE_ENCLOS), i, 23, TuileZoo.TypeTuile.Interdit);
                }
            }


            for (int i = 3; i < 28; i++)
            {
                if (!(i < 18 && i > 12 || i < 25 && i > 20 || i < 10 && i > 5))
                {
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TB_CLOTURE_ENCLOS), i, 13, TuileZoo.TypeTuile.Interdit);
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TB_CLOTURE_ENCLOS), i, 16, TuileZoo.TypeTuile.Interdit);
                }
            }


            //Clotures enclos verticaux
            for (int j = 6; j < 23; j++)
            {
                if (!(j < 16 && j > 12))
                {
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.RL_CLOTURE_ENCLOS), 3, j, TuileZoo.TypeTuile.Interdit);
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.RL_CLOTURE_ENCLOS), 13, j, TuileZoo.TypeTuile.Interdit);
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.RL_CLOTURE_ENCLOS), 18, j, TuileZoo.TypeTuile.Interdit);
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.RL_CLOTURE_ENCLOS), 28, j, TuileZoo.TypeTuile.Interdit);
                }
            }


            //Les coins en bas a droite
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ENCLOS), 13, 13, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ENCLOS), 28, 13, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ENCLOS), 13, 23, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ENCLOS), 28, 23, TuileZoo.TypeTuile.Interdit);

            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ENCLOS), 6, 13, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ENCLOS), 21, 13, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ENCLOS), 6, 16, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ENCLOS), 21, 16, TuileZoo.TypeTuile.Interdit);

        }

        private void DessinerInterieurEnclos(Graphics g)
        {
            //Enclos 1
            for (int i = 3; i < 14; i++)
            {
                for (int j = 6; j < 14; j++)
                {
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GAZON), i, j, TuileZoo.TypeTuile.Gazon);
                }
            }

            //Fleurs, nourriture, plantes
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.NOURRITURE), 4, 7, TuileZoo.TypeTuile.Decoration);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.PUIT), 4, 10, TuileZoo.TypeTuile.Decoration);

            for (int j = 7; j < 10; j++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.FLEUR), 12, j, TuileZoo.TypeTuile.Decoration);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.FLEUR), 11, j, TuileZoo.TypeTuile.Decoration);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.FLEUR), 10, j, TuileZoo.TypeTuile.Decoration);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.FLEUR), 9, j, TuileZoo.TypeTuile.Decoration);
            }

            for (int j = 7; j < 11; j++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.PLANTE), 8, j, TuileZoo.TypeTuile.Decoration);
            }

            for (int i = 9; i < 13; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.PLANTE), i, 10, TuileZoo.TypeTuile.Decoration);
            }

            //Enclos 2
            for (int i = 18; i < 29; i++)
            {
                for (int j = 6; j < 14; j++)
                {
                    if (!(i == 22 && j > 5 && j < 13 || i == 23 && j > 5 && j < 13 || i == 24 && j > 5 && j < 13 || i > 24 && i < 29))
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TERRE_VERTE), i, j, TuileZoo.TypeTuile.Terre);
                    }
                    else
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TERRE), i, j, TuileZoo.TypeTuile.Terre);
                    }
                }
            }

            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.FLAQUE), 25, 7, TuileZoo.TypeTuile.Eau);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TRONC), 19, 11, TuileZoo.TypeTuile.Eau);

            //Enclos 3
            for (int i = 3; i < 14; i++)
            {
                for (int j = 16; j < 24; j++)
                {
                    if (!(j > 19 && i < 7))
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.SABLE), i, j, TuileZoo.TypeTuile.Sable);
                    }
                    else
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GAZON), i, j, TuileZoo.TypeTuile.Gazon);
                    }
                }
            }

            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.WATER), 4, 21, TuileZoo.TypeTuile.Eau);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.WATER), 5, 21, TuileZoo.TypeTuile.Eau);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.WATER), 4, 22, TuileZoo.TypeTuile.Eau);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.WATER), 5, 22, TuileZoo.TypeTuile.Eau);

            for (int i = 3; i < 8; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.PALMIER), i, 19, TuileZoo.TypeTuile.Decoration);
            }

            for (int j = 20; j < 24; j++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.PALMIER), 7, j, TuileZoo.TypeTuile.Decoration);
            }

            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.SABLE_GAZON), 10, 17, TuileZoo.TypeTuile.Sable);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.PALMIER), 11, 18, TuileZoo.TypeTuile.Eau);

            //Enclos 4
            for (int i = 18; i < 29; i++)
            {
                for (int j = 16; j < 24; j++)
                {
                    if (!((i < 27 && i > 19 && j < 22 && j > 17) || j == 16 || j == 23 || i == 18 || i == 28))
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.WATER), i, j, TuileZoo.TypeTuile.Eau);
                    }
                    else
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GLACE_BLANCHE), i, j, TuileZoo.TypeTuile.Glace);
                    }

                }
            }

            for (int i = 21; i < 26; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GLACE_BLEU), i, 19, TuileZoo.TypeTuile.Glace);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GLACE_BLEU), i, 20, TuileZoo.TypeTuile.Glace);
            }

            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GLACE_BLANCHE), 22, 17, TuileZoo.TypeTuile.Glace);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GLACE_BLANCHE), 23, 17, TuileZoo.TypeTuile.Glace);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GLACE_BLANCHE), 24, 17, TuileZoo.TypeTuile.Glace);

        }

        private void DessinerAllee(Graphics g)
        {
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
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TL_CLOTURE_ZOO), 1, 3, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_CLOTURE_ZOO), 1, 25, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TR_CLOTURE_ZOO), 30, 3, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ZOO), 30, 25, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ZOO), 8, 3, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_CLOTURE_ZOO), 23, 3, TuileZoo.TypeTuile.Interdit);

            //Le haut
            for (int i = 2; i < 30; i++)
            {
                if (!(i == 5 || i == 26 || (i < 24 && i > 7)))
                {
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.T_CLOTURE_ZOO), i, 3, TuileZoo.TypeTuile.Interdit);
                }
            }

            //La gauche
            for (int j = 4; j < 25; j++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.L_CLOTURE_ZOO), 1, j, TuileZoo.TypeTuile.Interdit);
            }

            for (int j = 0; j < 3; j++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.L_CLOTURE_ZOO),23, j, TuileZoo.TypeTuile.Interdit);
            }

            //Le bas
            for (int i = 2; i < 30; i++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.B_CLOTURE_ZOO), i, 25, TuileZoo.TypeTuile.Interdit);
            }

            //La droite
            for (int j = 4; j < 25; j++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.R_CLOTURE_ZOO), 30, j, TuileZoo.TypeTuile.Interdit);
            }

            for (int j = 0; j < 3; j++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.R_CLOTURE_ZOO), 8, j, TuileZoo.TypeTuile.Interdit);
            }
        }

        private void DessinerGazon(Graphics g)
        {
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GAZON), i, j, TuileZoo.TypeTuile.Gazon);
                }
            }
        }

        private void DessinerEntreeSortie(Graphics g)
        {
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ENTREE), 3, 0, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.SORTIE), 24, 0, TuileZoo.TypeTuile.Interdit);

            //Mot Zoo écrit avec les plantes
            for (int i = 9; i < 23; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!(i == 9 && j == 1 || i == 9 && j == 2 || i == 10 && j == 1 || i == 11 && j == 2 || i == 12 && j == 1 || i == 12 && j == 2
                        || i == 15 && j == 1 || i == 15 && j == 2 || i == 16 && j == 1 || i == 16 && j == 2 || i == 20 && j == 1 || i == 20 && j == 2
                        || i == 21 && j == 1 || i == 21 && j == 2 || i == 13 || i == 18))
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ROCK), i, j, TuileZoo.TypeTuile.Interdit);
                    }
                }
            }
        }

        private void DessinerUneImageEtInitialiserTerrain(Graphics g, Bitmap image, int x, int y, TuileZoo.TypeTuile typeTuile)
        {
            if (image == TileSetGenerator.GetTile(TileSetGenerator.TB_CLOTURE_ENCLOS))
            {
                g.DrawImage(image, x * 32 + 8, y * 32);
            }

            else if (image == TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ENCLOS))
            {
                g.DrawImage(image, x * 32 - 8, y * 32);
            }
            else
            {
                g.DrawImage(image, x * 32, y * 32);
            }

            Terrain[x, y] = new TuileZoo(typeTuile, x == 16 && y == 0, x, y);
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
#endregion
