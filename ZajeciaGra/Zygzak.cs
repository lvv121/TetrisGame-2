namespace ZajeciaGra
{
    internal class Zygzak : Klocek
    {
        public Zygzak(int size = 3) : base(size)
        {
            for (int i = 0; i < size - 1; i++)
            {
                shape[0, i] = 1;
                shape[size / 2, size / 2] = 1;
                shape[size / 2, 2] = 1;
            }
        }
        public Zygzak() : base(3)
        {
            for (int i = 0; i < 3 - 1; i++)
            {
                shape[0, i] = 1;
                shape[3 / 2, 3 / 2] = 1;
                shape[3 / 2, 2] = 1;
            }
        }
    }
}
