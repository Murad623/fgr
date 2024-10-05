#region Parol
//string pass = string.Empty;
//Console.WriteLine("Parolda en az 1 boyuk herf, 1 reqem, uzunlugu en az 8 olmalidir.");
//while (true)
//{
//    Console.Write("Parol : ");
//    pass = Console.ReadLine();
//    if (pass.Length >= 8)
//    {
//        bool hUpper = false;
//        for (int i = 0; i < pass.Length; i++)
//        {
//            if (char.IsUpper(pass[i]))
//            {
//                hUpper = true;
//                break;
//            }
//        }
//        bool hNum = false;
//        for(int i = 0;i < pass.Length; i++)
//        {
//            int a = 0;
//            if (int.TryParse(pass[i].ToString(),out a))
//            {
//                hNum = true;
//                break;
//            }
//        }
//        if (hUpper && hNum)
//        {
//            break;
//        }
//    }
//    Console.WriteLine("Uygun deyil!");
//}
//Console.WriteLine("Qebul olundu");
#endregion
#region ArrOp
//string[] elements = new string[5];
//for (int i = 0; i < 5; i++)
//{
//    Console.Write($"{i+1}. element : ");
//    elements[i] = Console.ReadLine();
//}
//Array.Sort(elements);
//Array.Reverse(elements);
//for (int i = 0;i < elements.Length; i++)
//    Console.Write(elements[i] + " ");
#endregion

#region 4r ters
int a = 466731;
int b = 0;
int c = a.ToString().Length + 1;
for (int i = 1; i < c; i++)
{
    int q = (a%10);
    b = b*10 + q ;
    a = (a-q)/10;
}
Console.WriteLine(b);
#endregion