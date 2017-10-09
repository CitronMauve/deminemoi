using IHM;
using System.Collections.Generic;

namespace Jeu
{
    class Case
    {
        List<Case> voisines = new List<Case>();

        public int x;
        public int y;

        public bool minee;
        public bool marquee;
        public bool decouverte;

        public Plateau plateau;
        public IReactions ireactions;

        public Case(int x, int y, Plateau plateau, IReactions ireactions)
        {
            this.x = x;
            this.y = y;
            this.plateau = plateau;
            this.ireactions = ireactions;
        }
        
        public void Marquer()
        {
            this.marquee = !this.marquee;
            this.plateau.ModifierMarquees(this.marquee);
            this.ireactions.MarquerCase(this.x, this.y, this.marquee);
        }

        public void Decouvrir()
        {

        }

        public void Afficher()
        {

        }

        public void Connecter(Case c)
        {
            voisines.Add(c);
        }
    }
}
