using _16oct.Classes.Base;
namespace _16oct.Classes
{
    class Dog : Animal
    {
        public Dog(string cName, int cAge, string cGender, int cStomachLimit)
        {
            age = cAge;
            name = cName;
            gender = cGender;
            stomachLimit = cStomachLimit;
            stomach = 0;
            isAwake = true;
            ageLimit = 6;
        }
        public Dog()
        {
            age = 1;
            name = "Cute";
            gender = "Female";
            stomachLimit = 3;
            stomach = 0;
            isAwake = true;
            ageLimit = 6;
        }
        public void Bark()
        {
            Console.Clear();
            Console.WriteLine("Hav hav");
            Thread.Sleep(1500);
        }
        public override void Awake()
        {
            Bark();
            base.Awake();
        }
        public override void IsHungry(string aName)
        {
            Bark();
            base.IsHungry(aName);
        }
        public override void BirthDay()
        {
            age++;
            base.BirthDay();
        }
    }
}