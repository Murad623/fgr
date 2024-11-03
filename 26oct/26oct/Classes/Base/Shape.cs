namespace _26oct.Classes.Base
{
    public class Shape
    {
        protected string Name = string.Empty;
        public int sideAccount = 0;
        public int[] sides;
        public Shape(string name)
        {
            Name = name;
            //switch (name.ToLower()[1])
            //{
            //    case 't':
            //        sideAccount = 3;
            //        break;
            //    case 'c':
            //        sideAccount = 0;
            //        break;
            //    case 'r':
            //        sideAccount = 4;
            //        break;
            //    default:
            //        break;
            //}
        }
        public virtual double CalculateArea()
        {
            return 0;
        }
    }
}
