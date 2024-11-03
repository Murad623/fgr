using _18oct.Classes.Base;
using _18oct.Services;
namespace _18oct.Classes
{
    public class Worrior : Character
    {
        decimal ReducesDamage;
        GameService gameService = new GameService();
        public Worrior()
        {
            MaxHealth = 100;
            Health = MaxHealth;
            AttackPower = 10;
            ReducesDamage = 2;
        }
        public int Block(int damage, Character attacker) // Special ability
        {
            //gameService.PrintDeleyed((NPC ? Name : "You") + " reduced " + (NPC ? "your" : Name+"'s") + " attaack damage by half");
            SpecialUsedState = true;
            return (int)(damage / ReducesDamage);
        }
        public override void SpecialUsed(Character? character = null)
        {
            if (SpecialUsedState)
            {
                gameService.PrintDeleyed((NPC ? Name : "You") + " reduced " + (NPC ? "your" : Name + "'s") + " attaack damage by half");
                SpecialUsedState = false;
            }
        }
        public override void Levelup()
        {
            base.Levelup();
            if(ReducesDamage <= 5) ReducesDamage += 0.5m;
        }
        public override string Type()
        {
            return "Worrior";
        }
        public override void TakeDamage(int damage, bool IsSuccess, Character attacker)
        {
            if (!IsSuccess) damage = Block(damage, attacker);
            base.TakeDamage(damage, IsSuccess, attacker);
        }
        public override string CharacterSpecial()
        {
            return "Reduces damage from \nnon-full power attacks by half.";
        }
    }
}