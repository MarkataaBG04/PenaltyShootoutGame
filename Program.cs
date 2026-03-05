using System.Threading.Channels;

namespace PenaltyShootoutGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
            string input;
            int missedShots = 0;
            int goals = 0;

            while ((input = Console.ReadLine()) != "4")
            {
               
                switch (input)
                {
                    
                    case "1":
                        Console.Clear();

                        ChooseShootingDirectionMenu();
                        int playerChoose;

                        if (!int.TryParse(Console.ReadLine(), out playerChoose))
                        {
                            Console.WriteLine("Invalid input! Please enter a number.");
                            break;
                        }
                        if (playerChoose < 1 || playerChoose > 9)
                        {
                            Console.WriteLine($"Wrong Input!");
                            break;
                        }
                        string userDirection = Directions(playerChoose);
                        Console.Clear();
                        Console.WriteLine($"You choose: {userDirection}");
                        int computerChoose = ComputerChoose();
                        string computerDirection = Directions(computerChoose);

                        Console.WriteLine("The crowd holds its breath...");
                        Thread.Sleep(3000); // пауза 2 секунди

                        Console.WriteLine($"The goalkeeper dives to the: {computerDirection}!");

                        if (playerChoose == computerChoose)
                        {
                            Console.WriteLine("🧤 SAVED! The goalkeeper stopped your shot!");
                            missedShots++;
                        }
                        else
                        {
                            Console.WriteLine("⚽ GOAL! You scored!");
                            goals++;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        InstructionsMenu();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"You have scored: {goals}.");
                        Console.WriteLine($"You have missed: {missedShots}.");
                        break;
                    default:
                        Console.WriteLine($"Invalid input!");
                        break;
                }

                Console.WriteLine($"Do you want another game? yes/no");
                input = Console.ReadLine();

                if (input == "yes" || input == "Yes")
                {
                    Console.Clear();
                    MainMenu();
                }
                else
                {
                    break;
                }
                
            }


        }

        private static void InstructionsMenu()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("         INSTRUCTIONS");
            Console.WriteLine("===============================");
            Console.WriteLine();
            Console.WriteLine("Welcome to Penalty Shootout!");
            Console.WriteLine();
            Console.WriteLine("How to Play:");
            Console.WriteLine("1. Choose \"New Game / Start\" from the main menu.");
            Console.WriteLine("2. Pick a shooting direction by entering a number (1-9):");
            Console.WriteLine("   1. Top Left     4. Center Left     7. Bottom Left");
            Console.WriteLine("   2. Top Center   5. Center          8. Bottom Center");
            Console.WriteLine("   3. Top Right    6. Center Right    9. Bottom Right");
            Console.WriteLine("3. The goalkeeper will dive randomly to try to save your shot.");
            Console.WriteLine("4. If you choose the same direction as the goalkeeper, your shot will be SAVED!");
            Console.WriteLine("5. If you choose a different direction, you will score a GOAL!");
            Console.WriteLine("6. Try to score as many goals as possible before missing!");
            Console.WriteLine();
            Console.WriteLine("Tips:");
            Console.WriteLine("- Think ahead and try to guess where the goalkeeper will dive.");
            Console.WriteLine("- Mix up your shots to make it harder for the goalkeeper.");
            Console.WriteLine("- Have fun!");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        public static string Directions(int computerChoose)
        {
            switch (computerChoose)
            {
                case 1:
                    return "Top Left";
                case 2:
                    return "Top Center";
                case 3:
                    return "Top Right";
                case 4:
                    return "Center Left";
                case 5:
                    return "Center";
                case 6:
                    return "Center Right";
                case 7:
                    return "Bottom Left";
                case 8:
                    return "Bottom Center";
                case 9:
                    return "Bottom Right";
                default:
                    return "Unknown";
            }
        }

        public static int ComputerChoose()
        {
            Random rand = new Random();
            int randomNumberInRange = rand.Next(1, 10);

            return randomNumberInRange;
        }

        public static void MainMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("===============================");
            Console.WriteLine($"    ⚽ PENALTY SHOOTOUT ⚽");
            Console.WriteLine("===============================");
            Console.WriteLine($"1. New Game / Start");
            Console.WriteLine($"2. Instructions");
            Console.WriteLine($"3. Scores / Results");
            Console.WriteLine($"4. Exit");

            Console.WriteLine($"Please select an option (1-4):");
        }

        public static void ChooseShootingDirectionMenu() 
        {
            Console.WriteLine($"Choose your shooting direction:");
            Console.WriteLine($"1.Top Left");
            Console.WriteLine($"2.Top Center");
            Console.WriteLine($"3.Top Right");
            Console.WriteLine($"4.Center Left");
            Console.WriteLine($"5.Center");
            Console.WriteLine($"6.Center Right");
            Console.WriteLine($"7.Bottom Left");
            Console.WriteLine($"8.Bottom Center");
            Console.WriteLine($"9.Bottom Right");
            Console.WriteLine($"Your choice:");
        }
    }
}
