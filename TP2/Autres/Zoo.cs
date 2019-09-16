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

        public static Heros Heros { get; set; }
        public static FrmZoo InstanceForm { get; internal set; }

        private static Random _r = new Random();
        private readonly int MILLISEC_SLEEP = 821;
        private const int DECHET_SPAWN_RATE = 200;


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
            lock (ListeEntites)
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
            ListeEnclos[0] = new Enclos(3, 6, Animal.TypeAnimal.Inexistant);
            ListeEnclos[1] = new Enclos(18, 6, Animal.TypeAnimal.Inexistant);
            ListeEnclos[2] = new Enclos(3, 16, Animal.TypeAnimal.Lion);
            ListeEnclos[3] = new Enclos(18, 16, Animal.TypeAnimal.Grizzly);
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
        /// -Accouple les animaux
        /// -Kick les visiteurs
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
                AccouplerAnimaux();

                Invoke((MethodInvoker)delegate ()
                {
                    Refresh();
                });
            }
        }

        internal static void ViellirEnfants()
        {
            foreach (Entite e in ListeEntites.OfType<Animal>().Where(a => a.Age == Animal.AgeAnimal.Bebe))
            {
                Animal a = e as Animal;
                switch (a.JoursJusquaAdulte)
                {
                    case 0:
                        a.Age = Animal.AgeAnimal.Adulte;
                        break;
                    default:
                        a.JoursJusquaAdulte--;
                        break;
                }
            }
        }

        /// <summary>
        /// Pour chaque animal enceinte, réduit le nombre de jours requis pour donner naissance de 1 ou si égal à 0, donne naissance.
        /// </summary>
        internal static void GestationnerAnimaux()
        {
            List<Animal> animauxDonnentNaissance = new List<Animal>();
            foreach (Entite e in ListeEntites.OfType<Animal>().Where(a => a.Enceinte))
            {
                Animal a = e as Animal;
                switch (a.JoursAvantNaissance)
                {
                    case 0:
                        animauxDonnentNaissance.Add(a);
                        break;
                    default:
                        a.JoursAvantNaissance--;
                        break;
                }
            }
           
            foreach (Animal a in animauxDonnentNaissance)
                a.DonnerNaissance();
        }

        private void AccouplerAnimaux()
        {
            foreach (Enclos en in ListeEnclos)
            {
                Animal femelle = en.ContientDeuxSexesAdultes();
                if (femelle != null)
                    femelle.Enceinte = true;
            }
        }

        /// <summary>
        /// Kick les visiteurs hors du Zoo si ça fait plus d'une minute qu'ils sont entrés et qu'ils sont sur la case de sortie.
        /// </summary>
        private void KickVisiteur()
        {
            Visiteur visiteurAEnlever = null;
            foreach (Entite e in ListeEntites.OfType<Visiteur>()
                                             .Where(v => v.QuandEntreZoo.AddMinutes(1) <= DateTime.Now
                                                      && v.Position == Terrain[26, 4]))
            {
                visiteurAEnlever = e as Visiteur;
                break;
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
                foreach (Entite f in ListeEntites.OfType<Dechet>().Where(f => f.Position == e.Position))
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
        /// Evenement clique du jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zoo_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    CliqueDroit(sender, e);
                    break;
                case MouseButtons.Left:
                    CliqueGauche(sender, e);
                    break;
            }
        }

        /// <summary>
        /// Affiche un message contenant les informations de l'entité cliquée, si la case contient une entité.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CliqueDroit(object sender, MouseEventArgs e)
        {
            FrmInfos infos = new FrmInfos();
            TuileZoo tuile = Terrain[e.X / 32, e.Y / 32];
            foreach (Entite entite in ListeEntites.Where(entite => entite.Position == tuile))
            {
                if (entite is Animal)
                {
                    Animal a = entite as Animal;                    
                    MontrerInformations(infos, a.Type.ToString(), a.Image, a.Sexe.ToString(), 
                                        a.Age.ToString(), a.Enceinte ? "Enceinte" : "Pas enceinte", 
                                        a.DerniereFoisNourri.AddMinutes(a.MinutesPourNourrir) > DateTime.Now ? "A mangé récemment" : "A faim depuis " + a.DerniereFoisNourri.ToShortTimeString());
                }
                else if (entite is Visiteur)
                {
                    Visiteur v = entite as Visiteur;
                    MontrerInformations(infos, v.Nom, v.Image, v.SexeVisiteur.ToString(), 
                                       (DateTime.Now - v.QuandEntreZoo).ToString());
                }
                else if (entite is Concierge)
                {
                    Concierge c = entite as Concierge;
                    MontrerInformations(infos, c.GetType().ToString(), c.Image);
                }
                break;
            }
        }

        /// <summary>
        /// Instancie les labels de la FrmInfos
        /// </summary>
        /// <param name="infos">La Form d'informations où le reste des paramètres seront affichés</param>
        /// <param name="nomEntite">Le nom de l'entité</param>
        /// <param name="image">Le bitmap de l'entité</param>
        /// <param name="sexe">Le sexe de l'entité</param>
        /// <param name="age">L'âge de l'entité</param>
        /// <param name="enceinte">Si l'entité est enceinte ou non (applicable aux animaux seulement)</param>
        /// <param name="faim">Si l'entité a faim ou non (applicable aux animaux seulement)</param>
        private void MontrerInformations (FrmInfos infos, string nomEntite, Bitmap image, string sexe = "", string age = "", string enceinte = "", string faim = "")
        {
            infos.LblType.Text = nomEntite;
            infos.PicImage.Image = image;
            infos.LblSexe.Text = sexe;
            infos.LblAge.Text = age;
            infos.LblEnceinte.Text = enceinte;
            infos.LblFaim.Text = faim;
            infos.Show();
        }



        /// <summary>
        /// Si la tuile cliquée est à côté du héros : 
        /// nourrit les animaux, ou ajoute un animal dans un enclos, ou ramasse les déchets, ou ajoute un concierge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CliqueGauche(object sender, MouseEventArgs e)
        {
            TuileZoo tuile = Terrain[e.X / 32, e.Y / 32];
            if (tuile.EstACoteDuHeros())
            {
                if (tuile.ContientAnimal())
                    NourrirAnimal(tuile);

                else if (tuile.EstDansQuelEnclos().HasValue && tuile.Tuile != TuileZoo.TypeTuile.Interdit)
                    AjouterAnimalDansEnclos(tuile.EstDansQuelEnclos().Value, tuile);

                else if (tuile.ContientDechet())
                    HerosRamasseDechet(tuile);

                else if (!tuile.ContientEntite() && tuile.Tuile == TuileZoo.TypeTuile.Allee)
                    new Concierge(tuile);
            }
        }

        /// <summary>
        /// Nourrit un animal et il émet le son approprié. Si le temps pour nourrir l'animal est écoulé, ça coûtera 2$ au lieu de 1$.
        /// </summary>
        /// <param name="tuile"></param>
        private void NourrirAnimal(TuileZoo tuile)
        {
            if (Heros.AAssezDArgent(1))
            {
                foreach (Entite e in ListeEntites.OfType<Animal>().Where(e => e.Position == tuile))
                {
                    Animal a = e as Animal;
                    Heros.Argent -= a.DerniereFoisNourri.AddMinutes(a.MinutesPourNourrir) > DateTime.Now ? 1 : 2;
                    a.DerniereFoisNourri = DateTime.Now;
                    a.EmettreSon();
                }
            }
        }

        /// <summary>
        /// Si le numéro d'enclos est 0 ou 1 : demande le type de l'animal que l'enclos contiendra/ajoute un animal dans l'enclos
        /// 2 ou 3 : ajoute un animal dans l'enclos.
        /// </summary>
        /// <param name="numEnclos">Le numéro de l'enclos où l'animal doit être ajouté</param>
        /// <param name="tuile">La tuile sur laquelle l'animal apparaîtra</param>
        private void AjouterAnimalDansEnclos(int numEnclos, TuileZoo tuile)
        {
            Enclos enclos = ListeEnclos[numEnclos];
            switch (numEnclos)
            {
                case 0:
                    goto case 1;
                case 1:
                    if (enclos.Espece == Animal.TypeAnimal.Inexistant)
                        ChoisirEtAcheterAnimal(tuile, enclos);
                    else
                        AcheterAnimal(enclos, enclos.PrixEspece, tuile, enclos.Espece);
                    break;
                case 2:
                    AcheterAnimal(enclos, Animal.PRIX_LION, tuile, Animal.TypeAnimal.Lion);
                    break;
                case 3:
                    AcheterAnimal(enclos, Animal.PRIX_GRIZZLY, tuile, Animal.TypeAnimal.Grizzly);
                    break;
            }
        }

        /// <summary>
        /// Methode pour la selection d'animal (licorne ou mouton)
        /// </summary>
        /// <param name="tuile"></param>
        /// <param name="enclos"></param>
        private void ChoisirEtAcheterAnimal(TuileZoo tuile, Enclos enclos)
        {
            ChoixAnimal choix = new ChoixAnimal();
            choix.ShowDialog();
            switch (choix.Selection)
            {
                case Animal.TypeAnimal.Licorne:
                    AcheterAnimal(enclos, Animal.PRIX_LICORNE, tuile, Animal.TypeAnimal.Licorne);
                    break;
                case Animal.TypeAnimal.Mouton:
                    AcheterAnimal(enclos, Animal.PRIX_MOUTON, tuile, Animal.TypeAnimal.Mouton);
                    break;
            }
        }

        /// <summary>
        /// Methode pour ajouter (acheter) un animal dans un enclos
        /// </summary>
        /// <param name="enclos"></param>
        /// <param name="prixAnimal"></param>
        /// <param name="tuile"></param>
        /// <param name="type"></param>
        private void AcheterAnimal(Enclos enclos, double prixAnimal, TuileZoo tuile, Animal.TypeAnimal type)
        {
            if (!tuile.ContientAnimal() && Heros.AAssezDArgent(prixAnimal))
            {
                enclos.Espece = type;
                enclos.PrixEspece = prixAnimal;
                enclos.AnimauxPresents.Add(new Animal(tuile, type));
            }
        }


        /// <summary>
        /// Le clique gauche sur une tuile adjacente au Héros enlève les déchets
        /// </summary>
        /// <param name="tuile">La tuile cliquée</param>
        private void HerosRamasseDechet(TuileZoo tuile)
        {
            Dechet dechetEntite = null;

            foreach (Entite entite in ListeEntites.OfType<Dechet>().Where(e => e.Position == tuile))
                dechetEntite = entite as Dechet;

            ListeEntites.Remove(dechetEntite);
        }
    }
}