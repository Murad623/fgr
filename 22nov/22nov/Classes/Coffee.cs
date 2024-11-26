using _22nov.Classes.Base;
using System;
using System.Reflection;

namespace _22nov.Classes
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
