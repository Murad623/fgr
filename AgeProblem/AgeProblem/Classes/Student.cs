namespace AgeProblem.Classes
{
    internal class Student
    {
        static int _Age = 0;
        public int Age = 0;
        public Student()
        {
            _Age++;
            Age = _Age;
        }
    }
}
