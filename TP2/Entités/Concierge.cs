﻿using System;
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
        public Concierge()
        {
            Position = Zoo.Heros.Position;
            Image = TileSetGenerator.GetTile(TileSetGenerator.C_DOWN_IDLE);
            Zoo.ListeEntites.Add(this);
            TileSetSprite = 75;
        }

        internal new void DeplacerEtModifierImage()
        {
            List<KeyValuePair<TuileZoo, Direction>> casesDisponibles = DeterminerCasesDisponibles();
            if (casesDisponibles.Count != 0)
            {
                KeyValuePair<TuileZoo, Direction> caseDirection = DeterminerProchaineTuileSelonDechetsProches(casesDisponibles);
                TuileZoo prochaineTuile = caseDirection.Key;
                prochaineTuile.ContientHumain = true;
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
            foreach (KeyValuePair<TuileZoo, Direction> tuile in casesDisponibles)
            {
                if (tuile.Key.ContientDechet())
                {
                    return tuile;
                }
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
            foreach (Entite e in Zoo.ListeEntites.OfType<Humain>())
                if (e.Position == possibilite)
                    return false;

            return /*!possibilite.ContientHumain &&*/ possibilite.Tuile == TuileZoo.TypeTuile.Allee;
        }
    }
}
