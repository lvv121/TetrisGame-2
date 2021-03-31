namespace ZajeciaGra
{
    internal class LiteraL : Klocek
    {
        public LiteraL(int size = 3) : base(size)
        {
            for (int i = 0; i < size; i++)
            {
                shape[i, size - 1] = 1;
                shape[0, i] = 1;
            }
        }
        public LiteraL() : base(3)
        {
            for (int i = 0; i < 3; i++)
            {
                shape[i, 3 - 1] = 1;
                shape[0, i] = 1;
            }
        }
    }

}
