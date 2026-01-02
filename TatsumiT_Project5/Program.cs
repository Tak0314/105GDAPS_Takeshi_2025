/*Takeshi Tatsumi
 * 11/18/2025
 * Project 5
 */
namespace TatsumiT_Project5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dice d = new Dice();

            int sum = 0;
            double average;
            int roll;
            for (int i = 0; i < 100; i++)
            {
                roll = d.RollOneDie();
                sum += roll;
                Console.Write(roll + " ");
            }
            average = sum / 100.0;
            Console.WriteLine();
            Console.WriteLine("Average roll for a single die: " + average);
            sum = 0;
            for (int i = 0; i < 100; i++)
            {
                roll = d.RollMultipleDice(2);
                sum += roll;
                Console.Write(roll + " ");
            }
            average = sum / 100.0;
            Console.WriteLine();
            Console.WriteLine("Average roll for 2 dice: " + average);

            Monopoly myMonopoly = new Monopoly(100000, 25);
            myMonopoly.PrintResults(myMonopoly.Analyze());
        }
    }
}
