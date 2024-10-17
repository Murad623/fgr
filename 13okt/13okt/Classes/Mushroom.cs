using _13okt.Classes.Base;

namespace _13okt.Classes
{
    public class Mushroom : Alive
    {
        bool isPoison;
        public Mushroom( bool isP)
        {
            age = 1;
            cellCount = 10000;
            isPoision = isP;
        }
        public Mushroom()
        {
            age = 1;
            cellCount = 10000;
            isPoision = true;
        }
    }
}
