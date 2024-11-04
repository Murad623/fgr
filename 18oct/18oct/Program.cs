﻿using _18oct.Classes;
using _18oct.Classes.Base;
using _18oct.Services;
bool working = true;
Character player;
GameService gameService = new GameService();
DuelService duelService = new DuelService();
CampaignMode campaignMode = new CampaignMode();
TournamentMode tournamentMode = new TournamentMode();
string[] messages = { "Hi Adventurer", "Welcome to 'Lumena', our magical world", "Create your character and start new adventure", "But careful, if you close the game, you have to start over" };
//Character[] charachterTypes = { new Mage() }; // char test
//Character[] charachterTypes = { new Worrior(), new Archer(), new Mage() };
//char[] racesChar = { 'H', 'G', 'O', 'E', 'D' };
//string[] races = { "Human", "Goblin", "Orc", "Elf", "Dwarf" };
//string[] opponentNames = { "Kamil", "Mikayil", "Cavid", "Shamil", "Ferid", "Musa", "Pasha", "Shahin", "Arzu", "Leman", "Aydan", "Fidan", "Aysel", "Aygun", "Leyla", "Lale" };
//string[] usedNames = { };
for (int i = 0; i < messages.Length; i++) gameService.PrintDeleyed(messages[i]);
gameService.WaitPress(true);
while (working) // Main
{
    player = gameService.CharacterCreator();
    gameService.PrintDeleyed("Choose game mode :");
    gameService.PrintDeleyed("T - Tournament | C - Campaign");
    bool gMode = false;
    while (working)
    {
        ConsoleKeyInfo key;
        key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.T:
                gMode = true;
                working = false;
                break;
            case ConsoleKey.C:
                gMode = false;
                working = false;
                break;
            default:
                break;
        }
    }
    if (gMode)
    {
        working = true;
        while (working)
        {
            bool tResult = tournamentMode.StartTournament(player);
            Console.Clear();
            gameService.PrintCaracterDetails(player);
            gameService.PrintDeleyed("ESC - Quit | "+(tResult? "T - Try Again":"P - New Game Plus"));
            // try again - turnuvaya neçə levelnən girilmişdisə oynan başlatır
            // NGP - turnuvanı bitirdiyin levelnən başlıyırsan
            break;
        }
    }
    else campaignMode.StartCampaign(player);
    break;
}