#region uzunluğu 4-dən böyük olan sözlər
Console.WriteLine("---------------------------------------------------------");
string[] words = { "dəniz", "ada", "palma", "kakos", "daş", "od", "balıq" };
for (int i = 0; i < words.Length; i++)
{
    if (words[i].Length > 4)
    {
        Console.WriteLine(words[i]);
    }
}
Console.WriteLine("---------------------------------------------------------\n");
#endregion

#region tərs & cüt
int[] nums = { 3, 4, 5, 1, 2, 7, 8, 6, 9, 0, 10, 15, 14, 13, 12, 11, 18, 17 };
Array.Reverse(nums);
for (int i = 0;i < nums.Length; i++)
{
    if (nums[i] > 1)
    {
        if (nums[i]%2 == 0)
        {
            Console.Write(nums[i] + " ");
        }
    }
}
Console.WriteLine("\n---------------------------------------------------------\n");
#endregion

#region palindrom
string[] words2 = { "yol", "maşın", "sürət", "radar", "ata", "mesaj", "açar"};
for (int i = 0; i < words2.Length; i++)
{
    string reverse = "";
    char[] reverseWA = words2[i].ToCharArray();
    for (int j = reverseWA.Length - 1; j >= 0; j--)
    {
        reverse += reverseWA[j];
    }
    if (reverse == words2[i])
    {
        Console.WriteLine(reverse);
    }
}
Console.WriteLine("---------------------------------------------------------\n");
#endregion
