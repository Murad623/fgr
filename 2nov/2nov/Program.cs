using _2nov.Classes;
using _2nov.Classes.Bases;
#region Book
//Book book = new Book("The Fellowship of the Ring", "J.R.R. Tolkien", 423);
//book.GetBookİnfo();
#endregion
#region Student
//Student student = new Student("Fərid",2);
#endregion
#region Student 2
//Student2 newStudent = new Student2("Nihad", 18, "ADNSU");
//newStudent.Print();
#endregion
#region Animals
//Animal animal = new Animal();
//Dog dog = new Dog();
//Cat cat = new Cat();
//animal.Speak();
//dog.Speak();
//cat.Speak();
#endregion
#region Rectangle
//Rectangle rectangle = new Rectangle(5,4);
//rectangle.CalArea();
//Console.WriteLine(rectangle.Area);
#endregion
#region Set and write
int inum = int.MaxValue;
double dnum = double.MinValue;
string text = "Text";
bool state = true;
Console.WriteLine($"Int    : {inum}\nDouble : {dnum}\nString : {text}\nBool   : {state}");
#endregion
#region Check Number
//int num = 0;
//Console.Clear();
//Console.Write("Number : ");
//while (true)
//{
//	try
//	{
//		num = int.Parse(Console.ReadLine());
//		break;
//	}
//	catch (Exception)
//	{
//        Console.Clear();
//        Console.Write("Please enter numbers only : ");
//    }
//}
//if (num > 0) Console.WriteLine("Positive");
//else if (num < 0) Console.WriteLine("Negative");
//else Console.WriteLine("Zero");
#endregion
#region Odd
int num = 0;
Console.Clear();
Console.Write("Number : ");
while (true)
{
	try
	{
		num = int.Parse(Console.ReadLine());
		break;
	}
	catch (Exception)
	{
		Console.Clear();
		Console.Write("Please enter numbers only : ");
	}
}
for (int i = 1; i < num; i+=2)
{
	Console.WriteLine(i);
}
#endregion