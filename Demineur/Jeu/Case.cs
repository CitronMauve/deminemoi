using System.Collections.Generic;

namespace Jeu
{
    class Case
    {
        List<Case> voisines = new List<Case>();

        public bool minee;
        public bool marquee;
        public bool decouverte;
        
        public void Marquer()
        {

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
