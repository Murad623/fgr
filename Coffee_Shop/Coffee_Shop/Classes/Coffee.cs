using _Coffee_Shop.Classes.Base;
namespace _Coffee_Shop.Classes
{
    internal class Coffee : Products
    {
        public Coffee(string cName, double cPrice, int cCount, ref Products[] ProductsArr)
        {
            Type = "Coffee";
            Name = cName;
            Price = cPrice;
            Count = cCount;
        }
    }
}
