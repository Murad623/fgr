#region ArrOp
int[] nums = { 34, 13, 3, 1, 8, 2, 15, 10, 0, 9 };
bool ArrOp(int[] nums)
{
    int sum = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
    }
    if (sum % 2 == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}
Console.WriteLine(ArrOp(nums));
Console.WriteLine("--------------------------------------------------------\n");
#endregion

#region Prime
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
while (true)
{
    Console.Write("Number pls : ");
    try
    {
        int val = int.Parse(Console.ReadLine());
        Console.WriteLine(IsPrime(val));
        break;
    }
    catch (Exception)
    {
        
    }
}
Console.WriteLine("--------------------------------------------------------\n");
#endregion

#region CalcAvg
int CalcAvg(int[] xp)
{
    int sum = 0;
    for (int i = 0; i < xp.Length; i++)
    {
        sum += xp[i];
    }
    int avg = sum / xp.Length;
    return avg;
}
int[] xps = { 67, 75, 98, 74, 99 };
int avg = CalcAvg(xps);
if (avg > 60)
{
    Console.WriteLine("Məzun oldunuz");
}
else
{
    Console.WriteLine("Məzun ola bilmədiniz");
}
Console.WriteLine("--------------------------------------------------------\n");
#endregion

#region Age problem
int[] ages = { 17, 21, 23, 25 };
int userAge;
while (true)
{
    Console.Write("Age : ");
    try
    {
        userAge = int.Parse(Console.ReadLine());
        break;
    }
    catch (Exception)
    {
        Console.WriteLine("Use the decimal numeral system, pls");
    }
}
bool sameAge = false;
foreach (int age in ages)
{
    if (age == userAge)
    {
        sameAge = true;
        break;
    }
    else
    {
        sameAge = false;
    }
}
Console.WriteLine(sameAge);
Console.WriteLine("--------------------------------------------------------\n");
#endregion