/*Takeshi Tatsumi
 * 10/01/2025
 * Project 2
 */

namespace Project_PlayerChoice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* you found at the park cat. do you pet the cat?
             *      "pet" "pass"
             *      if pet
             *          friendship +=1
             *      else if == pass
             *          decided to just watch from distance
             *      else
             *          invalid
             *    
             *      
             * 
             * the next day, you meet the same cat again, What do you do?
             * if friendship == 1
             * {
             *      Follow, feed, hug
             * }
             * else
             * 
             * Follow, feed,
             * 
             *      if Follow
             *          friendship +=1
             *      else if feed
             *          friendship +=2
             *      
             * end
             * 
             */
            int friendship = 0;
            string playerAction1;
            string playerAction2;
            bool pet = false;
            bool feed = false;

            //first part
            Console.Write("You found the cat at the park." +
                "\nWhat do you do?: PET, PASS: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            playerAction1 =  Console.ReadLine()!.Trim().ToUpper();
            Console.ResetColor();
            switch (playerAction1)
            {
                case "PET":
                    Console.WriteLine("You pet the cat. The cat is purring. (friendship +1)");
                    friendship += 1;
                    pet = true;
                    break;
                case "PASS":
                    Console.WriteLine("You decided to just watch from a distance today");
                    break;
                default:
                    Console.WriteLine("Invalid input. The cat walked away.");
                    return;
            }
            Console.WriteLine();

            //2nd part
            Console.WriteLine("The next day, you meet the same cat again.");
            Console.Write("What do you do?: FOLLOW, FEED");
            //if you chose pet in the first part, you can hug the cat
            if (pet == true)
            {
                Console.Write(", HUG: ");
            }
            else
            {
                Console.Write(": ");
            }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            playerAction2 = Console.ReadLine()!.Trim().ToUpper();
            Console.ResetColor();

            switch (playerAction2)
            {
                case "FOLLOW":
                    Console.WriteLine("You followed the cat and found an apple. (friendship +1)");
                    friendship += 1;
                    break;

                case "FEED":
                    Console.WriteLine("You gave a snack for cat. The cat is happily eating the snack. (friendship +2)");
                    friendship += 2;
                    feed = true;
                    break;

                case "HUG":
                    if (pet == true)
                    {
                    Console.WriteLine("You pick up the cat. The cat looks so happy. (friendship +3)");
                    friendship += 3;
                    break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. The cat walked away.");
                        return;
                    }

                default:
                    Console.WriteLine("Invalid input. The cat walked away.");
                    return;
            }
            Console.WriteLine();

            //last part
            if (friendship >= 4)
            {
                Console.WriteLine("The cat moved in and now lives with you.");
            }
            else if (friendship == 3)
            {
                Console.WriteLine("The cat visits your home often.");
            }
            else if (friendship == 2 && feed == true)
            {
                Console.WriteLine("The cat now visits your home to beg for treats.");
            }
            else if (friendship == 2 && pet == true)
            {
                Console.WriteLine("The cat sometimes walk with you.");
            }
            else
            {
                Console.WriteLine("The cat went somewhere.");
            }
                Console.WriteLine("\nThe End.");

            
        }
    }
}
