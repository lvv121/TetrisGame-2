namespace ZajeciaGra
{
    internal class Trojnik : Klocek
    {
        public Trojnik(int size = 3) : base(size)
        {
            for (int i = 0; i < size; i++)
            {
                shape[0, i] = 1;
                shape[size / 2, size / 2] = 1;
            }
        }
        public Trojnik() : base(3)
        {
            for (int i = 0; i < 3; i++)
            {
                shape[0, i] = 1;
                shape[3 / 2, 3 / 2] = 1;
            }
        }

    }
}
