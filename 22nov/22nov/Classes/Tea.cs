using _22nov.Classes.Base;
namespace _22nov.Classes
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
