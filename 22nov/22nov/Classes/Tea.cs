using _22nov.Classes.Base;
namespace _22nov.Classes
{
    internal class Tea : Products
    {
        bool defPrice;
        Products exTea;
        public Tea(string cName, double cPrice, int cCount, Products[] ProductsArr)
        {
            if(ProductsArr != null)
            {
                foreach (Products item in ProductsArr)
                {
                    if (item.Name == cName)
                    {
                        onShop = true;
                        exTea = item;
                        if (item.Price != cPrice) defPrice = true;
                        else defPrice = false;
                    }
                }
            }
            if (!onShop)
            {
                Name = cName;
                Price = cPrice;
                Count = cCount;
            }
            else
            {
                Console.WriteLine("This product already exist");
                Console.WriteLine($"Name : {exTea.Name}\nPrice : {exTea.Price}\nCount : {exTea.Count}");
                Console.WriteLine("A - Add | S - Skip");
                ConsoleKeyInfo key;
                bool loop = true;
                while (loop)
                {
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.A:
                            double choosenPrice = cPrice;
                            if (defPrice) choosenPrice = ChoosePrice(cPrice, exTea.Price);
                            exTea.Price = choosenPrice;
                            exTea.Count += cCount;
                            loop = false;
                            break;
                        case ConsoleKey.S:
                            loop = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
