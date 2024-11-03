namespace _2nov.Classes
{
    internal class Rectangle
    {
        public int Width;
        public int Height;
        int _area;
        public int Area { get { return _area; } }
        public Rectangle(int cWidth, int cHeight)
        {
            Width = cWidth;
            Height = cHeight;
        }
        public int CalArea()
        {
            _area = Width*Height;
            return _area;
        }
    }
}
