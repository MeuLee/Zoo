using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2.LeReste
{
    public class TuileZoo  : Control
    {
        public bool ContientDechet { get; set; }
        public bool ContientAnimal { get; set; }
        public bool ContientVisiteur { get; set; }
        public bool EstSortie { get; set; }
        public TypeTuile Tuile { get; set; }

        public enum TypeTuile
        {

            Buisson,
            Roche,
            Cloture/*,
            ...*/
        }

    }
}
