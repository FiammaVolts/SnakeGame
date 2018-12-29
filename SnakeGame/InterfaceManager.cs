using System;


namespace SnakeGame
{
    class InterfaceManager
    {
        // Properties for the snake and apple
        public int NoseX { get; set; }
        public int NoseY { get; set; }
        public int NTail { get; set; }
        public int AppleX { get; set; }
        public int AppleY { get; set; }

        // Will define the size of the world
        public readonly int height = 20;
        public readonly int width = 60;

        // A bool property that will serve for the body
        // of the snake
        public bool isPrinted { get; set; }

        // An array of ints for the body of the snake
        public int[] TailX = new int[100];
        public int[] TailY = new int[100];

        // An instance of GameManager
        private GameManager gm;

        // Variables for the apple and snake's visualization
        private readonly string _snake = "Q";
        private readonly string _snakeTail = "o";
        private readonly string _apple = "ó";

        // Constructor of the class
        public InterfaceManager(GameManager gm)
        {
            this.gm = gm;
            ShowMenu();
        }

        // Updade method that will call for the ShowWorld()
        public void Update()
        {
            ShowWorld();
        }

        // Method that will render the menu to the player
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

        // Method that will render the credits to the player
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
            gm.GameLoop();
        }

        // Method that will render the world to the player
        public void ShowWorld()
        {
            Console.SetCursorPosition(0, 0);

            // A for that will build the world
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
                    // Will place an apple
                    else if (j == AppleX && i == AppleY)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(_apple);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    // Will place the snake
                    else if (j == NoseX && i == NoseY)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(_snake);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        // Will add to the snake's body
                        isPrinted = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int k = 0; k < NTail; k++)
                        {
                            if (TailX[k] == j && TailY[k] == i)
                            {
                                Console.Write(_snakeTail);
                                isPrinted = true;
                            }
                        }
                        // Will place a blank spot
                        Console.ForegroundColor = ConsoleColor.White;
                        if (!isPrinted)
                            Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            // Will show the points
            Console.WriteLine($"Your score: {gm.points}");
        }

        // A method that will read the player's input
        public void ReadEntry()
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
                        return;

                    // If the player chooses 2
                    case "2":
                        Console.Clear();
                        Console.WriteLine("There are no highscores yet :<\n");
                        Console.WriteLine("<- Press any button to go back to the menu\n");
                        Console.ReadKey();
                        Console.Clear();
                        gm.GameLoop();
                        break;

                    // If the player chooses 3
                    case "3":
                        Console.Clear();
                        ShowCredits();
                        break;

                    // If the player chooses 4
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
                        // Calls for the GameLoop() method
                        gm.GameLoop();
                        break;
                }
            }
        }
    }
}
