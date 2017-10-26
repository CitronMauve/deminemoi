using System;
using IHM;

namespace Jeu
{
    public class Partie : IActions
    {
        Random rnd = new Random(); // à supprimer après le test
        Plateau plateau;
        bool perdu;

        public IReactions vue
        {
            get; set;
        }

        public void CommencerPartie(int largeur, int hauteur, int mines)
        {
            this.plateau = new Plateau(this, largeur, hauteur, mines, vue);
            this.perdu = false;
        }

        public void DecouvrirCase(int x, int y)
        {
            int i = rnd.Next(-1, 9);
            Case caseactuel = plateau.Trouver(x, y);
            if (!caseactuel.marquee)
            {
                caseactuel.Decouvrir();
            }

            if (plateau.TesterSiGagne())
                vue.PartieGagnee();
        }

        public void MarquerCase(int x, int y)
        {
            Case caseactuel = plateau.Trouver(x, y);
            if (!caseactuel.marquee && !caseactuel.decouverte)
            {
                caseactuel.marquee = true;
                vue.MarquerCase(x, y, true);
                plateau.ModifierMarquees(true);
            }
            else
            {
                plateau.ModifierMarquees(false);
                caseactuel.marquee = false;
                vue.MarquerCase(x, y, false);
            }
        }

        public void TerminerPartie()
        {
            for (int x = 0; x < plateau.largeur; x++)
            {
                for (int y = 0; y < plateau.hauteur; y++)
                {
                    plateau.cases[x, y].Decouvrir();
                }
            }

        }
    }
}
