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
        return "Beli";
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
int GetNum(string txt)
{
    while (true)
    {
        try
        {
            Console.Write($"{txt} : ");
            string text1 = Console.ReadLine();
            return int.Parse(text1);
        }
        catch (Exception)
        {
            Console.WriteLine($"Bu eded deyil");
        }

    }
}
float GetNumFl(string txt)
{
    while (true)
    {
        try
        {
            Console.Write($"{txt} : ");
            string text1 = Console.ReadLine();
            return float.Parse(text1);
        }
        catch (Exception)
        {
            Console.WriteLine($"Bu eded deyil");
        }

    }
}
decimal GetNumDc(string txt)
{
    while (true)
    {
        try
        {
            Console.Write($"{txt} : ");
            string text1 = Console.ReadLine();
            return decimal.Parse(text1);
        }
        catch (Exception)
        {
            Console.WriteLine($"Bu eded deyil");
        }

    }
}
bool loopstate = true;
Console.WriteLine("Tasklar [1...9] kimi nömrelenmişdir. Proqramdan çıxış üçün ise 'e' yazın." );
Console.WriteLine("\n-------------------start--------------------");
while (loopstate)
{
    Console.Write("Task : ");
    string com = Console.ReadLine();
    switch (com)
    {
        case "1":
            int a = GetNum("Eded");
            int b = GetNum("Eded");
            Console.WriteLine(Sum(a, b));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "2":
            int l = GetNum("Arrayin uzunlugu");
            int[] arr = new int[l];
            Console.WriteLine("Arrayin deyerleri");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = GetNum($"Array[{i}] = ");
            }
            Console.WriteLine(Avg(arr));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "3":
            Console.WriteLine("Eded yuvarlaqlasdirma\n");
            Console.WriteLine(Round(GetNumFl("Eded")));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "4":
            Console.WriteLine("Tek Cüt");
            int d = GetNum("Eded");
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
            Console.WriteLine(DecimalPow(GetNumDc("Eded")));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "8":
            int e = GetNum("Eded");
            Console.WriteLine(IsPrime(e) ? "Eded sadedir" : "Eded mürekkebdir");
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "9":
            Console.WriteLine("Qüvvete yükseltme");
            int f = GetNum("Eded");
            int g = GetNum("Eded");
            Console.WriteLine(Power(f, g));
            Console.WriteLine("\n--------------------------------------------");
            break;
        case "e":
            loopstate = false;
            Console.WriteLine("\n-------------------end----------------------");
            break;
        default:
            Console.WriteLine("Bele bir funksya yoxdur | funksyalar [1...9] ve 'e'-dir");
            break;
    }
}