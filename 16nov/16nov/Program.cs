using _16nov.Classes;

Console.WriteLine("Calculator Add (5+4) --> "+Calculator.Add(5, 4));
Console.WriteLine("Calculator Multiply (5*4) --> " + Calculator.Multiply(5, 4));
Console.WriteLine("---------------------------------------------------------------------\n");
Student student = new Student();
Student student2 = new Student("Ferid",7,2);
Console.WriteLine("Student 1 :");
student.PrintStudent();
Console.WriteLine("\nStudent 2 :");
student2.PrintStudent();
Console.WriteLine("---------------------------------------------------------------------\n");
Circle circle = new Circle();
Rectangle rectangle = new Rectangle();
Console.WriteLine($"Circle Area (radius = 4 m) --> {circle.GetArea(4)} m^2");
Console.WriteLine($"Rectangle Area (side = 4 m) --> {rectangle.GetArea(4)} m^2");