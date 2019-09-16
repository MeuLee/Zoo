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
            Image = TileSetGenerator.GetTile(TileSetGenerator.C_DOWN_IDLE);
            Zoo.ListeEntites.Add(this);
            TileSetSprite = 75;
        }

        /// <summary>
        /// Crée une liste de cases où le concierge peut aller. Sa prochaine case est déterminée selon:
        /// Si elle contient un déchet;
        /// Sinon, un random est effectué sur la liste et le concierge prend la nouvelle position.
        /// La direction sert à donner une image au concierge.
        /// </summary>
        internal new void DeplacerEtModifierImage()
        {
            List<KeyValuePair<TuileZoo, Direction>> casesDisponibles = DeterminerCasesDisponibles();
            if (casesDisponibles.Count != 0)
            {
                KeyValuePair<TuileZoo, Direction> caseDirection = DeterminerProchaineTuileSelonDechetsProches(casesDisponibles);
                TuileZoo prochaineTuile = caseDirection.Key;
                Position = prochaineTuile;
                ModifierImage(caseDirection.Value);
            }
        }

        /// <summary>
        /// Donne priorité à une case qui contient un déchet, donc si un concierge est à côté d'un déchet, il se déplacera dessus au lieu de se fier au random
        /// </summary>
        /// <param name="casesDisponibles">Les cases sur lesquelles </param>
        /// <returns>La prochaine case du concierge</returns>
        private KeyValuePair<TuileZoo, Direction> DeterminerProchaineTuileSelonDechetsProches(List<KeyValuePair<TuileZoo, Direction>> casesDisponibles)
        {
            foreach (KeyValuePair<TuileZoo, Direction> tuile in casesDisponibles.Where(t => t.Key.ContientDechet()))
            {
                return tuile;
            }
            return casesDisponibles[_r.Next(0, casesDisponibles.Count)];
        }

        /// <summary>
        /// Le concierge peut se déplacer sur les Tuiles Allée qui ne contiennent pas d'humains.
        /// Contrairement aux visiteurs, il peut se déplacer sur les cases qui contiennent un déchet.
        /// </summary>
        /// <param name="possibilite"></param>
        /// <returns></returns>
        protected override bool PeutSeDeplacer(TuileZoo possibilite)
        {
            if (Zoo.ListeEntites.OfType<Humain>().Where(e => e.Position == possibilite).Count() > 0)
                return false;

            return possibilite.Tuile == TuileZoo.TypeTuile.Allee;
        }
    }
}
