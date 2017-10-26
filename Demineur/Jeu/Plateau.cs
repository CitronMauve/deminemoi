using IHM;
using System;

namespace Jeu
{
    class Plateau
    {
        public Partie partie;

        public IReactions ireactions;

        public int largeur;
        public int hauteur;
        public Case[,] cases;

        public int mines;
        public int decouvertes;
        public int restantes;

        Random random = new Random();

        public Plateau(Partie partie, int largeur, int hauteur, int mines, IReactions ireactions)
        {
            this.largeur = largeur;
            this.hauteur = hauteur;

            this.ireactions = ireactions;

            cases = new Case[largeur, hauteur];

            this.partie = partie;

            this.mines = mines;
            this.decouvertes = 0;
            this.restantes = mines;

            int limit = 0;

            for (int i = 0; i < this.largeur; i++)
            {
                for (int j = 0; j < this.hauteur; j++)
                {
                    cases[i, j] = new Case(i, j, this, ireactions);

                    int n = hauteur - 1;
                    if (i > 0 && j > 0) Connecter(cases[i, j], cases[i - 1, j - 1]);
                    if (i > 0) Connecter(cases[i, j], cases[i - 1, j]);
                    if (j > 0) Connecter(cases[i, j], cases[i, j - 1]);
                    if (i > 0 && j < n) Connecter(cases[i, j], cases[i - 1, j + 1]);
                }
            }

            limit = this.mines;

            for (int i = 0; i < limit; i++)
            {
                int x = random.Next(0, largeur);
                int y = random.Next(0, hauteur);
                if (!cases[x, y].minee)
                {
                    cases[x, y].minee = true;
                }
                else
                {
                    limit++;
                }
            }
            partie.vue.ActualiserComptage(restantes);
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
            restantes = marquee ? restantes - 1 : restantes + 1;
            partie.vue.ActualiserComptage(restantes);
        }

        public bool TesterSiGagne()
        {
            return decouvertes + mines == largeur * hauteur;
        }
    }
}
