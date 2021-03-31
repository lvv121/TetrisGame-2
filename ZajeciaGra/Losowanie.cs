using System;

namespace ZajeciaGra
{
    internal class Losowanie
    {
        public char[][] tab;
        private readonly int rozmiar1, rozmiar2;

        private Losowanie(int rozmiar1, int rozmiar2)
        {
            this.rozmiar1 = rozmiar1;
            this.rozmiar2 = rozmiar2;
            tab = new char[rozmiar1][];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = new char[rozmiar2];
            }
        }

        private char LosowyZnak()
        {
            Random q = new Random();
            char let;
            int num = q.Next(0, 26);
            let = (char)('a' + num);
            return let;
        }

        private void WpiszPuste()
        {
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab[i].Length; j++)
                {
                    tab[i][j] = '-';
                }
            }
        }

        private void WpiszLosowyZnak()
        {
            Random q = new Random();
            for (int i = 0; i < rozmiar1; i++)
            {
                tab[0][q.Next(0, i)] = LosowyZnak();
            }
        }

        private void Drukuj()
        {
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab[i].Length; j++)
                {
                    Console.Write(tab[i][j]);
                }

                Console.Write("\n");
            }
        }

        private void Spadanie()
        {
            int row = tab.Length - 1;
            while (row != 0)
            {
                for (int i = tab.Length - 2; i >= 0; i--)
                {
                    for (int j = 0; j < tab[i].Length; j++)
                    {
                        tab[i + 1][j] = tab[i][j];
                    }
                }

                for (int i = 0; i < tab.Length; i++)
                {
                    for (int j = 0; j < tab[i].Length; j++)
                    {
                        tab[0][j] = '-';
                    }
                }

                Console.Write("\n");
                Drukuj();
                row--;
            }
        }
    }
}
