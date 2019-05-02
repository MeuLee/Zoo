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
        public Concierge()
        {
            Position = Zoo.Heros.Position;
            Image = TileSetGenerator.GetTile(TileSetGenerator.C_DOWN_IDLE);
            Zoo.ListeEntites.Add(this);
        }

        internal void DeplacerEtModifierImage()
        {
            List<KeyValuePair<TuileZoo, Direction>> casesDisponibles = DeterminerCasesDisponibles();
            if (casesDisponibles.Count != 0)
            {
                var caseDirection = casesDisponibles[_r.Next(0, casesDisponibles.Count)];
                TuileZoo prochaineTuile = caseDirection.Key;
                prochaineTuile.ContientHumain = true;
                Position = prochaineTuile;
                //ModifierImage(caseDirection.Value);
            }
        }

        private List<KeyValuePair<TuileZoo, Direction>> DeterminerCasesDisponibles()
        {
            var casesDisponibles = new List<KeyValuePair<TuileZoo, Direction>>();
            if (Position.X != 0)
                AjouterCaseAListe(Zoo.Terrain[Position.X - 1, Position.Y], casesDisponibles, Direction.Left);
            if (Position.Y != 0)
                AjouterCaseAListe(Zoo.Terrain[Position.X, Position.Y - 1], casesDisponibles, Direction.Up);
            if (Position.X != Zoo.Terrain.GetLength(0) - 1)
                AjouterCaseAListe(Zoo.Terrain[Position.X + 1, Position.Y], casesDisponibles, Direction.Right);
            if (Position.Y != Zoo.Terrain.GetLength(1) - 1)
                AjouterCaseAListe(Zoo.Terrain[Position.X, Position.Y + 1], casesDisponibles, Direction.Down);
            return casesDisponibles;
        }

        private void AjouterCaseAListe(TuileZoo possibilite, List<KeyValuePair<TuileZoo, Direction>> casesDisponibles, Direction d)
        {
            if (PeutSeDeplacer(possibilite))
                casesDisponibles.Add(new KeyValuePair<TuileZoo, Direction>(possibilite, d));
        }

        private bool PeutSeDeplacer(TuileZoo possibilite)
        {
            foreach (Entite e in Zoo.ListeEntites.OfType<Humain>())
            {
                if (e.Position.X == possibilite.X && e.Position.Y == possibilite.Y)
                    return false;
            }
            return possibilite.Tuile == TuileZoo.TypeTuile.Allee;
        }
    }
}
