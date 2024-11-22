namespace _22nov.Classes.Base
{
    internal abstract class Products
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }
        public bool onShop = false;
        public float ChoosePrice(float newPrice, float oldPrice)
        {
            Console.WriteLine("Choose Price");
            Console.WriteLine($"O - Old({oldPrice}) | N - New({newPrice})");
            bool oldOrNew = false;
            ConsoleKeyInfo key;
            bool loop = true;
            while (loop)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.O:
                        loop = false;
                        break;
                    case ConsoleKey.N:
                        oldOrNew = true;
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
            if (oldOrNew) return newPrice;
            else return oldPrice;
        }
    }
}
