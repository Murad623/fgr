namespace _13okt.Classes.Base
{
    public class Alive
    {
        public int age;
        public long cellCount;
        public void Breathing(string type)
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(type + " is Breathing");
                Console.WriteLine("" +
                    " ___\n" +
                    "|   |\n" +
                    " ---");
                Thread.Sleep(700);
                Console.Clear();
                Console.WriteLine(type + " is Breathing");
                Console.WriteLine("" +
                    "  ___ \n" +
                    "|     |\n" +
                    "|     |\n" +
                    "  --- ");
                Thread.Sleep(700);
                Console.Clear();
            }
        }
    }
}
