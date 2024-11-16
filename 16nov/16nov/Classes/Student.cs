namespace _16nov.Classes
{
    internal class Student
    {
        string Name = string.Empty;
        int Age;
        int Grade;
        public Student()
        {
            Name = "Student";
            Age = 21;
            Grade = 4;
        }
        public Student(string cName, int cAge, int cGrade)
        {
            Name = cName;
            Age = cAge;
            Grade = cGrade;
        }
        public void PrintStudent()
        {
            Console.WriteLine($"Name : {Name}\nAge : {Age}\nGrade : {Grade}");
        }
    }
}
