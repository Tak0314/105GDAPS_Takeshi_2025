/*Takeshi Tatsumi
 * 10/14/2025
 * Project 3, Golf & Superman
 */
namespace TatsumiT_Project3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //todo Artillery Golf
            /*get input 
             *      angle of the cannon
             *      initial velocity
             *ballistics calculations
             *determine if they hit the target
             *make player try again until they win or make total of 5 attempts
             */

            //psudocode
            /*print Welcome
             *   your goal is to hit a target 751 meters away within 5 tries.
             *    
             *print attempt 1
             *
             *ask Enter the cannon's angle between 0 to 90
             *repeat until player input is between 0 to 90
             *
             *ask Enter the cannonball's initial velocity positive number:
             *repeat until player input is a positive number
             *
             *calculate
             *
             *
             *if the difference of the distance between 751 and the distance made from input was more than 1 meters
             *  Try again
             *else
             *  a successful hit
             *
             *print Thanks for playing Golf game!
             *
             *
             */

            Console.WriteLine("Welcome to Artillery Golf!");
            Console.WriteLine("Your goal is to hit a target 751 meters away within 5 tries.");
            Console.WriteLine();
            double angleInput;
            double velocityInput;
            bool clear = false;
            //runs for 5 times at most
            for(int i = 1; i <=5; i++)
            {
                Console.WriteLine($"Attempt {i} ----------------------------------");

                //ask for the angle of the cannon
                Console.Write("Enter the cannon's angle (between 0 and 90 degrees): ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                angleInput = double.Parse(Console.ReadLine()!);
                Console.ResetColor();
                //ask untill it is valid number
                while(angleInput < 0 || angleInput > 90)
                {
                    Console.WriteLine("That is an invalid angle.");
                    Console.Write("Enter the cannon's angle (between 0 and 90 degrees): ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    angleInput = double.Parse(Console.ReadLine()!);
                    Console.ResetColor();
                }
                Console.WriteLine();

                //ask for the initial velocity of the cannonball
                Console.Write("Enter the cannonball's initial velocity (a positive number): ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                velocityInput = double.Parse(Console.ReadLine()!);
                Console.ResetColor();
                //ask untill it is valid number
                while(velocityInput <= 0)
                {
                    Console.WriteLine("That is an invalid velocity.");
                    Console.Write("Enter the cannonball's velocity (a positive number): ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    velocityInput = double.Parse(Console.ReadLine()!);
                    Console.ResetColor();
                }
                Console.WriteLine();

                //calculate the time and distance
                double sinOfAngle = Math.Sin(angleInput * (Math.PI / 180.0));
                double cosOfAngle = Math.Cos(angleInput * (Math.PI / 180.0));
                //time
                double powOfVelocity = Math.Pow(velocityInput,2);
                double powOfSin = Math.Pow(sinOfAngle,2);
                double rootOfRightSide = Math.Sqrt((powOfVelocity * powOfSin + 20.0 * 2.0 * sinOfAngle));
                double timeFlight = (velocityInput*sinOfAngle + rootOfRightSide)/10.0;
                //distance
                double distanceMoved = velocityInput * cosOfAngle * timeFlight;

                //difference between the target and the cannonball
                double diffence = Math.Abs(distanceMoved - 751);

                Console.WriteLine($"A cannonball fired with an initial velocity of {velocityInput} m/s, " +
                    $"at an angle of {angleInput} degrees from the ground, " +
                    $"will strike the ground {distanceMoved} meters away");

                //check if player cleared or not and print
                //success or not
                //if success break from the loop
                if(diffence <= 0.5)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The shot is {diffence} meters from the target. A successful hit!");
                    Console.ResetColor();
                    clear = true;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The shot is {diffence} meters from the target. Try again!");
                    Console.ResetColor();
                }
            }

            //print different message for clear or out of attempts
            Console.WriteLine();
            if(clear)
            {
                Console.WriteLine("Thanks for playing the Golf game!");
            }
            else
            {
                Console.WriteLine("Ran out of attempts, but thanks for playing the Golf game!");
            }
            Console.WriteLine();
            //todo Superman
            /*prompt the player for a gravitational consistant
             * Calculate Superman's jump velocity to clear a 660 foot tall building
             * ask player if they'd like to enter a new value or quit
            */

            //psudocode
            /*print welcome to superman!
             * print Your goal is to find the initial velocity required for leaping over a 660 foot tall building on different planets
             * 
             * get input from player. positive double
             * repeat until it gets positive value
             * 
             * print superman must jump with an initial velocity of at least {calculated value} feet/seconds
             * 
             * ask if player want to try again
             * if no, print thanks for playing
             * if yes repeat
             * 
             */
            double playerGravity;
            double requiredVelocity;
            string continueOrNo;
            
            Console.WriteLine("Welcome to Superman!");
            Console.WriteLine("Your goal is to find the initial velocity required " +
                "for leaping over 660 foot tall building on different planets.\n");
            Console.WriteLine("Please enter the gravitational constant for the planet on which " +
                "Superman is currently attempting this jump. Units must be in feet/second^2.\n");

            //repeat until player wants to quit
            while(true)
            {
                //ask for a positive number
                //ask until it gets positive number
                Console.Write("Gravitational constant (a positive number): ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                playerGravity = double.Parse(Console.ReadLine()!);
                Console.ResetColor();
                while(playerGravity <= 0)
                {
                    Console.WriteLine("That is an invalid value.");
                    Console.Write("Gravitational constant (a positive number): ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    playerGravity = double.Parse(Console.ReadLine()!);
                    Console.ResetColor();
                }

                //calculate
                requiredVelocity = Math.Sqrt(2*playerGravity*660);
                Console.WriteLine($"Superman must jump with an initial velocity of at least {requiredVelocity} feet/second.\n");

                //ask continue or no
                //if no, break from the loop
                Console.Write("Want to try again? Enter 'yes' or 'no' to continue: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                continueOrNo = Console.ReadLine()!.Trim().ToUpper();
                Console.ResetColor();

                while(continueOrNo != "NO" && continueOrNo != "YES")
                {
                    Console.WriteLine("I don't recognize that response.");
                    Console.Write("Want to try again? Enter 'yes' or 'no' to continue: ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    continueOrNo = Console.ReadLine()!.Trim().ToUpper();
                    Console.ResetColor();
                }
                Console.WriteLine();

                if (continueOrNo == "NO")
                {
                    Console.WriteLine("Thanks for playing the Superman game!");
                    break;
                }
            }

            


        }
    }
}
