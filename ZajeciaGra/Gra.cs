using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ZajeciaGra
{
    public class Gra
    {
        private readonly int Cols = 12, Rows = 10;
        private int millisec;
        private bool test;
        public Plansza Plansza1 { get; private set; }
        private Klocek klocek;
        public Klocek nastepnyKlocek { get; private set; }
        private readonly Random random = new Random();
        private readonly List<Klocek> wszystkieKlocki;
        public bool Zyje { get; private set; } = true;
        public int Wynik { get; set; }

        public Gra()
        {
            Plansza1 = new Plansza(Cols, Rows);
            IEnumerable<Klocek> aux;
            aux = typeof(Klocek).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Klocek))).Select(t => (Klocek)Activator.CreateInstance(t));
            wszystkieKlocki = aux.Cast<Klocek>().ToList();
            nastepnyKlocek = wszystkieKlocki[random.Next(wszystkieKlocki.Count)];
            NowyKlocek();
        }

        private void NowyKlocek()
        {
            klocek = nastepnyKlocek;
            nastepnyKlocek = wszystkieKlocki[random.Next(wszystkieKlocki.Count)];
            klocek.KlocekStart(random.Next(Cols - klocek.Width - 1));
            if (Plansza1.Kolizja(klocek, 0, 0))
                Zyje = false;
        }

        public void Klatka(Keys key, bool wDol)
        {
            if (!Zyje)
            {
                return;
            }
            if (test || wDol)
            {
                Plansza1.PlytkieCzyszczenie();
                test = false;
            }
            if (wDol)
            {
                if (!Plansza1.Kolizja(klocek, klocek.PosX + 1, klocek.PosY))
                {
                    klocek.MoveDown();
                    Wynik++;
                    Plansza1.WpisywanieKlocka(klocek);
                }
                else
                {
                    Plansza1.Zamroz(klocek);
                    Wynik += Plansza1.Przesuwanie(Plansza1.Wymiary.GetLength(1));
                    Plansza1.Przesuwanie(Plansza1.SprawdzPlansze());
                    NowyKlocek();
                }
            }
            switch (key)
            {
                case Keys.Left:
                    if (!Plansza1.Kolizja(klocek, klocek.PosX, klocek.PosY - 1))
                    {
                        klocek.MoveLeft();
                        test = true;
                    }
                    break;

                case Keys.Right:
                    if (!Plansza1.Kolizja(klocek, klocek.PosX, klocek.PosY + 1))
                    {
                        klocek.MoveRight();
                        test = true;
                    }
                    break;

                case Keys.Up:
                    klocek.ObrotWPrawo(false);
                    if (!Plansza1.Kolizja(klocek, klocek.PosX, klocek.PosY))
                    {
                        test = true;
                    }
                    else
                    {
                        klocek.ObrotWPrawo(true);
                    }

                    break;

                case Keys.Down:
                    klocek.ObrotWPrawo(true);
                    if (!Plansza1.Kolizja(klocek, klocek.PosX, klocek.PosY))
                    {
                        test = true;
                    }
                    else
                    {
                        klocek.ObrotWPrawo(false);
                    }

                    break;
            }
        }
        public void RestartGry()
        {
            Wynik = 0;
            Zyje = true;
            Plansza1.GlebokieCzyszczenie();
        }




        public void Play()
        {
            Stopwatch watch = new Stopwatch();
            millisec = 1000;
            watch.Start();
            NowyKlocek();
            for (; ; )
            {
                if (watch.ElapsedMilliseconds > millisec)
                {
                    watch.Restart();
                    Plansza1.PlytkieCzyszczenie();
                    if (!Plansza1.Kolizja(klocek, klocek.PosX + 1, klocek.PosY))
                    {
                        klocek.MoveDown();
                        Plansza1.WpisywanieKlocka(klocek);
                    }
                    else
                    {
                        Plansza1.Zamroz(klocek);
                        Plansza1.Przesuwanie(Plansza1.SprawdzPlansze());
                        millisec = 1000;
                        NowyKlocek();
                    }
                    Console.Clear();
                    Plansza1.Drukuj();
                    nastepnyKlocek.PokazNastepnyKlocek();
                }
                if (Console.KeyAvailable)
                {
                    test = false;
                    ConsoleKeyInfo k = Console.ReadKey(true);
                    switch (k.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (!Plansza1.Kolizja(klocek, klocek.PosX, klocek.PosY - 1))
                            {
                                klocek.MoveLeft();
                                test = true;
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            if (!Plansza1.Kolizja(klocek, klocek.PosX, klocek.PosY + 1))
                            {
                                klocek.MoveRight();
                                test = true;
                            }
                            break;

                        case ConsoleKey.UpArrow:
                            klocek.ObrotWPrawo(false);
                            if (!Plansza1.Kolizja(klocek, klocek.PosX, klocek.PosY))
                            {
                                test = true;
                            }
                            else
                            {
                                klocek.ObrotWPrawo(true);
                            }

                            break;

                        case ConsoleKey.DownArrow:
                            klocek.ObrotWPrawo(true);
                            if (!Plansza1.Kolizja(klocek, klocek.PosX, klocek.PosY))
                            {
                                test = true;
                            }
                            else
                            {
                                klocek.ObrotWPrawo(false);
                            }

                            break;

                        case ConsoleKey.Spacebar:
                            millisec /= 2;
                            break;
                    }
                    if (test == false)
                    {
                        Console.Clear();
                    }
                }
            }
        }
    }
}