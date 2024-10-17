using _16oct.Classes.Base;
namespace _16oct.Classes
{
    public class Cat : Animal
    {
        public Cat(string cName, int cAge, string cGender, int cStomachLimit)
        {
            age = cAge;
            name = cName;
            gender = cGender;
            stomachLimit = cStomachLimit;
            stomach = 0;
            isAwake = true;
            ageLimit = 3;
        }
        public Cat()
        {
            age = 1;
            name = "Cute";
            gender = "Female";
            stomachLimit = 3;
            stomach = 0;
            isAwake = true;
            ageLimit = 3;
        }
        public void Meow()
        {
            Console.Clear();
            Console.WriteLine("Meow");
            Thread.Sleep(1500);
        }
        public override void Awake()
        {
            Meow();
            base.Awake();
        }
        public override void IsHungry(string aName)
        {
            Meow();
            base.IsHungry(aName);
        }
    }
}