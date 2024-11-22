namespace _22nov.Classes.Base
{
    internal class Shop
    {
        public Products[] ProductsArr;
        public float TotalIncome;
        public string SellerName;
        public Shop(string cSellerName)
        {
            SellerName = cSellerName;
        }
        public void Menu()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                TopBar();
                Console.WriteLine("1 - Add Product");
                Console.WriteLine("2 - Sell Product");
                Console.WriteLine("3 - Product list");
                Console.WriteLine("ESC - quit");
                ConsoleKeyInfo key;
                bool loop2 = true;
                while (loop2)
                {
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            AddProduct();
                            loop2 = false;
                            break;
                        case ConsoleKey.D2:
                            SellProduct();
                            loop2 = false;
                            break;
                        case ConsoleKey.D3:
                            PrintProductList();
                            loop2 = false;
                            break;
                        case ConsoleKey.Escape:
                            loop2 = false;
                            loop = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void TopBar()
        {
            int width = Console.WindowWidth - (SellerName.Length + 5);
            for (int i = 0; i < 3; i++)
            {
                if (i != 1)
                {
                    Console.Write("+");
                    for (int j = 0; j < SellerName.Length + 2; j++) Console.Write("-");
                    Console.Write("+");
                    for (int j = 0; j < width; j++) Console.Write("-");
                    Console.Write("+\n");
                }
                else
                {
                    Console.Write($"| {SellerName} | Total in come : {TotalIncome}");
                    for (int j = 0; j < width - (TotalIncome.ToString().Length + "Total in come : ".Length + 1); j++) Console.Write(" ");
                    Console.WriteLine("|");
                }
            }
        }
        public void AddProduct()
        {
            Console.Clear();
            TopBar();
            Console.WriteLine("C - Coffee\nT - Tea\nESC - Quit");
            Products product;
            ConsoleKeyInfo key;
            bool loop = true;
            while (loop)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.C:
                        product = ProductCreator('C');
                        if(ProductsArr != null) Array.Resize(ref ProductsArr, ProductsArr.Length + 1);
                        else ProductsArr = new Products[1];
                        ProductsArr.Append(product);
                        loop = false;
                        break;
                    case ConsoleKey.T:
                        product = ProductCreator('T');
                        if (ProductsArr != null) Array.Resize(ref ProductsArr, ProductsArr.Length + 1);
                        else ProductsArr = new Products[1];
                        ProductsArr.Append(product);
                        loop = false;
                        break;
                    case ConsoleKey.Escape:
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void SellProduct()
        {
            Console.Clear();
            TopBar();
            Console.WriteLine("Prodoct name : ");
            string productName = Console.ReadLine();
            int count;
            while (true)
            {
                try
                {

                    Console.Clear();
                    TopBar();
                    Console.Write("Count : ");
                    count = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Number please");
                    Thread.Sleep(2000);
                }
            }
            for (int i = 0; i < ProductsArr.Length; i++)
            {
                if (ProductsArr[i].Name == productName)
                {
                    bool loop = true;
                    while (loop)
                    {

                        if (ProductsArr[i].Count <= count)
                        {
                            ProductsArr[i].Count -= count;
                            TotalIncome += count * ProductsArr[i].Price;
                        }
                        else
                        {
                            Console.Clear();
                            TopBar();
                            Console.WriteLine($"We have only {ProductsArr[i].Count}");
                            Console.WriteLine("S - Sell all | C - Change Count | ESC - Return to menu");
                            ConsoleKeyInfo key;
                            bool loop2 = true;
                            while (loop2)
                            {
                                key = Console.ReadKey();
                                switch (key.Key)
                                {
                                    case ConsoleKey.S:
                                        TotalIncome = ProductsArr[i].Count * ProductsArr[i].Price;
                                        Products[] newProductArr = new Products[ProductsArr.Length-1];
                                        for (int j = 0, k = 0; j < newProductArr.Length; j++)
                                        {
                                            if (j != i)
                                            {
                                                newProductArr[k] = ProductsArr[j];
                                                k++;
                                            }
                                        }
                                        ProductsArr = newProductArr;
                                        loop = false;
                                        loop2 = false;
                                        break;
                                    case ConsoleKey.C:
                                        int newCount;
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.Clear();
                                                TopBar();
                                                Console.Write("New count : ");
                                                newCount = int.Parse(Console.ReadLine());
                                                break;
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Number please");
                                                Thread.Sleep(2000);
                                            }
                                        }
                                        loop2 = false;
                                        if (newCount > ProductsArr[i].Count) break;
                                        loop = false;
                                        break;
                                    case ConsoleKey.Escape:
                                        loop = false;
                                        loop2 = false;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
        public Products ProductCreator(char type)
        {
            Console.Clear();
            TopBar();
            Console.Write("Product Name : ");
            string name = Console.ReadLine();
            float price;
            while (true)
            {
                try
                {
                    Console.Clear();
                    TopBar();
                    Console.Write("Product Price : ");
                    price = float.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Number please");
                    Thread.Sleep(2000);
                }
            }
            int count;
            while (true)
            {
                try
                {
                    Console.Clear();
                    TopBar();
                    Console.Write("Product Count : ");
                    count = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Number please");
                    Thread.Sleep(2000);
                }
            }
            if(type=='C') return new Coffee(name, price, count, ProductsArr);
            return new Tea(name, price, count, ProductsArr);
        }
        public void PrintProductList()
        {
            int nameLength = 0;
            int priceLength = 0;
            int countLength = 0;
            for (int i = 0; i < ProductsArr.Length; i++)
            {
                if (ProductsArr[i].Name.Length > nameLength) nameLength = ProductsArr[i].Name.Length;
                if (ProductsArr[i].Price.ToString().Length > nameLength) priceLength = ProductsArr[i].Price.ToString().Length;
                if (ProductsArr[i].Count.ToString().Length > nameLength) countLength = ProductsArr[i].Count.ToString().Length;
            }
            if ("Name".Length > nameLength) nameLength = "Name".Length;
            if ("Price".Length > nameLength) priceLength = "Price".Length;
            if ("Count".Length > nameLength) countLength = "Count".Length;
            for (int i = -1;i < ProductsArr.Length; i++)
            {
                if (i==-1)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (k != 1)
                        {
                            Console.Write("+");
                            for (int j = 0; j < nameLength + 2; j++) Console.Write("-");
                            Console.Write("+");
                            for (int j = 0; j < priceLength + 2; j++) Console.Write("-");
                            Console.Write("+");
                            for (int j = 0; j < countLength + 2; j++) Console.Write("-");
                            Console.Write("+");
                        }
                        else
                        {
                            int nameSpace = (nameLength - "Name".Length) / 2;
                            int priceSpace = (nameLength - "Price".Length) / 2;
                            int countSpace = (nameLength - "Count".Length) / 2;
                            Console.Write("|");
                            for (int j = 0; j < nameSpace; j++) Console.Write(" ");
                            Console.Write("Name");
                            for (int j = 0; j < nameSpace; j++) Console.Write(" ");
                            Console.Write("|");
                            for (int j = 0; j < priceSpace; j++) Console.Write(" ");
                            Console.Write("Price");
                            for (int j = 0; j < priceSpace; j++) Console.Write(" ");
                            Console.Write("|");
                            for (int j = 0; j < countSpace; j++) Console.Write(" ");
                            Console.Write("Count");
                            for (int j = 0; j < countSpace; j++) Console.Write(" ");
                            Console.Write("|");
                        }
                    }
                }
                else
                {
                    for (int k = 0, l = 0; k < ProductsArr.Length*2; k++)
                    {
                        if (k%2 == 1)
                        {
                            Console.Write("+");
                            for (int j = 0; j < nameLength + 2; j++) Console.Write("-");
                            Console.Write("+");
                            for (int j = 0; j < priceLength + 2; j++) Console.Write("-");
                            Console.Write("+");
                            for (int j = 0; j < countLength + 2; j++) Console.Write("-");
                            Console.Write("+");
                        }
                        else
                        {
                            int nameSpace = (nameLength - ProductsArr[l].Name.Length) / 2;
                            int priceSpace = (nameLength - ProductsArr[l].Price.ToString().Length) / 2;
                            int countSpace = (nameLength - ProductsArr[l].Count.ToString().Length) / 2;
                            Console.Write("|");
                            for (int j = 0; j < nameSpace; j++) Console.Write(" ");
                            Console.Write("Name");
                            for (int j = 0; j < nameSpace; j++) Console.Write(" ");
                            Console.Write("|");
                            for (int j = 0; j < priceSpace; j++) Console.Write(" ");
                            Console.Write("Price");
                            for (int j = 0; j < priceSpace; j++) Console.Write(" ");
                            Console.Write("|");
                            for (int j = 0; j < countSpace; j++) Console.Write(" ");
                            Console.Write("Count");
                            for (int j = 0; j < countSpace; j++) Console.Write(" ");
                            Console.Write("|");
                            l++;
                        }
                    }
                }
            }
        }
    }
}
