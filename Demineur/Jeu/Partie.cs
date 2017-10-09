using System;
using System.Collections.Generic;
using System.Text;
using IHM;

namespace Jeu
{
    public class Partie : IActions
    {
        Random rnd = new Random(); // à supprimer après le test

        public IReactions vue
        {
            get; set;
        }

        public void CommencerPartie(int largeur, int hauteur, int mines)
        {

        }

        public void DecouvrirCase(int x, int y)
        {
            // à supprimer après le test
            int i = rnd.Next(-1, 9);
            if(i==-1)
                vue.AfficherCaseMinee(x, y, true);
            else
                vue.AfficherCaseNumerotee(x, y, i);
        }

        public void MarquerCase(int x, int y)
        {

        }

        public void TerminerPartie()
        {

        }
    }
}
