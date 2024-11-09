using _18oct.Services;

namespace _18oct.Classes.Base
{
    public abstract class Character
    {
        public string Name = string.Empty;
        public string Race = string.Empty;
        public int MaxHealth;
        public int Health;            // + Human  | Elf    | Goblin
        public int AttackPower;       // + Orc    | Dwarf  | Elf
        public int Xp;                // + Goblin | Dwarf  | Human |  Orc
        public int XpIncriment;
        public int XpIncrimentSub = 1;
        public int XpLimit;
        int XpLimitOld;
        public int Level;
        public bool NPC;
        public bool IsAttacker;
        public bool AttackSaccess;
        public int AttackPowerOrigin;
        public int PresentAttackPower;
        public int PresentDamage;
        public bool SpecialUsedState;
        GameService gameServis = new GameService();
        public Character()
        {
            Name = "Player";
            Race = "Human";
            Xp = 0;
            XpLimit = 1;
            XpIncriment = 1;
            Level = 0;
            XpLimitOld = 1;
            NPC = false;
        }
        public abstract void SpecialUsed(Character? character = null);
        public virtual void Attack(Character target, bool IsSuccess)
        {
            target.TakeDamage(AttackPower, IsSuccess, this);
        }
        public virtual void TakeDamage(int damage, bool IsSuccess, Character attacker)
        {
            if (Health > 0)
            {
                if (Health - damage > 0)
                {
                    PresentDamage = damage;
                    Health -= damage;
                }
                else
                {
                    PresentDamage = Health - damage;
                    Health = 0;
                }
            }
        }
        public void SetName(string name = "Player")
        {
            Name = name;
        }
        public void GetXp()
        {
            if (Xp < XpLimit)
            {
                int incriment = XpIncriment * XpIncrimentSub;
                while (true)
                {
                    if (Xp+incriment < XpLimit && incriment > 0)
                    {
                        Console.Clear();
                        gameServis.PrintCaracterDetails(this);
                        gameServis.PrintDeleyed($"You have extra {incriment}Xp");
                        gameServis.WaitPress(true);
                        Console.Clear();
                        Xp += incriment;
                        break;
                    }
                    else
                    {
                        if(Xp + incriment > XpLimit) incriment = incriment - (XpLimit - Xp);
                        Levelup();
                    }
                } 
            }
            else
            {
                Levelup();
            }
        }
        public virtual void Levelup()
        {
            if (!NPC)
            {
                Console.Clear();
                gameServis.PrintDeleyed(" __        ________  __      ___  ________  __\r\n|  \\      |   ____/ |  |    /  / |   ____/ |  \\\r\n|  |      |  |      |  |   /  /  |  |      |  |\r\n|  |      |  |__    |  |  /  /   |  |__    |  |\r\n|  |      |   __|   |  | /  /    |   __|   |  |\r\n|  |      |  |      |  |/  /     |  |      |  |\r\n|  |____  |  |____  |     /      |  |____  |  |____\r\n\\_______\\ |_______\\ \\____/       |_______\\ \\_______\\\r\n                                __   __   _____\r\n                               |  | |  | |     \\\r\n                               |  | |  | |  |\\  \\\r\n                               |  | |  | |  |/  /\r\n                               |  | |  | |   __/\r\n                               |  | |  | |  /\r\n                               \\  \\_/  / |  |\r\n                                \\_____/  |__|",0);
            }
            gameServis.WaitPress(true);
            Level += 1;
            Xp = 0;
            int XpLimitIncriment = XpLimitOld;
            XpLimitOld = XpLimit;
            XpLimit += XpLimitIncriment;
            AttackPower += 5;
            MaxHealth += 10;
            if (NPC) Health = MaxHealth;
        }
        public abstract string Type();
        public void SetNPC(bool IsNPC)
        {
            NPC = IsNPC;
        }
        public void SetRace(char race)
        {
            switch (race)
            {
                case 'H':
                    Race = "Human";
                    Health = (int)Math.Round(Health*1.35m);
                    MaxHealth = (int)Math.Round(Health*1.35m);
                    XpIncrimentSub = 2;
                    break;
                case 'G':
                    Race = "Goblin";
                    Health += 10;
                    MaxHealth += 10;
                    XpIncrimentSub = 3;
                    break;
                case 'O':
                    Race = "Orc";
                    AttackPower += 10;
                    XpIncrimentSub = 2;
                    break;
                case 'E':
                    Race = "Elf";
                    Health += 30;
                    MaxHealth += 30;
                    AttackPower += 15;
                    break;
                case 'D':
                    Race = "Dwarf";
                    AttackPower *= 2;
                    XpIncrimentSub = 4;
                    break;
                default:
                    break;
            }
            AttackPowerOrigin = AttackPower;
        }
        public abstract string CharacterSpecial();
        public void CharacterHealing(bool fullHealing = false, int hpInc = 30)
        {
            if (fullHealing) Health = MaxHealth;
            else
            {
                if(hpInc+Health <= MaxHealth) Health += hpInc;
                else Health = MaxHealth;
            }
            gameServis.PrintDeleyed(fullHealing || Health == MaxHealth ? (NPC ? Name + " is" : "You are") + " fully healed." : (NPC ? Name + "'s" : "Your") + " health increased by" + (MaxHealth-Health));
            gameServis.WaitPress(true);
        }
    }
}