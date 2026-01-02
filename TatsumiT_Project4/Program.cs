/*Takeshi Tatsumi
 * 10/17/2025
 * Project 4 RPG Character Build Utility
 */

namespace TatsumiT_Project4
{
    public enum WeaponType
    {
        Sword,
        Dagger,
        Wand
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            /*ask how many characters
             *  loop (input) times
             *      ask name
             *      ask level
             *      ask health
             *      ask weapon
             *      
             */
            bool a = true;
            int[] level;
            int[] health;
            string[] name;
            string weaponInput;
            int numOfCharacters;
            double averageLevel;
            //how many characters
            Console.Write("How many RPG characters are you building? ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            numOfCharacters = int.Parse(Console.ReadLine()!.Trim());
            Console.ResetColor();

            //array length = numOfCharacters
            level = new int[numOfCharacters];
            health = new int[numOfCharacters];
            name = new string[numOfCharacters];
            WeaponType[] weapons = new WeaponType[numOfCharacters];

            Console.WriteLine($"You are building {numOfCharacters} RPG characters");
            Console.WriteLine();

            //loop numOfCharacters
            for(int i = 0; i < numOfCharacters; i++)
            {
                a = true;
                //Character name
                Console.Write($"Enter character #{i + 1}'s name: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                name[i] = Console.ReadLine()!;
                Console.ResetColor();
                while (name[i].Length < 2)
                {
                    Console.Write("!! Name must be at least 2 letters long. Enter name again: ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    name[i] = Console.ReadLine()!;
                    Console.ResetColor();
                }

                //Character level
                Console.Write($"Enter {name[i]}'s level (1 - 20): ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                level[i] = int.Parse(Console.ReadLine()!);
                Console.ResetColor();
                while (level[i] < 1 || level[i] > 20)
                {
                    Console.Write("!! Level must be between 1 and 20. Enter level again: ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    level[i] = int.Parse(Console.ReadLine()!);
                    Console.ResetColor();
                }

                //Character health
                Console.Write($"Enter {name[i]}'s health (1 - 100): ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                health[i] = int.Parse(Console.ReadLine()!);
                Console.ResetColor();
                while (health[i] < 1 || health[i] > 100)
                {
                    Console.Write("!! Health must be between 1 and 100. Enter health again: ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    health[i] = int.Parse(Console.ReadLine()!);
                    Console.ResetColor();
                }

                //Character weapon
                Console.WriteLine($"Enter {name[i]}'s weapon.");
                Console.Write("Chose from'Sword' 'Dagger' or 'Wand': ");
                
                while(a == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    weaponInput = Console.ReadLine()!.Trim();
                    Console.ResetColor();
                    switch(weaponInput)
                    {
                        case "Sword":
                            weapons[i] = WeaponType.Sword;
                            a = false;
                            break;
                        case "Dagger":
                            weapons[i] = WeaponType.Dagger;
                            a = false;
                            break;
                        case "Wand":
                            weapons[i] = WeaponType.Wand;
                            a = false;
                            break;
                        default:
                            Console.Write("!! Unrecognized weapon. Enter the weapon type again: ");
                            continue;
                    }
                }
                Console.WriteLine();
            }

            //print all characters and average level
            Console.WriteLine();
            Console.WriteLine("All character data is entered!");
            Console.WriteLine();
            Console.WriteLine("Character Report:");
            PrintAllCharacters(name, level, health, weapons);
            averageLevel = CalculateLevelAverage(level);
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Average level for all characters: {averageLevel}");
            Console.WriteLine();

            /*get string input
             *  find character matches with the input
             *      loop until it matches
             *  change the level of the character
             *  
             */
            //get name of the character that player wants to change
            string changeLevel;
            int nameIndex = -1;
            Console.WriteLine("Now let's change one character's level.");
            Console.Write("Which character do you wish to change? ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            changeLevel = Console.ReadLine()!;
            Console.ResetColor();
            nameIndex = FindCharacterIndex(changeLevel, name);
            //repeat until it gets valid input
            while(nameIndex < 0)
            {
                Console.Write(" !! Character does not exist. Enter character name again: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                changeLevel = Console.ReadLine()!;
                Console.ResetColor();
                nameIndex = FindCharacterIndex(changeLevel, name);
            }

            //get input you want to change level to 
            int newLevel;
            Console.Write($"What is {name[nameIndex]}'s new level? ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            newLevel = int.Parse(Console.ReadLine()!);
            Console.ResetColor();
            while(newLevel <= 0 || newLevel > 20)
            {
                Console.Write(" !! Level must be between 1 and 20. Enter level again: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                newLevel = int.Parse(Console.ReadLine()!);
                Console.ResetColor();
            }
            level[nameIndex] = newLevel;

            //print all characters and average level
            Console.WriteLine();
            Console.WriteLine("Character Report:");
            PrintAllCharacters(name, level, health, weapons);
            averageLevel = CalculateLevelAverage(level);
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Average level for all characters: {averageLevel}");
            Console.WriteLine();

            //Analyze the party
            Console.WriteLine(AboveAverage(level,averageLevel) + " character(s) has an above-average level:");
            Console.WriteLine("The lowest health belongs to "+ name[LowestHealthIndex(health)]);
            Console.WriteLine("The highest health belongs to " + name[HighestHealthIndex(health)]);
            if(Duplicates(name))
            {
                Console.WriteLine("More than one character has the same name in this set of RPG players.");
            }
            else
            {
                Console.WriteLine("All character names are unique.");
            }


        }

        /// <summary>
        /// prints all character's names and levels and healths and weapons
        /// </summary>
        /// <param name="names">array of the names</param>
        /// <param name="levels">array of the levels</param>
        /// <param name="healths">array of the healths</param>
        /// <param name="weapons">enum array of the weapons</param>
        public static void PrintAllCharacters(string[] names, int[] levels, int[] healths, WeaponType[] weapons)
        {
            for(int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Character {i+1}: {names[i]} - Level {levels[i]} - Health {healths[i]} - {weapons[i]}");
            }
        }

        /// <summary>
        /// calculate the average of the levels 
        /// </summary>
        /// <param name="levels">int array of the level</param>
        /// <returns>average number of the level</returns>
        public static double CalculateLevelAverage(int[] levels)
        {
            double totalLevel = 0;
            //add all character's level
            for(int i = 0; i < levels.Length; i++)
            {
                totalLevel = totalLevel + levels[i];
            }
            //return total level / number of characters
            return Math.Round(totalLevel / levels.Length,2);
        }

        /// <summary>
        /// compare input and all names and if it maches, return the index of the name
        /// if it doesn't mach, returns -1
        /// </summary>
        /// <param name="input">input from player</param>
        /// <param name="name">name array</param>
        /// <returns>index of name, if nothing maches, return -1</returns>
        public static int FindCharacterIndex(string input, string[] name)
        {
            for(int i = 0; i < name.Length; i++)
            {
                if(input == name[i])
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// check if the character's level is higher than average
        /// </summary>
        /// <param name="levels">int array of the levels</param>
        /// <param name="average">average of the cahracter's level</param>
        /// <returns>number of the characters who has higher level than average</returns>
        public static int AboveAverage(int[] levels, double average)
        {
            int numAboveAverage = 0;
            for(int i = 0; i < levels.Length; i++)
            {
                if (levels[i] > average)
                {
                    numAboveAverage += 1;
                }
            }
            return numAboveAverage;
        }

        /// <summary>
        /// checks who has the lowest health and return the index of the character who has lowest
        /// </summary>
        /// <param name="health">int array of the health</param>
        /// <returns>index number of the character who has lowest health</returns>
        public static int LowestHealthIndex(int[] health)
        {
            int lowestHealthIndex = 0;
            for(int i = 1; i < health.Length; i++)
            {
                if (health[i] < health[lowestHealthIndex])
                {
                    lowestHealthIndex = i;
                }
            }
            return lowestHealthIndex;
        }

        /// <summary>
        /// checks who has the highest health and return the index of the character who has the lowest
        /// </summary>
        /// <param name="health">int array of the health</param>
        /// <returns>index number of the character who has the highest health</returns>
        public static int HighestHealthIndex(int[] health)
        {
            int highestHealthIndex = 0;
            for(int i = 1; i < health.Length; i++)
            {
                if (health[i] > health[highestHealthIndex])
                {
                    highestHealthIndex = i;
                }
            }
            return highestHealthIndex;
        }


        /// <summary>
        /// checks if any character has the same name with other character
        /// </summary>
        /// <param name="name">string array of the names</param>
        /// <returns>if anyone has the same name, returns true other, false</returns>
        public static bool Duplicates(string[] name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                for(int j = 0; j < name.Length; j++)
                {
                    if (i != j && name[i] == name[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
