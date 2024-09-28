int Sum(int a, int b)
{
    return a+b;
}
int Avg(int[] arr)
{
    int sum = 0;
    if (arr.Length>0)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum/arr.Length;
    }
    else
    {
        Console.WriteLine("Array bosdur");
        return 0;
    }
}
double Round(float a)
{
    return Math.Round(a);
}
bool OddOrEven(int a)
{
    if (a%2 == 0)
        return true;
    else
        return false;
}
string CheckBool (bool a)
{
    if (a)
        return "Bəli";
    else
        return "Xeyr";
}
string JoinStr (string a, string b)
{
    return a + " " + b;
}
decimal DecimalPow (decimal a)
{
    return a*a;
}
bool IsPrime(int num)
{
    int isP = 0;
    if (num <= 1)
    {
        return false;
    }
    if (num > 2)
    {
        for (int i = 2; i < num; i++)
        {
            if (num % i == 0)
            {
                isP++;
            }
        }
    }
    if (isP == 0)
        return true;
    else
        return false;
}
double Power(int a, int b)
{
    return Math.Pow(a, b);
}
bool loopstate = true;
Console.WriteLine("Tasklar [1...9] kimi nömrələnmişdir. Proqramdan çıxış üçün isə 'e' yazın." );
Console.WriteLine("\n-------------------start--------------------");
while (loopstate)
{
    Console.Write("Task : ");
    string com = Console.ReadLine();
    switch (com)
    {
        case "1":
            Console.WriteLine(Sum(17, 4));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "2":
            int[] arr = { 1324, 34, 1, 432, -1344 };
            Console.WriteLine(Avg(arr));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "3":
            Console.WriteLine(Round(20.5f));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "4":
            Console.WriteLine("Tək Cüt");
            int d = 0;
            while (true)
            {
                try
                {
                    Console.Write("Ədəd : ");
                    string text1 = Console.ReadLine();
                    d = int.Parse(text1);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Bu ədəd deyil");
                }

            }
            Console.WriteLine(OddOrEven(d));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "5":
            Console.WriteLine(CheckBool(true));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "6":
            Console.Write("Ad : ");
            string firstName = Console.ReadLine();
            Console.Write("Soyad : ");
            string lastName = Console.ReadLine();
            Console.WriteLine(JoinStr(firstName, lastName));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "7":
            Console.WriteLine(DecimalPow(14.43m));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "8":
            int c = 0;
            while (true)
            {
                try
                {
                    Console.Write("Ədəd : ");
                    string text1 = Console.ReadLine();
                    c = int.Parse(text1);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Bu ədəd deyil");
                }

            }
            Console.WriteLine(IsPrime(c) ? "Ədəd sadədir" : "Ədəd mürəkkəbdir");
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "9":
            Console.WriteLine("Qüvvətə yüksəltmə");
            int a = 0;
            int b = 0;
            while (true)
            {
                try
                {
                    Console.Write("Ədəd : ");
                    string text1 = Console.ReadLine();
                    a = int.Parse(text1);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Bu ədəd deyil");
                }
                
            }
            while (true)
            {
                try
                {
                    Console.Write("Ədəd : ");
                    string text1 = Console.ReadLine();
                    b = int.Parse(text1);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Bu ədəd deyil");
                }

            }
            Console.WriteLine(Power(a, b));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "e":
            loopstate = false;
            Console.WriteLine("\n-------------------end----------------------");
            break;
        default:
            Console.WriteLine("Belə bir funksya yoxdur");
            break;
    }
}