namespace _22nov.Classes.Base
{
    internal class Shop
    {
        public Products[] ProductsArr;
        public double TotalIncome;
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
                        //ProductsArr.Append(product);
                        ProductsArr[ProductsArr.Length - 1] = product;
                        loop = false;
                        break;
                    case ConsoleKey.T:
                        product = ProductCreator('T');
                        if (ProductsArr != null) Array.Resize(ref ProductsArr, ProductsArr.Length + 1);
                        else ProductsArr = new Products[1];
                        //ProductsArr.Append(product);
                        ProductsArr[ProductsArr.Length - 1] = product;
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
            if (ProductsArr != null)
            {
                Console.Write("Prodoct name : ");
                string productName = Console.ReadLine();
                bool isExist = false;
                foreach (Products item in ProductsArr) if (item.Name == productName) isExist = true;
                if (!isExist)
                {
                    Console.WriteLine("The product is not available in store");
                    return;
                }
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

                            if (ProductsArr[i].Count >= count)
                            {
                                ProductsArr[i].Count -= count;
                                TotalIncome += count * ProductsArr[i].Price;
                                loop = false;
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
                                            TotalIncome += ProductsArr[i].Count * ProductsArr[i].Price;
                                            ProductsArr[i].Count = 0;
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
                            if (ProductsArr[i].Count == 0) DeleteProduct(ref ProductsArr, ProductsArr[i]);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The store is empty");
                Console.WriteLine("ESC - Quit");
                while (true) if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
            }
        }
        public Products ProductCreator(char type)
        {
            Console.Clear();
            TopBar();
            Console.Write("Product Name : ");
            string name = Console.ReadLine();
            double price;
            while (true)
            {
                try
                {
                    Console.Clear();
                    TopBar();
                    Console.Write("Product Price : ");
                    price = double.Parse(Console.ReadLine());
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
            Console.Clear();
            TopBar();
            if(ProductsArr != null)
            {

                int nameLength = 0;
                int priceLength = 0;
                int countLength = 0;
                for (int i = 0; i < ProductsArr.Length; i++)
                {
                    if (ProductsArr[i].Name.Length > nameLength) nameLength = ProductsArr[i].Name.Length + 2 ;
                    if (ProductsArr[i].Price.ToString().Length > priceLength) priceLength = ProductsArr[i].Price.ToString().Length + 2;
                    if (ProductsArr[i].Count.ToString().Length > countLength) countLength = ProductsArr[i].Count.ToString().Length + 2;
                }
                if ("Name".Length > nameLength) nameLength = "Name".Length + 2;
                if ("Price".Length > priceLength) priceLength = "Price".Length + 2;
                if ("Count".Length > countLength) countLength = "Count".Length + 2;
                for (int i = -1;i < ProductsArr.Length; i++)
                {
                    if (i==-1)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (k != 1)
                            {
                                Console.Write("+");
                                for (int j = 0; j < nameLength; j++) Console.Write("-");
                                Console.Write("+");
                                for (int j = 0; j < priceLength; j++) Console.Write("-");
                                Console.Write("+");
                                for (int j = 0; j < countLength; j++) Console.Write("-");
                                Console.Write("+\n");
                            }
                            else
                            {
                                int nameSpace = (nameLength - "Name".Length) / 2;
                                int priceSpace = (priceLength - "Price".Length) / 2;
                                int countSpace = (countLength - "Count".Length) / 2;
                                Console.Write("|");
                                for (int j = 0; j < nameSpace; j++) Console.Write(" ");
                                Console.Write("Name");
                                for (int j = 0; j < nameSpace + (nameLength % 2 != "Name".Length % 2 ? 1 : 0); j++) Console.Write(" ");
                                Console.Write("|");
                                for (int j = 0; j < priceSpace; j++) Console.Write(" ");
                                Console.Write("Price");
                                for (int j = 0; j < priceSpace + (priceLength % 2 != "Price".Length % 2 ? 1 : 0); j++) Console.Write(" ");
                                Console.Write("|");
                                for (int j = 0; j < countSpace; j++) Console.Write(" ");
                                Console.Write("Count");
                                for (int j = 0; j < countSpace + (countLength % 2 != "Count".Length % 2 ? 1 : 0); j++) Console.Write(" ");
                                Console.Write("|\n");
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
                                for (int j = 0; j < nameLength; j++) Console.Write("-");
                                Console.Write("+");
                                for (int j = 0; j < priceLength; j++) Console.Write("-");
                                Console.Write("+");
                                for (int j = 0; j < countLength; j++) Console.Write("-");
                                Console.Write("+\n");
                            }
                            else
                            {
                                int nameSpace = (nameLength - ProductsArr[l].Name.Length) / 2;
                                int priceSpace = (nameLength - ProductsArr[l].Price.ToString().Length) / 2;
                                int countSpace = (nameLength - ProductsArr[l].Count.ToString().Length) / 2;
                                Console.Write("|");
                                for (int j = 0; j < nameSpace; j++) Console.Write(" ");
                                Console.Write(ProductsArr[l].Name);
                                for (int j = 0; j < nameSpace + (nameLength % 2 != ProductsArr[l].Name.Length % 2 ? 1 : 0); j++) Console.Write(" ");
                                Console.Write("|");
                                for (int j = 0; j < priceSpace; j++) Console.Write(" ");
                                Console.Write(ProductsArr[l].Price);
                                for (int j = 0; j < priceSpace + (priceLength % 2 != ProductsArr[l].Price.ToString().Length % 2 ? 1 : 0); j++) Console.Write(" ");
                                Console.Write("|");
                                for (int j = 0; j < countSpace; j++) Console.Write(" ");
                                Console.Write(ProductsArr[l].Count);
                                for (int j = 0; j < countSpace + (countLength % 2 != ProductsArr[l].Count.ToString().Length % 2 ? 1 : 0); j++) Console.Write(" ");
                                Console.Write("|\n");
                                l++;
                            }
                        }
                    }
                }
            }
            else Console.WriteLine("The store is empty");
            Console.WriteLine("ESC - Quit");
            while (true) if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
        }
        public void DeleteProduct(ref Products[] prodArrRef, Products prod)
        {
            Products[] newProductArr = new Products[prodArrRef.Length - 1];
            for (int j = 0, k = 0; j < newProductArr.Length; j++)
            {
                if (prodArrRef[j] != prod)
                {
                    newProductArr[k] = prodArrRef[j];
                    k++;
                }
            }
            prodArrRef = newProductArr;
        }
    }
}
