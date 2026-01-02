using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatsumiT_Project6
{
    internal class BattleField
    {
        private List<CommonCharacter> battlers;
        private bool debug;
        private Random rng;

        /// <summary>
        /// constructor of the battle field
        /// </summary>
        /// <param name="battlers">list of commoncharacters.</param>
        /// <param name="debug">bool of debug or not</param>
        public BattleField(List<CommonCharacter> battlers, bool debug)
        {
            this.battlers = battlers;
            this.debug = debug;
            this.rng = new Random();
        }

        /// <summary>
        /// start battle 
        /// </summary>
        public void RunBattle()
        {
            string input;
            int round = 1;
            while (battlers.Count > 1)
            {
                Console.WriteLine();
                Console.WriteLine("*************************************************");
                Console.WriteLine($"Round {round} - FIGHT!");
                Console.WriteLine("*************************************************");
                Round();
                round++;
                Console.Write("Press enter key to continue");
                input = Console.ReadLine()!;

            }

            Console.WriteLine();
            Console.WriteLine("*************************************************");
            Console.WriteLine("BATTLE ROYALE finished!");
            Console.WriteLine("*************************************************");
            if (battlers.Count == 1)
            {
                Console.WriteLine($"Winner: {battlers[0].Name}!");
            }
            else
            {
                Console.WriteLine("Everyone has fallen or fled. No winner.");
            }
        }
        public void Round()
        {
           /* compare speed and fastest will attack first
            * if three of the battler is readytoflee, finish round
            * if health went lower than some numbers, ask user to use character abilities
            * 
            */
            List<CommonCharacter> speedOrder = battlers.OrderByDescending(character => character.Speed).ToList();

            //loop for times the characters
            for (int i = 0; i < speedOrder.Count; i++)
            {
                //checks if battler can attack othe
                int cannotBattle = 0;
                for (int j = 0; j < speedOrder.Count; j++)
                {
                    if (speedOrder[j].ReadyToFlee())
                    {
                        cannotBattle ++;
                    }
                }

                //if battler is dead, or number of battler that can battle is less than or equal to 1, skip the turn
                if (speedOrder[i].IsDead || speedOrder.Count - cannotBattle <= 1)
                {
                    continue;
                }

                //loop until the target is not dead or not the character self
                int targetIndex = rng.Next(0, speedOrder.Count);
                while (speedOrder[targetIndex].IsDead || speedOrder[targetIndex] == speedOrder[i])
                {
                    targetIndex = rng.Next(0, speedOrder.Count);
                }

                //if health meets the requirement to activate ability, ask player use or not
                if (speedOrder[i] is Ghost ghost && ghost.Health < 50 && !ghost.AbilityUsed)
                {
                    Console.Write("Do you want to use ability? Type 'yes' or 'no': ");
                    string useOrNo = Console.ReadLine()!.ToLower();
                    if (useOrNo == "yes")
                    {
                        ghost.Fear();
                        Console.WriteLine($"{speedOrder[i].Name} used Fear, {speedOrder[i].Name} is giving off a terrifying aura...");
                    }
                }
                else if (speedOrder[i] is Dark dark && dark.Health < 40 && !dark.AbilityUsed)
                {
                    Console.Write("Do you want to use ability? Type 'yes' or 'no': ");
                    string useOrNo = Console.ReadLine()!.ToLower();
                    while (useOrNo != "yes" && useOrNo != "no")
                    {
                        Console.Write("Please enter valid input. Type 'yes' or 'no': ");
                        useOrNo = Console.ReadLine()!.ToLower();
                    }
                    if (useOrNo == "yes")
                    {
                        dark.Rage();
                        Console.WriteLine($"{speedOrder[i].Name} used Rage, {speedOrder[i].Name} is Angry!");
                    }
                }

                //attack
                int damage = speedOrder[i].Attack();
                int actualDamage = speedOrder[targetIndex].TakeDamage(damage);
                Console.WriteLine($"{speedOrder[i].Name} attacks {speedOrder[targetIndex].Name} for {actualDamage} damage!");

            }

            //print battlers status at the end of the round
            Console.WriteLine(">> Character Status <<");
            for (int i = 0; i < battlers.Count; i++)
            {
                Console.WriteLine(battlers[i].ToString());
            }

            //remove battlers that can't battle anymore
            for (int i = battlers.Count -1; i >= 0; i--)
            {
                if (battlers[i].IsDead || battlers[i].ReadyToFlee())
                {
                    battlers.RemoveAt(i);
                }
            }
        }
    }
}
