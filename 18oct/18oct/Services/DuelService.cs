using _18oct.Classes.Base;
using System.Diagnostics;

namespace _18oct.Services
{
    public class DuelService
    {
        GameService gameService = new GameService();
        public bool DuelChoicing() // Accept or reject the duel
        {
            gameService.PrintDeleyed("A - Accept | R - Reject");
            while (true)
            {
                ConsoleKeyInfo key;
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.A:
                        return true;
                    case ConsoleKey.R:
                        return false;
                    default:
                        break;
                }
            }
        }
        public bool Duel(Character player, Character opponent, bool isAggressive = false, bool isTournament = false) // Duello başlıyır
        {
            int minHealth = 40;
            if (!isAggressive)
            {
                if (WhoStartsTheAttack(player, opponent))
                {
                    gameService.PrintDeleyed("You will first");
                    gameService.WaitPress(true);
                }
                else
                {
                    gameService.PrintDeleyed($"{opponent.Name} will first");
                    gameService.WaitPress(true);
                    OpponentAttack(player, opponent);
                }
            }
            else
            {
                gameService.WaitPress(true);
                if ((player.Race != "Orc" && opponent.Race != "Orc") || player.Race == opponent.Race)
                {
                    opponent.AttackPower = (int)(opponent.AttackPower * 1.5m);
                    opponent.Health = (int)(opponent.Health * 1.5m);
                }
                else opponent.AttackPower = (int)(opponent.AttackPower * 1.5m);
                OpponentAttack(player, opponent);
                minHealth = 0;
            }
            if (isTournament) minHealth = 0;
            while (player.Health > minHealth && opponent.Health > minHealth) // Duel start
            {
                PlayerAttack(player, opponent);
                if (player.Health > minHealth && opponent.Health > minHealth)
                {
                    OpponentAttack(player, opponent);
                }
            }
            
            if (player.Health <= minHealth) // You died when the duel or you lose the duel
            {
                Console.Clear();
                gameService.PrintCaracterDetails(player);
                gameService.PrintCaracterDetails(opponent);
                if (isAggressive || isTournament) gameService.PrintDeleyed("___    ___   _____    __   __\r\n\\  \\  /  /  /  _  \\  |  | |  |\r\n \\  \\/  /  /  / \\  \\ |  | |  |\r\n  \\    /   |  | |  | |  | |  |\r\n   \\  /    |  | |  | |  | |  |\r\n   |  |    |  | |  | |  | |  |\r\n   |  |    \\  \\_/  / \\  \\_/  /\r\n   |__|     \\_____/   \\_____/\r\n\t\t\t ______    _____   ________  ______\r\n\t\t\t|   _  \\  |     | |   ____/ |   _  \\\r\n\t\t\t|  | \\  \\  \\   /  |  |      |  | \\  \\\r\n\t\t\t|  | |  |  |   |  |  |__    |  | |  |\r\n                        |  | |  |  |   |  |   __|   |  | |  |\r\n\t\t\t|  | |  |  |   |  |  |      |  | |  |\r\n\t\t\t|  |_/  /  /   \\  |  |____  |  |_/  /\r\n\t\t\t|______/  |_____| |_______\\ |______/", 0, false);
                else gameService.PrintDeleyed("___    ___   _____    __   __\r\n\\  \\  /  /  /  _  \\  |  | |  |\r\n \\  \\/  /  /  / \\  \\ |  | |  |\r\n  \\    /   |  | |  | |  | |  |\r\n   \\  /    |  | |  | |  | |  |\r\n   |  |    |  | |  | |  | |  |\r\n   |  |    \\  \\_/  / \\  \\_/  /\r\n   |__|     \\_____/   \\_____/\r\n\t\t        __         _____     _____    ________\r\n                       |  \\       /  _  \\   /  _  \\  |   ____/\r\n                       |  |      /  / \\  \\ /  / \\__\\ |  |\r\n                       |  |      |  | |  | \\  \\___   |  |__\r\n                       |  |      |  | |  |  \\___  \\  |   __|\r\n                       |  |      |  | |  |  __  \\  \\ |  |\r\n                       |  |____  \\  \\_/  / \\  \\_/  / |  |____\r\n                       \\_______\\  \\_____/   \\_____/  |_______\\", 0,false);
                gameService.WaitPress(true);
                opponent = null;
                return false;
            }
            else // You win the duel
            {
                Console.Clear();
                gameService.PrintCaracterDetails(player);
                gameService.PrintCaracterDetails(opponent);
                gameService.PrintDeleyed("___    ___   _____    __   __\r\n\\  \\  /  /  /  _  \\  |  | |  |\r\n \\  \\/  /  /  / \\  \\ |  | |  |\r\n  \\    /   |  | |  | |  | |  |\r\n   \\  /    |  | |  | |  | |  |\r\n   |  |    |  | |  | |  | |  |\r\n   |  |    \\  \\_/  / \\  \\_/  /\r\n   |__|     \\_____/   \\_____/\r\n\t\t       ____                ____  ____   __    __\r\n\t\t       \\   \\              /   / |    | |  \\  |  |\r\n\t\t\t\\   \\     __     /   /   \\  /  |   \\ |  |\r\n\t\t\t \\   \\   /  \\   /   /    |  |  |    \\|  |\r\n                          \\   \\_/    \\_/   /     |  |  |        |\r\n\t\t\t   \\      /\\      /      |  |  |  |\\    |\r\n\t\t\t    \\    /  \\    /       /  \\  |  | \\   |\r\n\t\t\t     \\__/    \\__/       |____| |__|  \\__|", 0, false);
                gameService.WaitPress(true);
                Console.Clear();
                player.GetXp();
                return true;
            }
        }
        public bool WhoStartsTheAttack(Character player,Character opponent) // Kimin birinci başlıyacağı seçilir
        {
            Console.Clear();
            gameService.PrintCaracterDetails(player);
            gameService.PrintCaracterDetails(opponent);
            gameService.PrintDeleyed("Heads or Tails");
            gameService.PrintDeleyed("H - Heads | T - Tails");
            ConsoleKeyInfo key;
            int yourChoice = 0;
            bool working2 = true;
            while (working2)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.H:
                        yourChoice = 0;
                        working2 = false;
                        break;
                    case ConsoleKey.T:
                        yourChoice = 1;
                        working2 = false;
                        break;
                    default:
                        break;
                }
            }
            Random random = new Random();
            int headsOrTails = random.Next(0, 2);
            return (headsOrTails == yourChoice);
        }
        public int Dice() // Zər
        {
            gameService.PrintDeleyed("Press D to roll dice");
            gameService.WaitPress(true, ConsoleKey.D);
            Random random = new Random();
            int systemChoicedNum = random.Next(1, 7);
            string[] diceTexts = { $"The dice was rolled, and it landed on {systemChoicedNum}", $"The dice was rolled, and {systemChoicedNum} came up", $"The dice was thrown, and it showed {systemChoicedNum}" };
            gameService.PrintDeleyed(diceTexts[random.Next(0, diceTexts.Length)]);
            return systemChoicedNum;
        }
        public void OpponentAttack(Character player, Character opponent)
        {
            string[] higher = { "a higher number might come", "a higher roll could happen", "a higher one might show up", "it could be something higher" };
            string[] lower = { "a lower number might come", "a lower roll could happen", "a smaller number might show up", "it could be something lower" };
            Random random = new Random();
            int choicedNum;
            int choicedDirection;
            int choicedText;
            choicedNum = random.Next(1, 7);
            if (choicedNum != 1 && choicedNum != 6) choicedDirection = random.Next(0, 2);
            else
            {
                if (choicedNum == 1) choicedDirection = 0;
                else choicedDirection = 1;
            }
            choicedText = random.Next(0, choicedDirection == 0 ? higher.Length : lower.Length);
            Console.Clear();
            gameService.PrintCaracterDetails(player);
            gameService.PrintCaracterDetails(opponent);
            gameService.PrintDeleyed($"{opponent.Name} said,' {choicedNum} or " + (choicedDirection == 0 ? higher[choicedText] : lower[choicedText]) + ".'");
            Attacks(opponent, player, choicedNum, choicedDirection);
        } // Opponentin attack hazırlığı
        public void PlayerAttack(Character player, Character opponent) // Playerin attack hazırlığı
        {
            Random random = new Random();
            int choosedNum = 0;
            int choosedDirection = 0;
            string[] pickTexts = { "Pick", "Choose", "Select" };
            string pickText = pickTexts[random.Next(0, pickTexts.Length)];
            ConsoleKeyInfo key;
            Console.Clear();
            gameService.PrintCaracterDetails(player);
            gameService.PrintCaracterDetails(opponent);
            gameService.PrintDeleyed(pickText + " a number between 1 and 6.\nWhen you select 1 or 6 and hit a successful shot, you gain +10 damage.\nIf the shot fails, the damage reduction will increase by 2x.");
            bool working2 = true;
            while (working2)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        choosedNum = 1;
                        working2 = false;
                        break;
                    case ConsoleKey.D2:
                        choosedNum = 2;
                        working2 = false;
                        break;
                    case ConsoleKey.D3:
                        choosedNum = 3;
                        working2 = false;
                        break;
                    case ConsoleKey.D4:
                        choosedNum = 4;
                        working2 = false;
                        break;
                    case ConsoleKey.D5:
                        choosedNum = 5;
                        working2 = false;
                        break;
                    case ConsoleKey.D6:
                        choosedNum = 6;
                        working2 = false;
                        break;
                    default:
                        break;
                }
            }
            string[] DirectionTexts2 = { "Do you think the roll will be higher or lower than your chosen number?", "Will the next number be higher or lower than the one you picked?", "Do you expect the roll to come out higher or lower than your selection?", "Do you think it will be above or below your chosen number?" };
            if (choosedNum != 1 && choosedNum != 6)
            {
                Console.Clear();
                gameService.PrintCaracterDetails(player);
                gameService.PrintCaracterDetails(opponent);
                gameService.PrintDeleyed(DirectionTexts2[random.Next(0, DirectionTexts2.Length)]);
                gameService.PrintDeleyed("H - higher | L - lower");
                working2 = true;
                while (working2)
                {
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.H:
                            choosedDirection = 0;
                            working2 = false;
                            break;
                        case ConsoleKey.L:
                            choosedDirection = 1;
                            working2 = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Console.Clear();
                gameService.PrintCaracterDetails(player);
                gameService.PrintCaracterDetails(opponent);
                if (choosedNum == 1) choosedDirection = 0;
                else choosedDirection = 1;
            }
            gameService.PrintDeleyed($"Your number is {choosedNum} and " + (choosedDirection == 0 ? "higher" : "lower"));
            Attacks(player, opponent, choosedNum, choosedDirection);
        }
        public void Attacks(Character attacker, Character underAttack, int choosedNum, int choosedDirection) // Characterin attack-ı
        {
            Random random = new Random();
            bool damageTook = true;
            int systemChoicedNum;
            string attackerName = attacker.NPC ? attacker.Name : "Your";
            systemChoicedNum = Dice();
            if (systemChoicedNum == choosedNum)
            {
                if (choosedNum == 1 || choosedNum == 6)
                {
                    attacker.AttackPower += 10;
                    attacker.Attack(underAttack, true);
                    attacker.AttackPower -= 10;
                }
                else attacker.Attack(underAttack, true);
                string[] attackSuccessfully = { attackerName + (attacker.NPC ? "'s" : "") + " attack hits successfully!", (attackerName == "Your" ? "you" : attackerName) + " land" + (attacker.NPC ? "s" : "") + " a powerful strike!", attackerName + (attacker.NPC ? "'s" : "") + " blow connect" + (attacker.NPC ? "s" : "") + " with full force!", attackerName + (attacker.NPC ? "'s" : "") + " attack land" + (attacker.NPC ? "s" : "") + " perfectly!", attackerName + (attacker.NPC ? "'s" : "") + " deliver" + (attacker.NPC ? "s" : "") + " a successful hit!" };
                gameService.PrintDeleyed(attackSuccessfully[random.Next(0, attackSuccessfully.Length)]);
            }
            else if ((systemChoicedNum > choosedNum && choosedDirection == 0) || (systemChoicedNum < choosedNum && choosedDirection == 1))
            {
                int attackDec = systemChoicedNum - choosedNum;
                if (attackDec < 0) attackDec *= -1;
                if (choosedNum == 1 || choosedNum == 6) attackDec *= 2;
                string[] attackHit = { attackerName + (attacker.NPC ? "'s" : "") + " attack hit" + (attacker.NPC ? "s" : "") + ", but " + (attackerName == "Your" ? "you're" : "it's") + " slightly weaker than expected.", attackerName + (attacker.NPC ? "'s" : "") + " strike land" + (attacker.NPC ? "s" : "") + $", but with {attackDec} less power.", attackerName + (attacker.NPC ? "'s" : "") + " attack connect" + (attacker.NPC ? "s" : "") + $", though not at full strength ({attackDec})", attackerName + (attacker.NPC ? "'s" : "") + " land" + (attacker.NPC ? "s" : "") + " a hit, but " + (attackerName == "Your" ? "you" : "it") + " fall" + (attacker.NPC ? "s" : "") + $" short of full power ({attackDec}).", attackerName + (attacker.NPC ? "'s" : "") + " hit" + (attacker.NPC ? "s" : "") + $" successfully, but with a {attackDec} power reduction." };
                gameService.PrintDeleyed(attackHit[random.Next(0, attackHit.Length)]);
                attacker.AttackPower -= attackDec;
                attacker.Attack(underAttack, false);
                attacker.AttackPower += attackDec;
            }
            else
            {
                string[] attackMiss = { attackerName + (attacker.NPC ? "'s" : "") + " attack miss" + (attacker.NPC ? "es!" : "!"), attackerName + (attacker.NPC ? "'s" : "") + " strike fail" + (attacker.NPC ? "s" : "") + " to connect.", (attackerName == "Your" ? "You" : attackerName) + " swing" + (attacker.NPC ? "s" : "") + ", but the attack misses the mark.", attackerName + (attacker.NPC ? "'s" : "") + " attack fail" + (attacker.NPC ? "s!" : "!"), attackerName + (attacker.NPC ? "'s" : "") + " blow fall" + (attacker.NPC ? "s" : "") + " short and miss" + (attacker.NPC ? "es." : ".") };
                gameService.PrintDeleyed(attackMiss[random.Next(0, attackMiss.Length)]);
                damageTook = false;
            }
            attacker.SpecialUsed(underAttack);
            underAttack.SpecialUsed(attacker);
            if(damageTook) gameService.PrintDeleyed($"Total damage : {underAttack.PresentDamage}");
            gameService.WaitPress(true);
        }
    }
}