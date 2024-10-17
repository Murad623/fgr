using _16oct.Classes;
using _16oct.Classes.Base;
bool working = true;
Cat cat1 = new Cat("Victor", 2, "Male", 4);
Dog dog1 = new Dog("Violet", 3, "Female", 5);
Console.Clear();
Console.WriteLine($"We give you 2 pets, a cat and a dog");
Console.WriteLine($"\n" +
    $"Cat \n------------------\n" +
    $"Name : {cat1.name}\n" +
    $"Age : {cat1.age}\n" +
    $"Gender : {cat1.gender}\n" +
    $"Stomach Limit : {cat1.stomachLimit}");
Console.WriteLine($"\n" +
    $"Dog \n------------------\n" +
    $"Name : {dog1.name}\n" +
    $"Age : {dog1.age}\n" +
    $"Gender : {dog1.gender}\n" +
    $"Stomach Limit : {dog1.stomachLimit}");
Console.WriteLine("\n\nPress type anything and press enter for skip");
while (Console.ReadLine().Length == 0);
Console.Clear();
PrintCommands();
while (working)
{
    Console.Clear();
    string com = Console.ReadLine();
    if (com.Length > 0)
    {
        switch (com.ToLower()[0])
        {
            case 'p':
                PrintCommands();
                break;
            case 'q':
                working = false;
                break;
            case 'c':
                Choiced(cat1);
                break;
            case 'd':
                Choiced(dog1);
                break;
            case 'i':
                Console.Clear();
                cat1.PrintPetValue();
                dog1.PrintPetValue();
                Console.WriteLine("\n\nPress type anything and press enter for skip");
                while (Console.ReadLine().Length == 0);
                break;
            default:
                break;
        }
    }
}
void PrintCommands()
{
    Console.Clear();
    Console.WriteLine("" +
        "Animal choicing : C - cat | D - dog\n" +
        "-----------------------------------\n\n" +
        "F - feeding | S - Sleep | A - Awake\n" +
        "-----------------------------------\n\n" +
        "P - Print Commands | Q - quit\n" +
        "-----------------------------------\n\n" +
        "I - information about pet(s)\n" +
        "-----------------------------------");
    Console.WriteLine("\n\nPress type anything and press enter for skip");
    while (Console.ReadLine().Length == 0) ;
}
void Choiced(Animal pet)
{
    bool working2 = true;
    while (working2)
    {
        Console.Clear();
        Console.WriteLine(pet.name + (pet.isAwake ? " is awake   " : " is sleeping") +$"                  day : {pet.day}");
        string com = Console.ReadLine();
        if (com.Length > 0)
        {
            switch (com.ToLower()[0])
            {
                case 'p':
                    PrintCommands();
                    break;
                case 'q':
                    working2 = false;
                    break;
                case 'f':
                    if (pet.isAwake)
                    {
                        Feed(pet);
                    }
                    break;
                case 's':
                    pet.Sleep();
                    break;
                case 'a':
                    if (!pet.isAwake)
                    {
                        pet.Awake();
                        if (cat1.isAwake && dog1.isAwake)
                        {
                            if (365 - pet.day >= pet.dayIncrement)
                            {
                                cat1.day += pet.dayIncrement;
                                dog1.day += pet.dayIncrement;
                            }
                            else
                            {
                                cat1.day = 365;
                                dog1.day = 365;
                                cat1.BirthDay();
                                dog1.BirthDay();
                            }
                        }
                    }
                    break;
                case 'i':
                    Console.Clear();
                    pet.PrintPetValue();
                    Console.WriteLine("\n\nPress type anything and press enter for skip");
                    while (Console.ReadLine().Length == 0) ;
                    break;
                default:
                    break;
            }
        }
    }
}
void Feed(Animal pet)
{
    bool working2 = true;
    while (working2)
    {
        if (pet.isAwake)
        {
            Console.Clear();
            Console.WriteLine("F - food | D - drink");
            string com = Console.ReadLine();
            if (com.Length > 0)
            {
                switch (com.ToLower()[0])
                {
                    case 'p':
                        PrintCommands();
                        break;
                    case 'q':
                        working2 = false;
                        break;
                    case 'f':
                        int foodValue = GetValue("Food");
                        pet.Eat(foodValue);
                        break;
                    case 'd':
                        int drinkValue = GetValue("Food");
                        pet.Drink(drinkValue);
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            working2 = false;
        }
    }
}
int GetValue (string feedType)
{
    int value = 0;
    while (true)
    {
        try
        {
            Console.Clear();
            Console.WriteLine($"{feedType} value : ");
            value = int.Parse(Console.ReadLine());
            break;
        }
        catch (Exception)
        {
            Console.WriteLine("You can use just number");
            Thread.Sleep(2000);
        }
    }
    return value;
}