using _18oct.Classes.Base;
using _18oct.Services;
namespace _18oct.Classes
{
    public class Archer : Character
    {
        int extraArrows;
        int extraArrowDamage;
        GameService gameService = new GameService();
        public Archer()
        {
            MaxHealth = 85;
            Health = MaxHealth;
            AttackPower = 15;
            extraArrows = 2;
            extraArrowDamage = 3;
        }
        public void Shoot(Character character) // Special ability
        {
            AttackPower += extraArrowDamage * extraArrows;
            PresentAttackPower = AttackPower;
            SpecialUsedState = true;
        }
        public override void SpecialUsed(Character? character = null)
        {
            if (SpecialUsedState)
            {
                //AttackPower += extraArrowDamage * extraArrows;
                gameService.PrintDeleyed((NPC ? Name : "You") + " shooted " + extraArrows + " extra arrow" + (extraArrows > 1 ? "s." : "."));
                gameService.PrintDeleyed($"Damage per arrow : {extraArrowDamage}");
                //gameService.PrintDeleyed($"Total damage : {PresentAttackPower}");
                SpecialUsedState = false;
                AttackPower = AttackPowerOrigin;
            }
        }
        public override void Levelup()
        {
            base.Levelup();
            AttackPowerOrigin = AttackPower;
            Random random = new Random();
            int increaseDamagePerArrow = 0;
            int increaseArrowCount = 0;
            if (extraArrows < 5) increaseArrowCount = random.Next(1, 3);
            if (extraArrowDamage < 20) increaseDamagePerArrow = random.Next(1,4);
            if (!NPC)
            {
                if(extraArrows < 5 && extraArrowDamage < 30)
                {
                    Console.WriteLine("Your special ability will improve.");
                    Console.WriteLine("Choose one : ");
                    Console.WriteLine($"C - Increase the arrow count by {increaseArrowCount} | D - Increase the damage per arrow by {increaseDamagePerArrow}");
                    ConsoleKeyInfo key;
                    bool working = true;
                    while (working)
                    {
                        key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.C:
                                extraArrows += increaseArrowCount;
                                working = false;
                                break;
                            case ConsoleKey.D:
                                extraArrowDamage += increaseDamagePerArrow;
                                working = false;
                                break;
                            default:
                                break;
                        }
                    }
                }
                else if (extraArrows > 5) extraArrows += increaseArrowCount;
                else if (extraArrowDamage > 20) extraArrowDamage += increaseDamagePerArrow;
            }
            else
            {
                if(random.Next(0,2) == 0) extraArrows += increaseArrowCount;
                else extraArrowDamage += increaseDamagePerArrow;
            }
        }
        public override string Type()
        {
            return "Archer";
        }
        public override void Attack(Character target, bool IsSuccess)
        {
            if (IsSuccess) Shoot(target);
            base.Attack(target, IsSuccess);
        }
        public override void TakeDamage(int damage, bool IsSuccess, Character attacker)
        {
            base.TakeDamage(damage, IsSuccess, attacker);
        }
        public override string CharacterSpecial()
        {
            return $"If the archer makes a successful shot,\nthey fire {extraArrows} more arrow" + (extraArrows > 1 ? "s" : "") + $"\nDamage per arrow : {extraArrowDamage}";
        }
    }
}