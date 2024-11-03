using _18oct.Classes.Base;
using _18oct.Services;
namespace _18oct.Classes
{
    public class Mage : Character
    {
        int AttackWhenTakeDamage;
        GameService gameService = new GameService();
        public Mage()
        {
            MaxHealth = 70;
            Health = MaxHealth;
            AttackPower = 20;
            AttackWhenTakeDamage = 5;
        }
        public void CastSpell(Character character) // Special ability
        {
            //gameService.PrintDeleyed((NPC ? Name : "You") + " used CastSpell.");
            //gameService.PrintDeleyed((NPC ? "You" : character.Name) + $" took {AttackWhenTakeDamage} damage");
            character.TakeDamage(AttackWhenTakeDamage,true,null);
            SpecialUsedState = true;
        }
        public override void SpecialUsed(Character? character = null)
        {
            if (SpecialUsedState)
            {
                gameService.PrintDeleyed((NPC ? Name : "You") + " used CastSpell.");
                gameService.PrintDeleyed((NPC ? "You" : character.Name) + $" took {AttackWhenTakeDamage} damage");
                SpecialUsedState = false;
            }
        }
        public override string Type()
        {
            return "Mage";
        }
        public override void TakeDamage(int damage, bool IsSuccess, Character attacker)
        {
            base.TakeDamage(damage, IsSuccess, attacker);
            if (!IsAttacker)
            {
                IsAttacker = true;
                attacker.IsAttacker = true;
                CastSpell(attacker);
                IsAttacker = false;
                attacker.IsAttacker = false;
            }
        }
        public override void Levelup()
        {
            base.Levelup();
            if(AttackWhenTakeDamage <= 100) AttackWhenTakeDamage++;
        }
        public override string CharacterSpecial()
        {
            return $"If the character takes damage when not attaker,\nthe attacker's health decreases by {AttackWhenTakeDamage}";
        }
    }
}