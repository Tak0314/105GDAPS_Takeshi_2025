using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TatsumiT_Project5
{
    internal class Monopoly
    {
        private Dice myDice;
        private String[] propertyNames = 
        {
                "Go",
                "Mediterranean Avenue",
                "Community Chest (1)",
                "Baltic Avenue",
                "Income Tax",
                "Reading Railroad",
                "Oriental Avenue",
                "Chance (1)",
                "Vermont Avenue",
                "Connecticut Avenue",
                "Jail",
                "St. Charles Place",
                "Electric Company",
                "States Avenue",
                "Virginia Avenue",
                "Pennsylvania Railroad",
                "St. James Place",
                "Community Chest (2)",
                "Tennessee Avenue",
                "New York Avenue",
                "Free Parking",
                "Kentucky Avenue",
                "Chance (2)",
                "Indiana Avenue",
                "Illinois Avenue",
                "B&O Railroad",
                "Atlantic Avenue",
                "Ventnor Avenue",
                "Water Works",
                "Marvin Gardens",
                "Go To Jail",
                "Pacific Avenue",
                "North Carolina Avenue",
                "Community Chest (3)",
                "Pennsylvania Avenue",
                "Short Line Railroad",
                "Chance (3)",
                "Park Place",
                "Luxury Tax",
                "Boardwalk"
        };
        private int numOfPlayer;
        private int timesAroundBoard;

        /// <summary>
        /// monopoly constructor
        /// gets number of players and how many times will the player goes around
        /// </summary>
        /// <param name="numOfPlayer">number of player</param>
        /// <param name="timesAround">times the players are going to go around</param>
        public Monopoly(int numOfPlayer, int timesAroundBoard)
        {
            this.numOfPlayer = numOfPlayer;
            this.timesAroundBoard = timesAroundBoard;
            myDice = new Dice();
        }

        /*  int array for number stopped 
         *  double for times visit
         * 
         *  loop number of players
         *      int times around = 0
         *      int position = 0
         *      while number player went around < timesAround
         *          roll 2 dice
         *          add that number to position
         *          
         *          if (position is > length of board)
         *              position = position - length of board
         *              times around++
         *              
         *          array for num stopped[position]++
         *          times visit++
         *          
         *          if (position == 30 go to jail)
         *              times around++
         *              position = 10 //send to 
         *  double array percentage length is length of propertyNames
         *  
         *  loop propertyName length
         *      percentage = visit/totalvisit*100
         *  return percentage
         */

        /// <summary>
        /// simulate monopoly play for every player
        /// </summary>
        /// <returns>percentages player stopped on the board</returns>
        public double[] Analyze()
        {
            int[] visits = new int[propertyNames.Length];
            double totalVisit = 0;

            //loop for every player
            for (int i = 0; i < numOfPlayer; i++)
            {
                int timesGoAround = 0;
                int position = 0;

                //loop until the player went through the board for timesAround
                while (timesGoAround < timesAroundBoard)
                {
                    int roll = myDice.RollMultipleDice(2);
                    position += roll;

                    //if you went around, add times around and make position inside the board
                    if (position > propertyNames.Length-1)
                    {
                        position = position - propertyNames.Length;
                        timesGoAround++;
                    }

                    //add total visit and visits[position] for percentage calculation
                    visits[position]++;
                    totalVisit++;

                    //if player stopped on "go to jail" go to jail, don't add visit[position]
                    if (position == 30)
                    {
                        timesGoAround++;
                        position = 10;
                    }
                }
            }

            //calculate percentage players stopped on the board
            double[] percentages = new double[propertyNames.Length];
            for (int i = 0; i < propertyNames.Length; i++)
            {
                percentages[i] = visits[i] / totalVisit * 100;
            }
            return percentages;
        }

        /// <summary>
        /// Print percentages for each place
        /// </summary>
        /// <param name="visitPercentages">percentages you got from Analyse</param>
        public void PrintResults(double[] visitPercentages)
        {
            for (int i = 0; i < propertyNames.Length; i++)
            {
                Console.WriteLine(propertyNames[i].PadLeft(25) + "    " + "{0:F2}%", visitPercentages[i]);
            }
        }

    }
}
