namespace Jeu
{
    class Plateau
    {
        public Partie partie;

        public int largeur;
        public int hauteur;
        Case[,] cases;

        private int mines;
        private int decouvertes;
        private int restantes;

        public Case Trouver(int x, int y)
        {
            return cases[x, y];
        }

        public void IncrementerDecouvertes()
        {
            decouvertes++;
        }

        public void ModifierMarquees(bool marquee)
        {
            if (marquee)
            {
                restantes--;
            } else
            {
                restantes++;
            }

            partie.vue.ActualiserComptage(restantes);
        }

        public bool TesterSiGagne()
        {
            return decouvertes + mines == largeur * hauteur;
        }
    }
}
