namespace _Coffee_Shop.Classes.Base
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
            Console.WriteLine("1 - Coffee\n2 - Tea\nESC - Quit");
            Products product;
            ConsoleKeyInfo key;
            bool loop = true;
            while (loop)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        ProductCreator('C');
                        while(Console.ReadKey(true).Key != ConsoleKey.Escape) break;
                        loop = false;
                        break;
                    case ConsoleKey.D2:
                        ProductCreator('T');
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
                        if (count > 0) break;
                        Console.WriteLine("Count can only be a positive number");
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
                                Console.WriteLine("1 - Sell all\n2 - Change Count\nESC - Return to menu");
                                ConsoleKeyInfo key;
                                bool loop2 = true;
                                while (loop2)
                                {
                                    key = Console.ReadKey();
                                    switch (key.Key)
                                    {
                                        case ConsoleKey.D1:
                                            TotalIncome += ProductsArr[i].Count * ProductsArr[i].Price;
                                            ProductsArr[i].Count = 0;
                                            loop = false;
                                            loop2 = false;
                                            break;
                                        case ConsoleKey.D2:
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
        public void ProductCreator(char type)
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
                    if(price > 0) break;
                    Console.WriteLine("Price can only be a positive number");
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
                    if (count > 0) break;
                    Console.WriteLine("Count can only be a positive number");
                }
                catch (Exception)
                {
                    Console.WriteLine("Number please");
                    Thread.Sleep(2000);
                }
            }
            // --> Check store for same product
            bool isExist = false;
            bool defPrice = false;
            int index = 0;
            if (ProductsArr != null)
            {
                for (int i = 0; i < ProductsArr.Length; i++)
                {
                    if (ProductsArr[i].Name == name)
                    {
                        if (ProductsArr[i].Price != price) defPrice = true;
                        isExist = true;
                        index = i;
                    }
                }
            }
            if (!isExist)
            {
                if (ProductsArr != null) Array.Resize(ref ProductsArr, ProductsArr.Length + 1);
                else ProductsArr = new Products[1];
                Products product;
                if (type=='C') product = new Coffee(name, price, count, ref ProductsArr);
                else product = new Tea(name, price, count, ref ProductsArr);
                ProductsArr[ProductsArr.Length - 1] = product;
            }
            else
            {
                Console.WriteLine("This product already exist");
                Console.WriteLine($"Name : {ProductsArr[index].Name}\nPrice : {ProductsArr[index].Price}\nCount : {ProductsArr[index].Count}");
                Console.WriteLine("1 - Add | 2 - Skip");
                ConsoleKeyInfo key;
                bool loop = true;
                while (loop)
                {
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            double choosenPrice = price;
                            if (defPrice) choosenPrice = ChoosePrice(price, ProductsArr[index].Price);
                            ProductsArr[index].Price = choosenPrice;
                            ProductsArr[index].Count += count;
                            loop = false;
                            break;
                        case ConsoleKey.D2:
                            loop = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            // <--
        }
        public void PrintProductList()
        {
            Console.Clear();
            TopBar();
            if(ProductsArr != null)
            {
                Products[] Coffee = null;
                Products[] Tea = null;
                for (int i = 0; i < ProductsArr.Length; i++)
                {
                    if (ProductsArr[i].Type == "Coffee")
                    {
                        Array.Resize(ref Coffee, (Coffee == null ? 1 : Coffee.Length + 1));
                        Coffee[Coffee.Length-1] = ProductsArr[i];
                    }
                    else
                    {
                        Array.Resize(ref Tea, (Tea == null ? 1 : Tea.Length + 1));
                        Tea[Tea.Length - 1] = ProductsArr[i];
                    }
                }
                if (Coffee != null) PrintProds(Coffee);
                if (Tea != null) PrintProds(Tea);
            }
            else Console.WriteLine("The store is empty");
            Console.WriteLine("ESC - Quit");
            while (true) if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
        }
        public void PrintProds(Products[] Prods)
        {
            if(Prods != null)
            {
                int nameLength = 0;
                int priceLength = 0;
                int countLength = 0;
                for (int i = 0; i < Prods.Length; i++)
                {
                    if (Prods[i].Name.Length > nameLength) nameLength = Prods[i].Name.Length + 2;
                    if (Prods[i].Price.ToString().Length > priceLength) priceLength = Prods[i].Price.ToString().Length + 2;
                    if (Prods[i].Count.ToString().Length > countLength) countLength = Prods[i].Count.ToString().Length + 2;
                }
                if ("Name".Length + 2 > nameLength) nameLength = "Name".Length + 2;
                if ("Price".Length + 2 > priceLength) priceLength = "Price".Length + 2;
                if ("Count".Length + 2 > countLength) countLength = "Count".Length + 2;
                for (int i = -2, l = 0; i < Prods.Length; i++)
                {
                    if (i == -2)
                    {
                        int len = nameLength + priceLength + countLength + 2;
                        Console.Write("+");
                        for (int k = 0; k < len; k++) Console.Write("-");
                        Console.Write("+\n");
                        Console.Write("|");
                        for (int k = 0; k < (len - Prods[0].Type.Length)/2; k++) Console.Write(" ");
                        Console.Write(Prods[0].Type);
                        for (int k = 0; k < ((len - Prods[0].Type.Length)/2 + (len%2 != Prods[0].Type.Length%2 ? 1 : 0)); k++) Console.Write(" ");
                        Console.Write("|\n");
                    }
                    else if (i == -1)
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
                        int nameSpace = (nameLength - Prods[l].Name.Length) / 2;
                        int priceSpace = (priceLength - Prods[l].Price.ToString().Length) / 2;
                        int countSpace = (countLength - Prods[l].Count.ToString().Length) / 2;
                        Console.Write("|");
                        for (int j = 0; j < nameSpace; j++) Console.Write(" ");
                        Console.Write(Prods[l].Name);
                        for (int j = 0; j < nameSpace + (nameLength % 2 != Prods[l].Name.Length % 2 ? 1 : 0); j++) Console.Write(" ");
                        Console.Write("|");
                        for (int j = 0; j < priceSpace; j++) Console.Write(" ");
                        Console.Write(Prods[l].Price);
                        for (int j = 0; j < priceSpace + (priceLength % 2 != Prods[l].Price.ToString().Length % 2 ? 1 : 0); j++) Console.Write(" ");
                        Console.Write("|");
                        for (int j = 0; j < countSpace; j++) Console.Write(" ");
                        Console.Write(Prods[l].Count);
                        for (int j = 0; j < countSpace + (countLength % 2 != Prods[l].Count.ToString().Length % 2 ? 1 : 0); j++) Console.Write(" ");
                        Console.Write("|\n");
                        Console.Write("+");
                        for (int j = 0; j < nameLength; j++) Console.Write("-");
                        Console.Write("+");
                        for (int j = 0; j < priceLength; j++) Console.Write("-");
                        Console.Write("+");
                        for (int j = 0; j < countLength; j++) Console.Write("-");
                        Console.Write("+\n");
                        l++;
                    }
                }
            }
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
        public double ChoosePrice(double newPrice, double oldPrice)
        {
            Console.WriteLine("Choose Price");
            Console.WriteLine($"1 - Old({oldPrice})\n2 - New({newPrice})");
            bool oldOrNew = false;
            ConsoleKeyInfo key;
            bool loop = true;
            while (loop)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        loop = false;
                        break;
                    case ConsoleKey.D2:
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
