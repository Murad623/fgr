using _18oct.Classes;
using _18oct.Classes.Base;
using _18oct.Services.BaseService;
namespace _18oct.Services
{
    internal class TournamentMode : GameVarables
    {
        GameService gameService = new GameService();
        DuelService duelService = new DuelService();
        Character playerClone;
        public bool StartTournament(Character player)
        {
            PClone(player);
            for (int i = 0; i < opponentNames.Length; i++)
            {
                Console.Clear();
                Random random = new Random();
                string oppName = gameService.chooseRandomName(opponentNames, usedNames);
                usedNames[i] = oppName;
                Character opponent = charachterTypes[random.Next(charachterTypes.Length)];
                opponent.SetNPC(true);
                opponent.SetRace(racesChar[random.Next(0, races.Length)]);
                opponent.SetName(oppName);
                for (int j = 0; j < player.Level; j++) opponent.Levelup();  // => Opponent level = Player level
                //opponent.Health = 1; // test
                Console.WriteLine(opponent.Level);
                gameService.WaitPress(true);
                if (!duelService.Duel(playerClone, opponent, false, true)) return false;
                if(playerClone.Health < playerClone.MaxHealth)playerClone.CharacterHealing();
            }
            player = playerClone;
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
        }
    }
}
