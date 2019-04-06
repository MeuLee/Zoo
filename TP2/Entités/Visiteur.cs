﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.LeReste;

namespace TP2.Entités
{
    public class Visiteur : Humain
    {
        private static Random _r = new Random();

        public DateTime QuandEntreZoo { get; set; }
        public Sexe SexeVisiteur { get; set; }
        public string Nom { get; set; }

        public Visiteur(TuileZoo position, Bitmap image)
        {
            SexeVisiteur = (Sexe)_r.Next(0, 2);
            QuandEntreZoo = DateTime.Now;
            Position = position;
            //Image = random entre les 4
        }
    }

}
