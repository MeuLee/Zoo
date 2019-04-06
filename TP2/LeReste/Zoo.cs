using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Entités;

namespace TP2.LeReste
{
    public class Zoo
    {
        public TuileZoo[][] Terrain { get; set; }
        public List<Entite> EntitesPresentes { get; set; }
    }
}
