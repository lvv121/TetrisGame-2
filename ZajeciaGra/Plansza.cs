using System;

namespace ZajeciaGra
{
    public class Plansza
    {
        public int[,] Wymiary { get; }

        public Plansza(int x, int y)
        {
            Wymiary = new int[x, y];
        }

        public void Drukuj()
        {
            int x = Wymiary.GetLength(0);
            int y = Wymiary.GetLength(1);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (Wymiary[i, j] == 0)
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        Console.Write(Wymiary[i, j].ToString());
                    }
                }
                Console.Write("#\n");
            }
            for (int i = 0; i < y + 1; i++)
            {
                Console.Write("#");
            }

            Console.Write("\n\n");
        }

        public void WpisywanieKlocka(Klocek klocek)
        {
            int rozmiar = klocek.shape.GetLength(0);
            for (int i = 0; i < rozmiar; i++)
            {
                for (int j = 0; j < rozmiar; j++)
                {
                    if (klocek.shape[i, j] != 0)
                    {
                        Wymiary[klocek.PosX + i, klocek.PosY + j] = klocek.shape[i, j];
                    }
                }
            }
        }

        public void Zamroz(Klocek klocek)
        {
            int rozmiar = klocek.shape.GetLength(0);
            for (int i = 0; i < rozmiar; i++)
            {
                for (int j = 0; j < rozmiar; j++)
                {
                    if (klocek.shape[i, j] != 0)
                    {
                        Wymiary[klocek.PosX + i, klocek.PosY + j] = 2;
                    }
                }
            }
        }

        public void GlebokieCzyszczenie()
        {
            for (int i = 0; i < Wymiary.GetLength(0); i++)
            {
                for (int j = 0; j < Wymiary.GetLength(1); j++)
                {
                    Wymiary[i, j] = 0;
                }
            }
        }

        public void PlytkieCzyszczenie()
        {
            for (int i = 0; i < Wymiary.GetLength(0); i++)
            {
                for (int j = 0; j < Wymiary.GetLength(1); j++)
                {
                    if (Wymiary[i, j] == 1)
                    {
                        Wymiary[i, j] = 0;
                    }
                }
            }
        }

        public bool Kolizja(Klocek klocek, int x, int y)
        {
            int rozmiar = klocek.shape.GetLength(0);
            for (int i = 0; i < rozmiar; i++)
            {
                for (int j = 0; j < rozmiar; j++)
                {
                    if (klocek.shape[i, j] == 1)
                    {
                        if (x + i < 0 ||
                            x + i >= Wymiary.GetLength(0) ||
                            y + j < 0 ||
                            y + j >= Wymiary.GetLength(1) ||
                            Wymiary[x + i, y + j] == 2)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public int SprawdzPlansze()
        {
            int licznik = 0;
            for (int i = 0; i < Wymiary.GetLength(0); i++)
            {
                for (int j = 0; j < Wymiary.GetLength(1); j++)
                {
                    if (Wymiary[i, j] == 2)
                    {
                        licznik++;
                    }
                }
                if (licznik == Wymiary.GetLength(1))
                {
                    return i;
                }

                licznik = 0;
            }
            return -1; 
        }

        public int Przesuwanie(int linia = 10)
        {
            int level = SprawdzPlansze();
            int wynik = 1;
            while (level != -1)
            {
                for (int i = linia - 1; i >= 0; i--)
                {
                    for (int j = 0; j < Wymiary.GetLength(1); j++)
                    {
                        Wymiary[i + 1, j] = Wymiary[i, j];
                    }
                }
                level = SprawdzPlansze();
                wynik *= linia;
                linia++;
            }
            return wynik;
        }
    }
}

