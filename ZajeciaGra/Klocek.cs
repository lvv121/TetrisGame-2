using System;

namespace ZajeciaGra
{
    public class Klocek
    {
        private int posX, posY;
        public int[,] shape;

        public Klocek(int size)
        {
            shape = new int[size, size];
        }

        public int PosX => posX;

        public int PosY => posY;

        public int Width => shape.GetLength(1);

        public int Height => shape.GetLength(0);

        public void MoveDown()
        {
            posX++;
        }

        public void MoveRight()
        {
            posY++;
        }

        public void MoveLeft()
        {
            posY--;
        }

        private int[,] Rotate(bool clockDirection)
        {
            int rozmiar = shape.GetLength(0);

            int[,] wynik = new int[rozmiar, rozmiar];

            if (clockDirection)
            {
                for (int i = 0; i < rozmiar; i++)
                {
                    for (int j = 0; j < rozmiar; j++)
                    {
                        wynik[j, rozmiar - 1 - i] = shape[i, j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < rozmiar; i++)
                {
                    for (int j = rozmiar - 1; j >= 0; j--)
                    {
                        wynik[rozmiar - 1 - i, j] = shape[j, i];
                    }
                }
            }
            return wynik;
        }

        public void PokazNastepnyKlocek()
        {
            int rozmiar = shape.GetLength(0);
            Console.WriteLine("Następny\nklocek:");
            for (int i = 0; i < rozmiar; i++)
            {
                for (int j = 0; j < rozmiar; j++)
                {
                    if (shape[i, j] == 0)
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        Console.Write(shape[i, j].ToString());
                    }
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public void ObrotWPrawo(bool right)
        {
            shape = Rotate(right);
        }

        public void KlocekStart(int start)
        {
            posX = 0;
            posY = start;
        }
    }
}