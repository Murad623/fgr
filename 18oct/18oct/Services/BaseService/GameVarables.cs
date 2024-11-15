using _18oct.Classes.Base;
using _18oct.Classes;

namespace _18oct.Services.BaseService
{
    public class GameVarables
    {
        //public Character[] charachterTypes = { new Mage() }; // char test
        //public Character[] charachterTypes = { new Worrior(), new Archer(), new Mage() };
        public char[] racesChar = { 'H', 'G', 'O', 'E', 'D' };
        public string[] races = { "Human", "Goblin", "Orc", "Elf", "Dwarf" };
        public string[] opponentNames = { "Kamil", "Mikayil", "Cavid", "Shamil", "Ferid", "Musa", "Pasha", "Shahin", "Arzu", "Leman", "Aydan", "Fidan", "Aysel", "Aygun", "Leyla", "Lale" };
        //public string[] opponentNames = { "Kamil", "Mikayil", "Cavid", "Shamil" }; // test
        //public string[] opponentNames = { "Kamil" }; // test 2
        public string[] usedNames;
        public GameVarables()
        {
            usedNames = new string[opponentNames.Length];
        }
    }
}
