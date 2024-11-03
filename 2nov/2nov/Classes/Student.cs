namespace _2nov.Classes
{
    internal class Student
    {
        public string Name;
        int _grade;
        public int Grade {
            get { return _grade; }
            set 
            {
                if (value > 0) _grade = value;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter positive numbers only.");
                    Console.Write("Try again : ");
                    int newGr = 0;
                    while (true)
                    {
                        try
                        {
                            newGr = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.Write("Please enter numbers only : ");
                        }
                    }
                    Grade = newGr;
                }
            }
        }
        public Student(string cName, int cGrade)
        {
            Name = cName;
            Grade = cGrade;
        }
    }
}
