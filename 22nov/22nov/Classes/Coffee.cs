using _22nov.Classes.Base;

namespace _22nov.Classes
{
    internal class Coffee : Products
    {
        bool defPrice;
        Products exCoffee;
        public Coffee(string cName, float cPrice, int cCount, Products[] ProductsArr)
        {
            if (ProductsArr != null)
            {
                foreach (Products item in ProductsArr)
                {
                    if (item.Name == cName)
                    {
                        onShop = true;
                        exCoffee = item;
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
                Console.WriteLine($"Name : {exCoffee.Name}\nPrice : {exCoffee.Price}\nCount : {exCoffee.Count}");
                Console.WriteLine("A - Add | S - Skip");
                ConsoleKeyInfo key;
                bool loop = true;
                while (loop)
                {
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.A:
                            float choosenPrice = cPrice;
                            if (defPrice) choosenPrice = ChoosePrice(cPrice, exCoffee.Price);
                            exCoffee.Price = choosenPrice;
                            exCoffee.Count += cCount;
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
