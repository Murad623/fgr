using _13okt.Classes.Base;

namespace _13okt.Classes
{
    public class Human : Alive
    {
        public int footcount;
        public Human()
        {
            age = 21;
            cellCount = 1000000;
            footcount = 2;
        }
        public void Run()
        {
            for (int i = 0; i < 18; i++)
            {
                Console.Clear();
                Console.WriteLine("Human is runing");
                char[] symb= { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' };
                symb[i] = '+';
                for (int j = 0; j < symb.Length; j++)
                {
                    Console.Write(symb[j]);
                }
                Thread.Sleep(100);
            }
        }
    }
}
