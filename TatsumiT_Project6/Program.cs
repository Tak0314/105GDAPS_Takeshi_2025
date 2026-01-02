namespace TatsumiT_Project6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ghost ghost1 = new Ghost("Schweppes", 200, 125, 6, 10, 5);
            Ghost ghost2 = new Ghost("Canada Dry", 190, 100, 8, 15, 9);
            Dark dark1 = new Dark("Pepsi", 220, 75, 5, 12, 15);
            Dark dark2 = new Dark("CocaCola", 180, 142, 9, 7, 20);


            List<CommonCharacter> commonCharacters = new List<CommonCharacter>{ghost1, ghost2, dark1, dark2};
            BattleField battle = new BattleField(commonCharacters, false);

            Console.WriteLine("*************************************************");
            Console.WriteLine("Introducing the battlers!");
            Console.WriteLine("*************************************************");
            for (int i = 0; i < commonCharacters.Count; i++)
            {
                Console.WriteLine($"Battler #{i + 1}: {commonCharacters[i].Name}");
            }
            for (int i = 0; i < commonCharacters.Count; i++)
            {
                Console.WriteLine(". . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .");
                Console.WriteLine(commonCharacters[i].ToString());
            }


            battle.RunBattle();

        }
    }
}
