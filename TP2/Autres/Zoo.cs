using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using TP2.Entités;

namespace TP2.LeReste
{
    public class Zoo : Control
    {
        #region Taille fixe
        private Size DesiredSize = new Size(1025, 833);
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

        public static bool partieCommence = false;
        public static Heros Heros { get; set; }

        private static Random _r = new Random();
        private const int MILLISEC_SLEEP = 822;
        private const int DECHET_SPAWN_RATE = 100;


        #region OnPaint
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            DessinerGazon(g);
            DessinerEntreeSortie(g);
            DessinerMotZoo(g);
            DessinerAllee(g);
            DessinerClotureZoo(g);
            DessinerInterieurEnclos(g);
            DessinerClotureEnclos(g);
            DessinerEntites(g);
        }

        private void DessinerEntites(Graphics g)
        {
            foreach (Entite e in ListeEntites)
                g.DrawImage(e.Image, e.Position.X * 32, e.Position.Y * 32);
        }

        /// <summary>
        /// Dessine les clotures des enclos
        /// </summary>
        /// <param name="g"></param>
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

        /// <summary>
        /// Dessine l'interieur des enclos
        /// </summary>
        /// <param name="g"></param>
        private void DessinerInterieurEnclos(Graphics g)
        {
            //Enclos 1
            for (int i = 3; i < 14; i++)
            {
                for (int j = 6; j < 14; j++)
                {
                    if (!(j == 10 && i > 3 && i < 7 || j == 11 && i > 3 && i < 7 || j == 12 && i > 3 && i < 7 || j == 7 && i == 5))
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GAZON), i, j, TuileZoo.TypeTuile.Gazon);
                    }
                    else
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GAZON), i, j, TuileZoo.TypeTuile.Interdit);
                    }

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

            for (int i = 25; i < 28; i++)
            {
                for (int j = 7; j < 10; j++)
                {
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TERRE_VERTE), i, j, TuileZoo.TypeTuile.Interdit);
                }
            }

            for (int i = 19; i < 21; i++)
            {
                for (int j = 11; j < 13; j++)
                {
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TERRE_VERTE), i, j, TuileZoo.TypeTuile.Interdit);
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
                if (i != 5)
                {
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.PALMIER), i, 19, TuileZoo.TypeTuile.Decoration);
                }

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

        /// <summary>
        /// Dessine les allees
        /// </summary>
        /// <param name="g"></param>
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

        /// <summary>
        /// Dessine la grande cloture du zoo
        /// </summary>
        /// <param name="g"></param>
        private void DessinerClotureZoo(Graphics g)
        {

            //Les coins
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TL_CLOTURE_ZOO), 1, 3, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_CLOTURE_ZOO), 1, 25, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.TR_CLOTURE_ZOO), 30, 3, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ZOO), 30, 25, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BR_CLOTURE_ZOO), 8, 3, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.BL_CLOTURE_ZOO), 23, 3, TuileZoo.TypeTuile.Interdit);

            //Haut et bas
            for (int i = 2; i < 30; i++)
            {
                if (!(i == 5 || i == 26 || (i < 24 && i > 7)))
                {
                    DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.T_CLOTURE_ZOO), i, 3, TuileZoo.TypeTuile.Interdit);
                }
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.B_CLOTURE_ZOO), i, 25, TuileZoo.TypeTuile.Interdit);
            }

            //Gauche et droite
            for (int j = 4; j < 25; j++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.L_CLOTURE_ZOO), 1, j, TuileZoo.TypeTuile.Interdit);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.R_CLOTURE_ZOO), 30, j, TuileZoo.TypeTuile.Interdit);
            }

            for (int j = 0; j < 3; j++)
            {
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.L_CLOTURE_ZOO), 23, j, TuileZoo.TypeTuile.Interdit);
                DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.R_CLOTURE_ZOO), 8, j, TuileZoo.TypeTuile.Interdit);
            }
        }

        /// <summary>
        /// Dessine le gazon dans les endroits appropries
        /// </summary>
        /// <param name="g"></param>
        private void DessinerGazon(Graphics g)
        {
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (!(i > 2 && i < 8 && j < 3 || i > 23 && i < 29 && j < 3))
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GAZON), i, j, TuileZoo.TypeTuile.Gazon);
                    }
                    else
                    {
                        DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.GAZON), i, j, TuileZoo.TypeTuile.Interdit);
                    }

                }
            }
        }

        /// <summary>
        /// Dessine la porte d'entree et de sortie
        /// </summary>
        /// <param name="g"></param>
        private void DessinerEntreeSortie(Graphics g)
        {
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.ENTREE), 3, 0, TuileZoo.TypeTuile.Interdit);
            DessinerUneImageEtInitialiserTerrain(g, TileSetGenerator.GetTile(TileSetGenerator.SORTIE), 24, 0, TuileZoo.TypeTuile.Interdit);
        }

        /// <summary>
        /// Dessine le mot zoo en haut de la map (ecrit avec des roches)
        /// </summary>
        /// <param name="g"></param>
        private void DessinerMotZoo(Graphics g)
        {
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

        /// <summary>
        /// Pour chaque tuile, la methode la dessine et l'ajoute dans le tableau de tuile Terrain
        /// </summary>
        /// <param name="g"></param>
        /// <param name="image"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="typeTuile"></param>
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

            Terrain[x, y] = new TuileZoo(typeTuile, x, y);
        }
        #endregion


        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Zoo
            // 
            this.Size = new System.Drawing.Size(1024, 832);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zoo_MouseDown);
            this.ResumeLayout(false);

        }

        public Zoo()
        {
            CreerEnclos();
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Initialise les enclos avec leur position respective
        /// </summary>
        private void CreerEnclos()
        {
            ListeEnclos[0] = new Enclos(3, 6);
            ListeEnclos[0].Espece = Animal.TypeAnimal.Inexistant;
            ListeEnclos[0].AnimauxPresents = new List<Animal>();
            ListeEnclos[1] = new Enclos(18, 6);
            ListeEnclos[1].Espece = Animal.TypeAnimal.Inexistant;
            ListeEnclos[1].AnimauxPresents = new List<Animal>();
            ListeEnclos[2] = new Enclos(3, 16);
            ListeEnclos[2].AnimauxPresents = new List<Animal>();
            ListeEnclos[3] = new Enclos(18, 16);
            ListeEnclos[3].AnimauxPresents = new List<Animal>();
        }

        #region Thread
        /// <summary>
        /// Démarre le thread de jeu
        /// </summary>
        public void CreerEtLancerThreadAnimaux()
        {
            Thread thread = new Thread(new ThreadStart(BoucleDeJeu))
            {
                IsBackground = true,
                Name = "Boucle de jeu"
            };
            thread.Start();
        }

        /// <summary>
        /// -Spawn les visiteurs
        /// -Déplace les visiteurs
        /// -Spawn les déchets
        /// -Déplace les concierges
        /// -Ramasse les déchets
        /// -Déplace les animaux
        /// -
        /// </summary>
        private void BoucleDeJeu()
        {
            while (true)
            {
                Thread.Sleep(MILLISEC_SLEEP);

                if (_r.Next(0, 10) == 0 && MoinsDeVisiteursQueDAnimaux())//une chance sur 10
                    new Visiteur();

                List<TuileZoo> listeNouveauxDechets = DeplacerVisiteursEtCreerDechets();

                if (listeNouveauxDechets.Count > 0)
                    SpawnDechets(listeNouveauxDechets);

                DeplacerConcierges();
                RamasserDechets();
                DeplacerAnimaux();
                KickVisiteur();
                //breed

                Invoke((MethodInvoker)delegate ()
                {
                    Refresh();
                });
            }
        }

        /// <summary>
        /// Kick les visiteurs hors du Zoo si ça fait plus d'une minute qu'ils sont entrés et qu'ils sont sur la case de sortie.
        /// </summary>
        private void KickVisiteur()
        {
            Visiteur visiteurAEnlever = null;
            foreach (Entite e in ListeEntites.OfType<Visiteur>().Where(v => v.QuandEntreZoo.AddMinutes(1) <= DateTime.Now))
            {
                if (e.Position == Terrain[26, 4])
                {
                    visiteurAEnlever = e as Visiteur;
                    break;
                }
            }
            ListeEntites.Remove(visiteurAEnlever);
        }

        /// <summary>
        /// Crée un nouveau déchet à l'emplacement spécifié
        /// </summary>
        /// <param name="listeNouveauxDechets"></param>
        private void SpawnDechets(List<TuileZoo> listeNouveauxDechets)
        {
            foreach (TuileZoo emplacementDechet in listeNouveauxDechets)
                new Dechet(emplacementDechet);
        }

        /// <summary>
        /// Enlève les déchets de la ListeEntite qui ont la même position qu'un concierge
        /// </summary>
        private void RamasserDechets()
        {
            List<Dechet> dechetsAEnlever = new List<Dechet>();

            foreach (Entite e in ListeEntites.OfType<Concierge>())
                foreach (Entite f in ListeEntites.OfType<Dechet>())
                    if (e.Position == f.Position)
                        dechetsAEnlever.Add(f as Dechet);

            foreach (Dechet d in dechetsAEnlever)
                ListeEntites.Remove(d);
        }

        /// <summary>
        /// Déplace les concierges dans le tableau 2d (Refresh sera call plus tard).
        /// </summary>
        private void DeplacerConcierges()
        {
            foreach (Entite e in ListeEntites.OfType<Concierge>())
                (e as Concierge).DeplacerEtModifierImage();
        }

        /// <returns>True s'il y a plus d'animaux que de visiteurs, false sinon.</returns>
        private bool MoinsDeVisiteursQueDAnimaux()
        {
            return ListeEntites.OfType<Animal>().Count() > ListeEntites.OfType<Visiteur>().Count();
        }

        /// <summary>
        /// Déplace les visiteurs dans le tableau 2d (Refresh sera call plus tard).
        /// </summary>
        /// <returns>Une liste de TuileZoo comprenant la position des nouveaux déchets</returns>        
        private List<TuileZoo> DeplacerVisiteursEtCreerDechets()
        {
            List<TuileZoo> emplacementsDechet = new List<TuileZoo>();
            foreach (Entite e in ListeEntites.OfType<Visiteur>())
            {
                if (_r.Next(0, DECHET_SPAWN_RATE) == 0 && !e.Position.ContientDechet())
                    emplacementsDechet.Add(e.Position);
                (e as Visiteur).DeplacerEtModifierImage();
            }
            return emplacementsDechet;
        }

        /// <summary>
        /// Déplace les animaux dans le tableau 2d (Refresh sera call plus tard).
        /// </summary>
        private void DeplacerAnimaux()
        {
            foreach (Entite e in ListeEntites.OfType<Animal>())
                (e as Animal).Deplacer();
        }
        #endregion


        /// <summary>
        /// Methode pour ajouter (acheter) un animal dans un enclos
        /// </summary>
        /// <param name="enclos"></param>
        /// <param name="prixAnimal"></param>
        /// <param name="tuile"></param>
        /// <param name="type"></param>
        private void ajouterAnimal(Enclos enclos, double prixAnimal, TuileZoo tuile, Animal.TypeAnimal type)
        {
            if (!(verifierTuile(tuile)))
            {
                if (verifierAdjacent(tuile) && verifierPrixAnimal(prixAnimal))
                {
                    enclos.Espece = type;
                    enclos.prixEspece = prixAnimal;
                    enclos.AnimauxPresents.Add(new Animal(tuile, type));
                }
            }
        }

        /// <summary>
        /// Verifier si la tuile contient deja un animal, car si cest le cas, on ne pourrait pas ajouter un animal a cette position
        /// </summary>
        /// <param name="tuile"></param>
        /// <returns></returns>
        private bool verifierTuile(TuileZoo tuile)
        {
            bool tuileOccupe = false;

            for (int i = 0; i < ListeEntites.Count(); i++)
            {
                if (ListeEntites[i].Position == tuile)
                {
                    tuileOccupe = true;
                }
            }

            return tuileOccupe;
        }

        private void nourrirAnimal(TuileZoo tuile)
        {
            if (verifierAdjacent(tuile) && verifierTuile(tuile))
            {
                Animal animal;
                foreach (Entite e in ListeEntites.OfType<Animal>())
                {
                    animal = e as Animal;

                    if (verifierPrixAnimal(1))
                    {
                        switch (animal.Type)
                        {
                            case Animal.TypeAnimal.Mouton:
                                Heros.Argent -= 1;
                                animal.DerniereFoisNourri = DateTime.Now;
                                playMoutonSound();
                                break;
                            case Animal.TypeAnimal.Licorne:
                                Heros.Argent -= 1;
                                animal.DerniereFoisNourri = DateTime.Now;
                                playLicorneSound();
                                break;
                            case Animal.TypeAnimal.Lion:
                                Heros.Argent -= 1;
                                animal.DerniereFoisNourri = DateTime.Now;
                                playLionSound();
                                break;
                            case Animal.TypeAnimal.Grizzly:
                                Heros.Argent -= 1;
                                animal.DerniereFoisNourri = DateTime.Now;
                                playGrizzlySound();
                                break;
                        }
                    }

                }


            }

        }

        /// <summary>
        /// Son du lion
        /// </summary>
        private void playLionSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"lion.wav");
            simpleSound.Play();
        }

        /// <summary>
        /// Son du grizzly
        /// </summary>
        private void playGrizzlySound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"ours.wav");
            simpleSound.Play();
        }

        /// <summary>
        /// Son de la licorne
        /// </summary>
        private void playLicorneSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"licorne.wav");
            simpleSound.Play();
        }

        /// <summary>
        /// Son du mouton
        /// </summary>
        private void playMoutonSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"mouton.wav");
            simpleSound.Play();
        }


        /// <summary>
        /// Methode pour verifier si le clique est adjacent au heros
        /// </summary>
        /// <param name="tuile"></param>
        /// <returns></returns>
        private bool verifierAdjacent(TuileZoo tuile)
        {
            if (Terrain[tuile.X - 1, tuile.Y - 1] == Heros.Position || Terrain[tuile.X, tuile.Y + 1] == Heros.Position || Terrain[tuile.X + 1, tuile.Y + 1] == Heros.Position
                    || Terrain[tuile.X + 1, tuile.Y] == Heros.Position || Terrain[tuile.X + 1, tuile.Y - 1] == Heros.Position || Terrain[tuile.X, tuile.Y - 1] == Heros.Position
                    || Terrain[tuile.X - 1, tuile.Y - 1] == Heros.Position || Terrain[tuile.X - 1, tuile.Y] == Heros.Position)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Methode pour verifier le prix d'un animal ou le prix pour le nourrir
        /// </summary>
        /// <param name="prix"></param>
        /// <returns></returns>
        private bool verifierPrixAnimal(double prix)
        {
            if (Heros.Argent - prix < 0)
            {
                MessageBox.Show("Fonds insuffisants !");
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// Methode pour la selection d'animal (licorne ou mouton)
        /// </summary>
        /// <param name="tuile"></param>
        /// <param name="enclos"></param>
        private void selectionAnimal(TuileZoo tuile, Enclos enclos)
        {
            if (verifierAdjacent(tuile))
            {
                ChoixAnimal choix = new ChoixAnimal();
                choix.ShowDialog();

                if (choix.selection.Equals("Licorne"))
                {
                    ajouterAnimal(enclos, Animal.PRIX_LICORNE, tuile, Animal.TypeAnimal.Licorne);
                }
                else if (choix.selection.Equals("Mouton"))
                {
                    ajouterAnimal(enclos, Animal.PRIX_MOUTON, tuile, Animal.TypeAnimal.Mouton);
                }
            }
        }


        /// <summary>
        /// Evenement clique du jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zoo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cliqueDroit(sender, e);
            }

            if (e.Button == MouseButtons.Left)
            {
                cliqueGauche(sender, e);
            }
        }

        private void cliqueDroit(object sender, MouseEventArgs e)
        {
            
        }

        /// <summary>
        /// Methode pour le clique gauche (ajouter entite, nourrir animaux)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cliqueGauche(object sender, MouseEventArgs e)
        {
            //Avec l'endroit du clique, on peut savoir quel enclos a ete clique
            if (partieCommence)
            {
                TuileZoo tuile = Terrain[e.X / 32, e.Y / 32];
                nourrirAnimal(tuile);

                //Enclos 1              
                if (tuile.X > 2 && tuile.X < 14 && tuile.Y > 5 && tuile.Y < 14)
                {
                    //Verifier s'il n'y a pas deja un type d'animal dans l'enclos
                    if (ListeEnclos[0].Espece == Animal.TypeAnimal.Licorne || ListeEnclos[0].Espece == Animal.TypeAnimal.Mouton)
                    {
                        ajouterAnimal(ListeEnclos[0], ListeEnclos[0].prixEspece, tuile, ListeEnclos[0].Espece);
                    }
                    else
                    {
                        selectionAnimal(tuile, ListeEnclos[0]);
                    }

                }

                //Enclos 2
                else if (tuile.X > 17 && tuile.X < 29 && tuile.Y > 5 && tuile.Y < 14)
                {

                    //Verifier s'il n'y a pas deja un type d'animal dans l'enclos
                    if (ListeEnclos[1].Espece == Animal.TypeAnimal.Licorne || ListeEnclos[1].Espece == Animal.TypeAnimal.Mouton)
                    {
                        ajouterAnimal(ListeEnclos[1], ListeEnclos[1].prixEspece, tuile, ListeEnclos[1].Espece);
                    }
                    else
                    {
                        selectionAnimal(tuile, ListeEnclos[1]);
                    }

                }

                //Enclos 3
                else if (tuile.X > 2 && tuile.X < 14 && tuile.Y > 15 && tuile.Y < 24)
                {
                    ajouterAnimal(ListeEnclos[2], Animal.PRIX_LION, tuile, Animal.TypeAnimal.Lion);
                }

                //Enclos 4
                else if (tuile.X > 17 && tuile.X < 29 && tuile.Y > 15 && tuile.Y < 24)
                {
                    ajouterAnimal(ListeEnclos[3], Animal.PRIX_GRIZZLY, tuile, Animal.TypeAnimal.Grizzly);
                }

                //Concierge
                else if (verifierAdjacent(tuile))
                {
                    new Concierge();
                }
            }
        }
    }
}
