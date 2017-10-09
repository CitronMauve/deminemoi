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

        public Plateau()
        {

        }

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
            restantes = marquee ? restantes-- : restantes++;
            partie.vue.ActualiserComptage(restantes);
        }

        public bool TesterSiGagne()
        {
            return decouvertes + mines == largeur * hauteur;
        }
    }
}
