using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.LeReste;

namespace TP2.Entités
{
    public class Concierge : Humain
    {
        public Concierge(TuileZoo position)
        {
            Position = position;
            //Image = ;
        }

        internal override void DeplacerEtModifierImage()
        {
            throw new NotImplementedException();
        }

        protected override bool PeutSeDeplacer(TuileZoo tuile)
        {
            throw new NotImplementedException();
        }
    }
}
