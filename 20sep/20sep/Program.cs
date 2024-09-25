#region 1 <-> 10 +
//int a = 0;
//for (int i = 1; i < 10; i++)
//{
//    a += i;
//}
//Console.WriteLine(a);
//Console.WriteLine("----------------------------------------\n");
#endregion

#region cüt || tək
//int b = 0;
//int.TryParse(Console.ReadLine(), out b);
//Console.WriteLine(b % 2 == 0 ? "cüt" : "tək");
//Console.WriteLine("----------------------------------------\n");
#endregion

#region 1 <-> 20 tət
//for (int i = 1; i < 20; i++)
//	if (i%2 == 1)
//		Console.WriteLine(i);
#endregion

#region sort by name length
//string[] names = { "Fizuli", "Samir", "Mehriban", "Röya", "Mahmud" };
//int index = 0;
//while (index < names.Length)
//{
//    for (int i = 0; i < names.Length; i++)
//    {
//        if (i < names.Length-1)
//        {
//            if (names[i].Length > names[i + 1].Length)
//            {
//                string temp = names[i];
//                names[i] = names[i+1];
//                names[i+1] = temp;
//            }
//        }
//    }
//    index++;
//}
//for (int i = 0; i < names.Length; i++)
//    Console.WriteLine(names[i]);
#endregion

#region ^2
//string[] names = { "Fizuli", "Samir", "Mehriban", "Röya", "Mahmud" };
//for (int i = 0; i < names.Length; i++)
//{
//    Console.WriteLine(names[i].Length * names[i].Length);
//}
#endregion

#region köklü bir şeylər
//int[] nums = { 81, 45, 23, 14, 64, 25, 49, 90, 9 };
//int[] numsSq = {};
//int sq = 0;
//for (int i = 0; i < nums.Length; i++)
//{
//    if (nums[i] > 1)
//    {
//        for (int j = 1; j < nums[i]/2; j++)
//        {
//            if (nums[i]/j == j)
//            {
//                sq++;
//                Array.Resize(ref numsSq, sq);
//                numsSq[sq-1] = nums[i];
//            }
//        }
//    }
//    else
//    {
//        sq++;
//        Array.Resize(ref numsSq, sq);
//        numsSq[sq - 1] = nums[i];
//    }
//}
//Console.WriteLine($"Kökdən çıxanların sayı : {sq}");
//for (int i = 0;i < numsSq.Length; i++)
//{
//    Console.WriteLine(numsSq[i]);
//}
#endregion