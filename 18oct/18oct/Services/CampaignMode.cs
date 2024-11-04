using _18oct.Classes.Base;
using _18oct.Services.BaseService;
namespace _18oct.Services
{
    internal class CampaignMode : GameVarables
    {
        GameService gameService = new GameService();
        DuelService duelService = new DuelService();
        ////public Character[] charachterTypes = { new Mage() }; // char test
        //public Character[] charachterTypes = { new Worrior(), new Archer(), new Mage() };
        //public char[] racesChar = { 'H', 'G', 'O', 'E', 'D' };
        //public string[] races = { "Human", "Goblin", "Orc", "Elf", "Dwarf" };

        public bool StartCampaign(Character player)
        {
            Console.Clear();
            #region Chapter 1 : Start to journey
            gameService.PrintCaracterDetails(player);
            Random random = new Random();
            int cType = random.Next(charachterTypes.Length);
            int cRace = random.Next(0, races.Length);
            /*    Test
            int ctype = 1;
            int crace = 3;*/
            string oppName = gameService.chooseRandomName(opponentNames,usedNames);
            bool aggressive = false;
            bool aggressivePlus = false;
            bool duelOffered = false;
            bool nameGived = false;
            bool run = false;
            bool working = true;
            gameService.PrintDeleyed("You are walking in the forest.");
            gameService.PrintDeleyed($"You see a {charachterTypes[cType].Type()} {races[cRace]} in your path.");
            gameService.WaitPress(true);
            Console.Clear();
            if ((player.Race != "Orc" && races[cRace] != "Orc") || player.Race == races[cRace])
            {
                gameService.PrintDeleyed($"{races[cRace]} :\n - Hey, who are you ?");
                gameService.PrintDeleyed($"S - Say your name. | D - Don't say anything. | A - Give an aggressive answer. | R - Run");
                while (working)
                {
                    ConsoleKeyInfo key;
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.S:
                            working = false;
                            duelOffered = true;
                            nameGived = true;
                            break;
                        case ConsoleKey.D:
                            working = false;
                            aggressive = true;
                            duelOffered = true;
                            break;
                        case ConsoleKey.A:
                            working = false;
                            aggressive = true;
                            aggressivePlus = true;
                            break;
                        case ConsoleKey.R:
                            working = false;
                            run = true;
                            break;
                        default:
                            break;
                    }
                }
                if (!run)
                {
                    string[] trainingTexts = { "Do you want to do some fight training with me", "Would you like to train for a fight with me", "How about doing some combat practice with me", "Would you be interested in doing fight training with me" };
                    if (duelOffered) //Duel təklifi var
                    {
                        if (!aggressive) gameService.PrintDeleyed($"{races[cRace]} :\n - I'm {oppName}");
                        gameService.PrintDeleyed((!nameGived ? races[cRace] : oppName) + $" :\n - " + (aggressive ? trainingTexts[random.Next(trainingTexts.Length)] : (player.Name + ", " + trainingTexts[random.Next(trainingTexts.Length)].ToLower())) + " ?");
                        gameService.PrintDeleyed($"A - Accept | R - Reject | D - Don't say anything");
                        working = true;
                        while (working)
                        {
                            ConsoleKeyInfo key;
                            key = Console.ReadKey(true);
                            switch (key.Key)
                            {
                                case ConsoleKey.A:
                                    working = false;
                                    aggressive = false;
                                    break;
                                case ConsoleKey.R:
                                    working = false;
                                    aggressive = false;
                                    duelOffered = false;
                                    break;
                                case ConsoleKey.D:
                                    working = false;
                                    aggressive = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    if (duelOffered || aggressive) // duel var
                    {
                        Character opponent = charachterTypes[cType];
                        if (nameGived) opponent.Name = oppName;
                        else
                        {
                            opponent.Name = "";
                            for (int i = 0; i < oppName.Length; i++) opponent.Name += "?";
                        }
                        opponent.SetNPC(true);
                        opponent.SetRace(racesChar[cRace]);
                        if (aggressive && !aggressivePlus) gameService.PrintDeleyed($"{opponent.Type()} :\n - AAAAAAAAAAAAAAAAAAAAGGGGGGGGGHhhhhhhhhh\n - Hey! Are you even listening?\n - I've been talking to you this whole time, and you're just standing there!\n - What's the matter with you?\n - Say something!\n - Don't just ignore me!\n - Seriously, how hard is it to respond?\n - I'm right here!\n - I'll kill you !!!", 20);
                        for (int i = 0; i < player.Level; i++) opponent.Levelup();  // => Opponent level = Player level
                        if (!duelService.Duel(player, opponent, aggressive))
                        {
                            if (aggressive) return false;
                            Console.Clear();
                            gameService.PrintDeleyed((!nameGived ? charachterTypes[cType].Type() : oppName) + " :");
                            gameService.PrintDeleyed(" - Don't worry " + (nameGived ? player.Name : "Adventurer"));
                            gameService.PrintDeleyed(" - I'm giving you 1 Xp.");
                            gameService.PrintDeleyed(" - Take it pleace.");
                            gameService.WaitPress(true);
                            player.GetXp();
                        }
                    }
                    else
                    {
                        gameService.PrintDeleyed((nameGived ? oppName : races[cRace]) + "\n - Ok, " + (nameGived ? player.Name : "Adventurer") + ", good luck on your journey.");
                        gameService.WaitPress(true);
                    }
                }
                else
                {
                    gameService.PrintDeleyed("You :");
                    gameService.PrintDeleyed(" - Aaa Aaaa AAaaaaAaaaaa");
                    gameService.PrintDeleyed(" - AAaaaAaAaaaaAaa AaaaAAaaAaa");
                    gameService.PrintDeleyed($"{races[cRace]} :");
                    gameService.PrintDeleyed(" - Why are you running ?");
                    string[] wayr = { " - WHY", " ARE", " YOU", " RUNNING ?" };
                    gameService.PrintDeleyed(null, 400, true, wayr);
                    gameService.WaitPress(true);
                }
            }
            else
            {
                gameService.PrintDeleyed($"The {races[cRace].ToLower()} started attacking you");
                Character opponent = charachterTypes[cType];
                if (nameGived) opponent.Name = oppName;
                else
                {
                    opponent.Name = "";
                    for (int i = 0; i < oppName.Length; i++) opponent.Name += "?";
                }
                opponent.SetNPC(true);
                opponent.SetRace(racesChar[cRace]);
                duelService.Duel(player, opponent, true);
            }
            Console.Clear();
            gameService.PrintCaracterDetails(player);
            #endregion
            #region Chapter 2 : Strange events
            gameService.PrintDeleyed("You left there and continued on your way.");
            gameService.PrintDeleyed("You moved forward a little, and then you come to a fork in the road : ");
            gameService.PrintDeleyed("one path leads into the forest, while the other leads to a village.");
            gameService.PrintDeleyed("Choose your path :");
            gameService.PrintDeleyed("F - Forest | V - Village");
            bool path = false;
            working = true;
            while (working)
            {
                ConsoleKeyInfo key;
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.F:
                        working = false;
                        path = false;
                        break;
                    case ConsoleKey.V:
                        working = false;
                        path = true;
                        break;
                    default:
                        break;
                }
            }
            Console.Clear();
            gameService.PrintDeleyed("You followed the path and arrived at the " + (path ? "village." : "forest."));
            if (path)
            {
                if (player.Race != "Orc")
                {
                    gameService.PrintDeleyed("There is chaos in the village.");
                    gameService.PrintDeleyed("I - Investigate the cause of the chaos | S - Steal some food from the village");
                    bool choice = false;
                    working = true;
                    while (working)
                    {
                        ConsoleKeyInfo key;
                        key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.I:
                                working = false;
                                choice = false;
                                break;
                            case ConsoleKey.S:
                                working = false;
                                choice = true;
                                break;
                            default:
                                break;
                        }
                    }
                    if (choice)
                    {
                        gameService.PrintDeleyed("You ate and drink whatever you found (food, fruit, salad, water, vine, beer) you were satisfied.");
                        player.CharacterHealing(true);
                    }
                    else
                    {
                        gameService.PrintDeleyed("The village chief : ");
                        gameService.PrintDeleyed(" - There is a gang hiding in the forest, and they are preparing to attack to take over the village.");
                        gameService.PrintDeleyed(" - If we act before they do, we have a chance to win.");
                        gameService.PrintDeleyed("H - Help them | N - Never mind");
                        working = true;
                        while (working)
                        {
                            ConsoleKeyInfo key;
                            key = Console.ReadKey(true);
                            switch (key.Key)
                            {
                                case ConsoleKey.H:
                                    working = false;
                                    choice = false;
                                    break;
                                case ConsoleKey.N:
                                    working = false;
                                    choice = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (choice) gameService.PrintDeleyed("You left the village");
                        else
                        {
                            gameService.PrintDeleyed("You joined the villagers, and you all started heading toward the forest.");
                            gameService.PrintDeleyed("You encountered the gang in a valley between the forest and the village, and the battle began.");
                            cType = random.Next(charachterTypes.Length);
                            Character opponent = charachterTypes[cType];
                            oppName = gameService.chooseRandomName(opponentNames,usedNames);
                            opponent.Name = "";
                            for (int i = 0; i < oppName.Length; i++) opponent.Name += "?";
                            opponent.SetNPC(true);
                            opponent.SetRace('H');
                            if (!duelService.Duel(player, opponent, true)) return false;
                            Console.WriteLine(" __    __   ________ ___     ___ ____________\r\n|  \\  |  | |   ____/ \\  \\   /  / \\__      __/\r\n|   \\ |  | |  |       \\  \\_/  /     \\    /\r\n|    \\|  | |  |__      \\     /       |  |\r\n|        | |   __|      |   |        |  |\r\n|  |\\    | |  |        /  _  \\       |  |\r\n|  | \\   | |  |____   /  / \\  \\      |  |\r\n|__|  \\__| |_______\\ /__/   \\__\\    /____\\");
                            Console.SetCursorPosition(0, Console.WindowHeight);
                            gameService.WaitPress(true);
                            cType = random.Next(charachterTypes.Length);
                            opponent = charachterTypes[cType];
                            oppName = gameService.chooseRandomName(opponentNames, usedNames);
                            opponent.Name = "";
                            for (int i = 0; i < oppName.Length; i++) opponent.Name += "?";
                        }
                    }
                }
            }
            #endregion

            #region End
            Console.WriteLine(" ________  __    __   ______\r\n|   ____/ |  \\  |  | |   _  \\\r\n|  |      |   \\ |  | |  | \\  \\\r\n|  |__    |    \\|  | |  | |  |\r\n|   __|   |        | |  | |  |\r\n|  |      |  |\\    | |  | |  |\r\n|  |____  |  | \\   | |  |_/  /\r\n|_______\\ |__|  \\__| |______/");
            #endregion
            return false;
        }
    }
}
