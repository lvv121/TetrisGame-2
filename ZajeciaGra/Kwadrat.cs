namespace ZajeciaGra
{
    internal class Kwadrat : Klocek
    {
        public Kwadrat(int size = 2) : base(size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    shape[i, j] = 1;
                }
            }
        }
        public Kwadrat() : base(2)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    shape[i, j] = 1;
                }
            }
        }
    }
}
