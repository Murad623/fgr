using _Coffee_Shop.Classes.Base;
namespace _Coffee_Shop.Classes
{
    internal class Tea : Products
    {
        public Tea(string cName, double cPrice, int cCount, ref Products[] ProductsArr)
        {
            Type = "Tea";
            Name = cName;
            Price = cPrice;
            Count = cCount;
        }
    }
}
