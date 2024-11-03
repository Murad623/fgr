using _18oct.Classes.Base;
using _18oct.Services.BaseService;
using System.ComponentModel;
using System.Xml.Linq;

namespace _18oct.Services
{
    internal class TournamentMode : GameVarables
    {
        GameService gameService = new GameService();
        DuelService duelService = new DuelService();
        public bool StartTournament(Character player)
        {
            for (int i = 0; i < opponentNames.Length; i++)
            {
                Console.Clear();
                Random random = new Random();
                int cType = random.Next(charachterTypes.Length);
                int cRace = random.Next(0, races.Length);
                string oppName = gameService.chooseRandomName(opponentNames, usedNames);
                usedNames[i] = oppName;
                Character opponent = charachterTypes[cType];
                opponent.SetNPC(true);
                opponent.SetRace(racesChar[cRace]);
                opponent.SetName(oppName);
                if (!duelService.Duel(player, opponent, false, true)) return false;
                player.CharacterHealing();
            }
            return true;
        }
    }
}
