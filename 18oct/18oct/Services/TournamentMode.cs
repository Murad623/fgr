using _18oct.Classes;
using _18oct.Classes.Base;
using _18oct.Services.BaseService;
namespace _18oct.Services
{
    internal class TournamentMode
    {
        GameService gameService = new GameService();
        DuelService duelService = new DuelService();
        GameVarables gVars = new GameVarables();
        //Random random = new Random();
        Character playerClone;
        public bool StartTournament(ref Character player)
        {
            PClone(player);
            for (int i = 0; i < gVars.opponentNames.Length; i++)
            {
                for (int c = 3; c > 0; c--)
                {
                    Console.Clear();
                    for (int l = 0; l < 3; l++)
                    {
                        if (l==1)
                        {
                            Console.Write("|");
                            int space1 = ((Console.WindowWidth - (i.ToString().Length+"Round #".Length)) / 2)-1;
                            for (int r = 0; r < space1; r++) Console.Write(" ");
                            Console.Write("Round #"+(i+1));
                            for (int r = 0; r < space1; r++) Console.Write(" ");
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write("+");
                            for (int j = 0; j < Console.WindowWidth-2; j++) Console.Write("-");
                            Console.WriteLine("+");
                        }
                    }
                    Console.WriteLine();
                    switch (c)
                    {
                        case 1:
                            Console.WriteLine("    ___\r\n   /   |\r\n  /_   |\r\n    |  |\r\n    |  |\r\n    |  |\r\n   _|  |_\r\n  /______\\");
                            break;
                        case 2:
                            Console.WriteLine("  _______\r\n /  ___  \\\r\n/__/   \\  \\\r\n      _/  /\r\n    _/  _/\r\n  _/  _/\r\n /   /____\r\n/_________|");
                            break;
                        case 3:
                            Console.WriteLine("  _______\r\n /  ___  \\\r\n/__/   \\  \\\r\n     __/  /\r\n    /__  |\r\n___    \\  \\\r\n\\  \\___/  /\r\n \\_______/");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("\nPress [Space] to skip");
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Spacebar) break;
                    }
                    else Thread.Sleep(1000);
                }
                Character opponent = gameService.RCG(gVars);
                for (int j = 0; j < playerClone.Level; j++) opponent.Levelup();  // => Opponent level = Player level
                //opponent.Health = 1; // test
                if (!duelService.Duel(playerClone, opponent, false, true)) return false;
                if(playerClone.Health < playerClone.MaxHealth)playerClone.CharacterHealing();
            }
            player = playerClone;
            player.Health = player.MaxHealth;
            for (int i = 0; i < gVars.usedNames.Length; i++) gVars.usedNames[i] = "";
            return true;
        }
        void PClone(Character player)
        {
            switch (player.Type()[0])
            {
                case 'W':
                    playerClone = new Worrior();
                    break;
                case 'A':
                    playerClone = new Archer();
                    break;
                case 'M':
                    playerClone = new Mage();
                    break;
                default:
                    break;
            }
            playerClone.SetRace(player.Race[0]);
            playerClone.SetName(player.Name);
            playerClone.SetNPC(true);
            for (int j = 0; j < player.Level; j++) playerClone.Levelup();
            playerClone.SetNPC(false);
            playerClone.Xp = player.Xp;
        }
    }
}
