using _16nov.Classes.Bases;

namespace _16nov.Classes
{
    internal class Circle : Shape
    {
        public override double GetArea(int r)
        {
            return r*r*Math.PI;
        }
    }
}
