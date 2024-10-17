using System.Xml.Linq;

namespace _16oct.Classes.Base
{
    public class Animal
    {
        public string name = string.Empty;
        public int age;
        public int day = 1;
        public int dayIncrement = 30;
        public int ageLimit;
        public int bloodType;
        public int stomachLimit;
        public int stomach;
        public bool isAwake;
        public string gender = string.Empty;
        public void Eat(int foodValue)
        {
            Console.Clear();
            if (isAwake)
            {
                if (stomach < stomachLimit)
                {
                    Console.WriteLine($"{name} is eating something");
                    Thread.Sleep(1000);
                    if (stomachLimit - stomach > foodValue)
                    {
                        stomach += foodValue;
                    }
                    else
                    {
                        stomach = stomachLimit;
                        Console.WriteLine($"{name} can't eat another bite." + " And " + (gender == "Female" ? "she" : "he")+" gonna bed");
                        Thread.Sleep(1000);
                        Sleep();
                    }
                }
                else
                {
                    Console.WriteLine($"{name} is stuffed and gonna bed");
                    Thread.Sleep(1000);
                    Sleep();
                }
            }
            else
            {
                Console.WriteLine($"{name} is sleeping");
            }
        }
        public void Drink(int drinkValue)
        {
            Console.Clear();
            if (isAwake)
            {
                if (stomach < stomachLimit)
                {
                    Console.WriteLine($"{name} is drinking something");
                    Thread.Sleep(1000);
                    if (stomachLimit - stomach > drinkValue)
                    {
                        stomach += drinkValue;
                    }
                    else
                    {
                        stomach = stomachLimit;
                        Console.WriteLine($"{name} is full." + " And" + (gender == "Female" ? " she" : " he") + " gonna bed");
                        Thread.Sleep(1000);
                        Sleep();
                    }
                }
                else
                {
                    Console.WriteLine($"{name} is stuffed and gonna bed");
                    Thread.Sleep(1000);
                    Sleep();
                }
            }
            else
            {
                Console.WriteLine($"{name} is sleeping");
            }
        }
        public void Sleep()
        {
            if (stomach == 0)
            {
                IsHungry($"{name} can't sleep, because " + (gender == "Female" ? "she" : "he"));
            }
            else
            {
                isAwake = false;
                for (int i = 0; i < 3; i++)
                {
                    Console.Clear();
                    Console.Write("Z");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write("z");
                        Thread.Sleep(500);
                    }
                }
            }
        }
        public virtual void Awake()
        {
            isAwake = true;
            stomach = 0;
            Console.Clear();
            IsHungry(name);
            if (day == 365)
            {
                day = 1;
            }
        }
        public virtual void IsHungry(string aName)
        {
            Console.WriteLine($"{aName} is hungry");
            Thread.Sleep(3000);
        }
        public void PrintPetValue()
        {
            Console.WriteLine($"" +
                $"{name}\n" +
                $"-----------------\n" +
                $"Age : {age}\n" +
                $"Stomach : {stomach}\n" +
                $"Stomach Limit : {stomachLimit}\n" +
                $"Blood Type : {bloodType}\n" +
                $"Gender : {gender}\n" +
                $"-----------------\n");
        }
        public virtual void BirthDay()
        {
            if (age == ageLimit)
            {
                ageLimit += 3;
                if (stomachLimit <=20)
                {
                    stomachLimit++;
                }
            }
            Console.Clear();
            Console.WriteLine($"" +
                $"Today is Violet and Victor's birthday\n" +
                $"Happy {age}{ArtOfNum(age)} birthday {name}" +
                $"\r\n     _|_|_\r\n    |     |\r\n  +---------+\r\n  |         |\r\n+-------------+\r\n|             |\r\n+-------------+");
            if (dayIncrement>1)
            {
                dayIncrement--;
            }
            Console.WriteLine("\n\nPress type anything and press enter for skip");
            while (Console.ReadLine().Length == 0) ;
        }
        public string ArtOfNum(int num)
        {
            string artNum = "th";
            if (num%10 == 1 && num%100 != 11)
            {
                artNum = "st";
            }
            else if(num%10 == 2 && num%100 != 12)
            {
                artNum = "nd";
            }
            else if (num%10 == 3 && num%100 != 13)
            {
                artNum = "rd";
            }
            return artNum;
        }
    }
}