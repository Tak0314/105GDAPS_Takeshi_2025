using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatsumiT_Project5
{
    internal class Dice
    {
        private Random rng;

        /// <summary>
        /// default constructor
        /// create new Random
        /// </summary>
        public Dice()
        {
             rng = new Random();
        }

        /// <summary>
        /// Roll one six sided die
        /// </summary>
        /// <returns>random number 1-6</returns>
        public int RollOneDie()
        {
            return rng.Next(1, 7);
        }
        
        /// <summary>
        /// Roll multiple six sided dice
        /// </summary>
        /// <param name="numberOfDice">number of Dice</param>
        /// <returns>sum of the result of RollOneDie</returns>
        public int RollMultipleDice(int numberOfDice)
        {
            int sum = 0;
            for (int i = 0; i < numberOfDice; i++)
            {
                sum += RollOneDie();
            }
            return sum;
        }
    }
}
