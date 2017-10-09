using System;
using IHM;

namespace Jeu
{
    public class Partie : IActions
    {
        Random rnd = new Random(); // à supprimer après le test
        Plateau plateau;

        public IReactions vue
        {
            get; set;
        }

        public void CommencerPartie(int largeur, int hauteur, int mines)
        {
            this.plateau = new Plateau(largeur, hauteur, vue);
        }

        public void DecouvrirCase(int x, int y)
        {
            // à supprimer après le test
            int i = rnd.Next(-1, 9);
            if (i == -1)
                vue.AfficherCaseMinee(x, y, true);
            else
                vue.AfficherCaseNumerotee(x, y, i);
        }

        public void MarquerCase(int x, int y)
        {
            Case casse = this.plateau.Trouver(x, y);
            casse.Marquer();
        }

        public void TerminerPartie()
        {

        }
    }
}
