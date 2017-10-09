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

        public Plateau(int largeur, int hauteur)
        {
            this.largeur = largeur;
            this.hauteur = hauteur;

            cases = new Case[largeur, hauteur];

            fillCases();
        }

        private void fillCases()
        {
            for (int i = 0; i < this.largeur; i++)
            {
                for (int j = 0; j < this.hauteur; j++)
                {
                    cases[i, j] = new Case();

                    int n = hauteur - 1;
                    if (i > 0 && j > 0)
                    {
                        Connecter(cases[i, j], cases[i - 1, j - 1]);
                    } else if (i > 0)
                    {
                        Connecter(cases[i, j], cases[i - 1, j]);
                    } else if (j > 0)
                    {
                        Connecter(cases[i, j], cases[i, j - 1]);
                    } else
                    {
                        Connecter(cases[i, j], cases[i - 1, j + 1]);
                    }
                }
            }
        }

        private void Connecter(Case a, Case b)
        {
            a.Connecter(b);
            b.Connecter(b);
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
