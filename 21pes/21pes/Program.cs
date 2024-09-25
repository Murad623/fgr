a:
try
{
	string text = Console.ReadLine();
	int age = int.Parse(text);
	if (age > 18)
	{
		Console.WriteLine("Xoş gəmisiniz");
	}
	else
	{
		Console.WriteLine("18 yaşın olanda gələrsən");
	}
}
catch (Exception)
{
	Console.WriteLine("Rəqəm daxil edin");
	goto a;
	throw;
}