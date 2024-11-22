using _22nov.Classes.Base;
Console.Write("Enter your seller name : ");
string SellerName = Console.ReadLine();
Shop shop = new Shop(SellerName);
shop.Menu();