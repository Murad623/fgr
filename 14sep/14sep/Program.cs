// 1
#region
int yOBirth = 2003;
//int.TryParse(Console.ReadLine(), out yOBirth);
if (yOBirth > 2006)
    Console.WriteLine("18 yaşınız tamam olmayıb\n");
else
    Console.WriteLine("18 yaşınız tamam olub\n");
#endregion

//2
#region
int x = -25;
if (x < 0)
    Console.WriteLine("Rəqəm mənfidir\n");
else
    Console.WriteLine("Rəqəm müsbətdir\n");
#endregion

// 3
#region
int day = 7;
switch (day)
{
    case 1:
        Console.WriteLine("Bazar ertəsi");
        break;
    case 2:
        Console.WriteLine("Çərşənbə axşamı");
        break;
    case 3:
        Console.WriteLine("Çərşənbə");
        break;
    case 4:
        Console.WriteLine("Cümə axşamı");
        break;
    case 5:
        Console.WriteLine("Cümə");
        break;
    case 6:
        Console.WriteLine("Şənbə");
        break;
    case 7:
        Console.WriteLine("Bazar");
        break;
    default:
        Console.WriteLine("Bu planetdə həftədə " + day + "gün var :)");
        break;
}
#endregion

// 4
#region
Console.WriteLine("");
string[] month = { "Yanvar", "Fevral", "Mart", "Aprel", "May", "İyun", "İyul", "Avqust", "Sentyabr", "Oktyabr", "Noyabr", "Dekabr" };
for (int i = 0; i < month.Length; i++)
{
    Console.WriteLine(i+1+". "+month[i]);
}
#endregion