using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class InterfaceManager
    {        
        public int NoseX { get; set; }
        public int NoseY { get; set; }
        public int NTail { get; set; }
        public int AppleX { get; set; }
        public int AppleY { get; set; }

        public readonly int height = 20;
        public readonly int width = 60;

        public bool isPrinted { get; set; }

        private int[] TailX = new int[100];
        private int[] TailY = new int[100];

        private readonly string snake = "\u20E2";
        private readonly string apple = "\u20D8";

        public void Update()
        {
            ShowMenu();
        }


        public void ShowMenu()
        {
            Console.WriteLine("╔═══*.·:·.**  < Snake >  **.·:·.*═══╗");
            Console.WriteLine();
            Console.WriteLine("       1. Start Game\n" +
                              "       2. Highscore\n" +
                              "       3. Credits\n" +
                              "       4. Quit Game\n");
            Console.WriteLine("╚═══*.·:·.**  < Game >  **.·:·.*═══╝");

            // Will call the ReadEntry() method
            ReadEntry();
        }

        public void ShowCredits()
        {
            Console.WriteLine("╔═══*.·:·.**  < Credits >  **.·:·.*═══╗");
            Console.WriteLine();
            Console.WriteLine("       Ines Goncalves    a21702076\n" +
                              "       Ines Nunes        a21702520\n" +
                              "       Sara Gama         a21705494\n");
            Console.WriteLine("╚═══*.·:·.**  < Credits >  **.·:·.*═══╝");

            Console.WriteLine();
            Console.WriteLine("<- Press any button to go back to the menu\n");
            Console.ReadKey();
            Console.Clear();
            ShowMenu();
        }


        public void ShowWorld()
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1)
                    {
                        Console.Write("-");
                    }
                    else if (j == 0 || j == width - 1)
                    {
                        Console.Write("|");
                    }
                    else if (j == AppleX && i == AppleY)
                    {
                        Console.Write("a");
                    }
                    else if (j == NoseX && i == NoseY)
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        isPrinted = false;
                        for (int k = 0; k < NTail; k++)
                        {
                            if (TailX[k] == j && TailY[k] == i)
                            {
                                Console.Write("O");
                                isPrinted = true;
                            }
                        }
                        if (!isPrinted)
                            Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine($"Your score: {Snake.Points}");
        }

        public int ReadEntry()
        {
            // A loop that will run while the condition is true, and while the
            // player doesn't choose to leave
            while (true)
            {

                // A switch case that will work based on the player's input
                switch (Console.ReadLine())
                {

                    // If the player chooses 1
                    case "1":
                        Console.Clear();
                        ShowWorld();
                        break;

                    // If the player chooses 2
                    case "2":
                        Console.Clear();
                        Console.WriteLine("There are no highscores yet :<\n");
                        Console.WriteLine("<- Press any button to go back to the menu\n");
                        Console.ReadKey();
                        Console.Clear();
                        ShowMenu();
                        break;

                    // If the player chooses 3
                    case "3":
                        Console.Clear();
                        ShowCredits();
                        break;

                    case "4":
                        Console.Clear();
                        // Will break the loop and exit the program
                        Environment.Exit(0);
                        break;

                    // A default message in case the player chooses an
                    // unavailable number
                    default:
                        // Will print an error message, and ask them to type a
                        // number again
                        Console.WriteLine("Not a valid number. Try again.");
                        // Reads the input
                        Console.ReadLine();
                        // Will clear the console
                        Console.Clear();
                        // Calls for the ShowMenu() method
                        ShowMenu();
                        break;
                }
            }
        }
    }
}
