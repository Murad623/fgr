using _2nov.Classes.Bases;

namespace _2nov.Classes
{
    internal class Student2 : Person
    {
        public string University;
        public Student2(string cName, int cAge, string cUniversity)
        {
            Name = cName;
            Age = cAge;
            University = cUniversity;
        }
        public void Print() => Console.WriteLine($"Name       : {Name}\nAge        : {Age}\nUniversity : {University}");
    }
}
