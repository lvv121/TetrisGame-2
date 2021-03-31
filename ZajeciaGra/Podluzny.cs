namespace ZajeciaGra
{
    internal class Podluzny : Klocek
    {
        public Podluzny(int size = 5) : base(size)
        {
            for (int i = 0; i < size; i++)
            {
                shape[size / 2, i] = 1;
            }
        }
        public Podluzny() : base(5)
        {
            for (int i = 0; i < 5; i++)
            {
                shape[5 / 2, i] = 1;
            }
        }
    }
}
