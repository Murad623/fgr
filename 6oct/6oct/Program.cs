Car FirstCar = new Car
{
    Brend = "Ford",
    Model = "Transit",
    Type = "Truck",
    Color = "Purple",
    CountOfDoor = 5,
    MaxSpeed = 200,
    Size = "M",
};
Car SecCar = new Car
{
    Brend = "IDK",
    Model = "Tavria",
    Type = "Pickup",
    Color = "White",
    CountOfDoor = 4,
    MaxSpeed = 180,
    Size = "S",
};
Console.WriteLine("First Car\n");
FirstCar.Print();
FirstCar.Lights();
FirstCar.Farword();
FirstCar.Backword();
FirstCar.TurnLeft();
FirstCar.TurnRight();
FirstCar.Horn();
Console.WriteLine("\nSecond Car : \n");
SecCar.Print();
SecCar.Lights();
SecCar.Farword();
SecCar.Backword();
SecCar.TurnLeft();
SecCar.TurnRight();
SecCar.Horn();
class Car
{
    public string Brend = "";
    public string Model = "";
    public string Type = "";
    public string Color = "";
    public int CountOfWheel = 4;
    public int CountOfDoor;
    public int MaxSpeed;
    public string Size = "";
    public void Farword()
    {
        Console.WriteLine("˄\n|");
    }
    public void Backword()
    {
        Console.WriteLine("|\n˅");
    }
    public void TurnLeft ()
    {
        Console.WriteLine("<-");
    }
    public void TurnRight()
    {
        Console.WriteLine("->");
    }
    public void Horn()
    {
        Console.WriteLine("BIIIP BIIIP");
    }
    public void Lights()
    {
        Console.WriteLine("" +
            "╔══╗" +
            "\n●==●" +
            "\n▀  ▀");
    }
    public void Print()
    {
        Console.WriteLine($"" +
            $"Brend        : {Brend}\n" +
            $"Model        : {Model}\n" +
            $"Type         : {Type}\n" +
            $"Color        : {Color}\n" +
            $"CountOfWheel : {CountOfWheel}\n" +
            $"CountOfDoor  : {CountOfDoor}\n" +
            $"Max Speed    : {MaxSpeed}\n" +
            $"Size         : {Size}");
    }
}