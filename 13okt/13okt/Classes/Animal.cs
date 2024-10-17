using _13okt.Classes.Base;

namespace _13okt.Classes
{
    public class Animal : Alive
    {
        public int footcount;
        public Animal()
        {
            age = 14;
            cellCount = 1000000;
            footcount = 4;
        }
        public void Run()
        {
            for (int i = 0; i < 18; i++)
            {
                Console.Clear();
                Console.WriteLine("Animal is runing");
                char[] symb = { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' };
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
