using _18oct.Classes.Base;
using _18oct.Classes;

namespace _18oct.Services
{
    public class GameService
    {
        string playerName = string.Empty;
        
        public void PrintDeleyed(string? word = null, int delay = 100, bool dState = true, string[]? words = null) // Print letters with deley
        {
            if (word != null || words != null)
            {
                //if (center) Console.SetCursorPosition((Console.WindowWidth - (word == null ? words.Length : word.Length)) / 2, Console.CursorTop);
                for (int i = 0; i < (word == null ? words.Length : word.Length); i++)
                {
                    Console.Write(word == null ? words[i] : word[i]);
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key;
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Spacebar) dState = false;
                    }
                    if (dState)
                    {
                        //Console.Beep();
                        //Console.Beep(3000, delay/2);
                        Thread.Sleep(delay/2);
                    }
                }
            }
            Console.Write("\n");
        }
        public void WaitPress(bool waitSys, ConsoleKey key = ConsoleKey.Spacebar) // Wait for any key
        {
            if (waitSys)
            {
                if (key == ConsoleKey.Spacebar) PrintDeleyed("Press [Space] to skip");
                while (Console.ReadKey(true).Key != key) { }
            }
        }
        public void TurnOfGame() // Quit
        {
            Console.Clear();
            bool working2 = true;
            while (working2)
            {
                Console.WriteLine("Are you sure ?\nIf you close the game, you have to start over");
                Console.WriteLine("Y - Yes | N - No");
                ConsoleKeyInfo key;
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Y:
                        working2 = false;
                        break;
                    case ConsoleKey.N:
                        working2 = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public Character CharacterCreator() // Character creating process
        {
            Character character = null;
            ConsoleKeyInfo key;
            bool working1 = true;
            while (working1)
            {
                bool working2 = true;
                while (working2)
                {

                    Console.Clear();
                    Console.WriteLine("" +
                        "Character class\n" +
                        "W - Worrior | A - Archer | M - Mage | I - Info | ESC - Quit");
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.W:
                            character = new Worrior();
                            working2 = false;
                            break;
                        case ConsoleKey.A:
                            character = new Archer();
                            working2 = false;
                            break;
                        case ConsoleKey.M:
                            character = new Mage();
                            working2 = false;
                            break;
                        case ConsoleKey.I:
                            Console.Clear();
                            TypesInfo(new Worrior());
                            TypesInfo(new Archer());
                            TypesInfo(new Mage());
                            WaitPress(true);
                            break;
                        case ConsoleKey.Escape:
                            TurnOfGame();
                            break;
                        default:
                            break;
                    }
                }
                working2 = true;
                while (working2)
                {
                    Console.Clear();
                    Console.WriteLine("Race : ");
                    Console.WriteLine("H - Human | G - Goblin | O - Orc | E - Elf | D - Dwarf | I - Info | ESC - Back");
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.H:
                            character.SetRace('H');
                            working1 = false;
                            working2 = false;
                            break;
                        case ConsoleKey.G:
                            character.SetRace('G');
                            working1 = false;
                            working2 = false;
                            break;
                        case ConsoleKey.O:
                            character.SetRace('O');
                            working1 = false;
                            working2 = false;
                            break;
                        case ConsoleKey.E:
                            character.SetRace('E');
                            working1 = false;
                            working2 = false;
                            break;
                        case ConsoleKey.D:
                            character.SetRace('D');
                            working1 = false;
                            working2 = false;
                            break;
                        case ConsoleKey.I:
                            RacesInfo();
                            break;
                        case ConsoleKey.Escape:
                            working2 = false;
                            break;
                        default:
                            break;
                    }
                }
                working2 = true;
            }
            Console.Clear();
            Console.Write("Name : ");
            playerName = Console.ReadLine().Trim();
            if (playerName != "") character.SetName(playerName);
            Console.Clear();
            return character;
        }
        public void TypesInfo(Character character) // Get info about character types
        {
            string[] details = { $"{character.Type()}", "------------------", $"Health : {character.Health}", $"Attack Power : {character.AttackPower}", $"\nCharacter Spacial :\n{character.CharacterSpecial()}", "------------------\n" };
            foreach (string item in details)
            {
                PrintDeleyed(item);
            }
        }
        public void RacesInfo() // İrqlər haqqında məlumat
        {
            Console.Clear();
            string[] extras = { "Human", "------------------", "Health x1.35", "Xp x2", "------------------\n", "Goblin", "------------------", "Health +10", "Xp x3", "------------------\n", "Orc", "------------------", "Attack Power +10", "Xp x2", "------------------\n", "Elf", "------------------", "Health +30", "Attack Power +15", "------------------\n", "Dwarf", "------------------", "Attack Power x2", "Xp x4", "------------------", };
            foreach (var item in extras)
            {
                PrintDeleyed(item);
            }
            WaitPress(true);
        }
        public void PrintCaracterDetails(Character character) // Top bar, about player's charecter
        {
            Console.Write("+");
            for (int i = 0; i < character.Name.Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            for (int i = 0; i < character.Health.ToString().Length + ("Health : ").Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            for (int i = 0; i < character.Race.Length + ("Race : ").Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            for (int i = 0; i < character.Type().Length + ("Type : ").Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            for (int i = 0; i < character.AttackPower.ToString().Length + ("Attack Power : ").Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            for (int i = 0; i < character.Level.ToString().Length + ("Level : ").Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            if (character.NPC)
            {
                for (int i = 0; i < "NPC".Length + 2; i++)
                {
                    Console.Write("-");
                }
            }
            else
            {
                for (int i = 0; i < character.Xp.ToString().Length + ("Xp : ").Length + 2; i++)
                {
                    Console.Write("-");
                }
            }
            Console.Write("+\n");
            Console.WriteLine($"| {character.Name} | Health : {character.Health} | Race : {character.Race} | Type : {character.Type()} | Attack Power : {character.AttackPower} | Level : {character.Level} " + (character.NPC ? "| NPC |" : $"| Xp : {character.Xp} |"));
            Console.Write("+");
            for (int i = 0; i < character.Name.Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            for (int i = 0; i < character.Health.ToString().Length + ("Health : ").Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            for (int i = 0; i < character.Race.Length + ("Race : ").Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            for (int i = 0; i < character.Type().Length + ("Type : ").Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            for (int i = 0; i < character.AttackPower.ToString().Length + ("Attack Power : ").Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            for (int i = 0; i < character.Level.ToString().Length + ("Level : ").Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            if (character.NPC)
            {
                for (int i = 0; i < "NPC".Length + 2; i++)
                {
                    Console.Write("-");
                }
            }
            else
            {
                for (int i = 0; i < character.Xp.ToString().Length + ("Xp : ").Length + 2; i++)
                {
                    Console.Write("-");
                }
            }
            Console.Write("+\n");
        }
        public string chooseRandomName(string[] allNames, string[] usedNames)
        {
            Random random = new Random();
            string name = allNames[random.Next(allNames.Length)];
            if (usedNames.Length > 0)
            {
                bool checkName = true;
                while (checkName)
                {
                    for (int i = 0; i < usedNames.Length; i++)
                    {
                        if (Array.IndexOf(usedNames, name) > -1) break;
                        else checkName = false;
                    }
                    if(checkName) name = allNames[random.Next(allNames.Length)];
                }
            }
            return name;
        }
    }
}