using _22nov.Classes.Base;
Console.Write("Enter your seller name : ");
string SellerName = Console.ReadLine();
if (SellerName.Length == 0) SellerName = "Seller";
Shop shop = new Shop(SellerName);
shop.Menu();