using IHM;
using System.Collections.Generic;

namespace Jeu
{
    class Case
    {
        public int x;
        public int y;

        public bool minee;
        public bool marquee;
        public bool decouverte;

        public Plateau plateau;
        public IReactions ireactions;

        public List<Case> connexion;

        public Case(int x, int y, Plateau plateau, IReactions ireactions)
        {
            this.x = x;
            this.y = y;
            this.plateau = plateau;
            this.ireactions = ireactions;
            this.connexion = new List<Case>();
        }
        
        public void Marquer()
        {
            this.marquee = true;
        }

        public void Decouvrir()
        {
            if (!decouverte)
            {
                decouverte = true;
                plateau.IncrementerDecouvertes();
                if (this.marquee)
                {
                    if (this.minee)
                    {
                        ireactions.AfficherCaseMinee(x, y, true);
                    }
                    else
                    {
                        ireactions.AfficherCaseMarquee(x, y);
                        ireactions.PartiePerdue();
                    }
                }
                else
                {
                    if (this.minee)
                    {
                        ireactions.AfficherCaseMinee(x, y, true);
                        ireactions.PartiePerdue();
                    }
                    else
                    {
                        ireactions.AfficherCaseNumerotee(x, y, CountMines());
                        if (CountMines() == 0)
                        {
                            DecouvrirCasesVoisine();
                        }
                    }
                }
            }
        }

        public void Afficher()
        {

        }

        private int CountMines()
        {
            int result = 0;
            foreach (Case casesVoisine in connexion)
            {
                if (casesVoisine.minee)
                {
                    ++result;
                }
            }
            this.decouverte = true;
            return result;
        }

        private void DecouvrirCasesVoisine()
        {
            foreach (Case caseVoisine in connexion)
            {
                if (!caseVoisine.marquee)
                    caseVoisine.Decouvrir();
            }
        }

        public void Connecter(Case c)
        {
            connexion.Add(c);
        }
    }
}
