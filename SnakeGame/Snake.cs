using System;

namespace SnakeGame
{
    class Snake
    {
        // Will create an instance of Random
        private Random rnd;
        // Will create an instance of ConsoleKeyInfo
        private ConsoleKeyInfo pressedKey;
        // Will create an instance of InterfaceManager
        private InterfaceManager im;

        // Variable for horizontal and vertical
        private bool horizontal;
        private bool vertical;

        // Bool property for GameOver
        public bool GameOver { get; set; }

        // Strings for the direction the player chooses, needed
        // for the cases
        public string dir;
        public string pre_dir;

        // Property for the points
        public int Points { get; set; } = 0;

        // Constructor for the class
        public Snake(InterfaceManager im)
        {
            this.im = im;
            rnd = new Random();
        }

        // Update() method that will call for CheckInput() and Movement()
        public void Update()
        {
            CheckInput();
            Movement();
        }

        // Method that will check the player's input
        public void CheckInput()
        {
            // A while that will check which key was pressed
            while (Console.KeyAvailable)
            {
                pressedKey = Console.ReadKey(true);
                // If ESC was pressed
                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    // Will exit the game
                    Environment.Exit(0);
                }

                // If A was pressed
                if (pressedKey.Key == ConsoleKey.A)
                {
                    // Will update both pre_dir and dir
                    pre_dir = dir;
                    dir = "LEFT";
                }
                // If D was pressed
                else if (pressedKey.Key == ConsoleKey.D)
                {
                    // Will update both pre_dir and dir
                    pre_dir = dir;
                    dir = "RIGHT";
                }
                // If W was pressed
                else if (pressedKey.Key == ConsoleKey.W)
                {
                    // Will update both pre_dir and dir
                    pre_dir = dir;
                    dir = "UP";
                }
                // If S was pressed
                else if (pressedKey.Key == ConsoleKey.S)
                {
                    // Will update both pre_dir and dir
                    pre_dir = dir;
                    dir = "DOWN";
                }
            }
        }

        // A method for the movement
        public void Movement()
        {
            int preX = im.TailX[0];
            int preY = im.TailY[0];
            int tempX, tempY;

            im.TailX[0] = im.NoseX;
            im.TailY[0] = im.NoseY;

            for (int i = 1; i < im.NTail; i++)
            {
                tempX = im.TailX[i];
                tempY = im.TailY[i];
                im.TailX[i] = preX;
                im.TailY[i] = preY;
                preX = tempX;
                preY = tempY;
            }

            // Will take the dir and apply it to the cases
            switch (dir)
            {
                // If D was pressed
                case "RIGHT":
                    // Will increase 1 in the X position
                    im.NoseX++;
                    break;

                // If A was pressed
                case "LEFT":
                    // Will decrease 1 in the X position
                    im.NoseX--;
                    break;

                // If W was pressed
                case "UP":
                    // Will decrease 1 in the Y position
                    im.NoseY--;
                    break;

                // If S was pressed
                case "DOWN":
                    // Will increase 1 in the Y position
                    im.NoseY++;
                    break;
            }

            // If the direction is left or right
            if ((dir == "LEFT") || (dir == "RIGHT"))
            {
                // Horizontal will become true
                horizontal = true;
            }

            // If it's not left or right
            else
            {
                // Will become false
                horizontal = false;
            }

            // If the direction is up or down
            if ((dir == "UP") || (dir == "DOWN"))
            {
                // Vertical will become true
                vertical = true;
            }

            // If it's not up or down
            else
            {
                // Vertical will be false
                vertical = false;
            }

            // If that will check if there was a "collision" with an apple
            if (im.NoseX == im.AppleX && im.NoseY == im.AppleY)
            {
                // Points will increase by 10
                Points += 10;
                // The tail will increase by 1
                im.NTail++;
                // And a new apple will be placed randomly
                im.AppleX = rnd.Next(1, im.width - 1);
                im.AppleY = rnd.Next(1, im.height - 1);
            }

            // An if that will check if the top of the snake collides
            // with a wall
            if (im.NoseX <= 0 || im.NoseX >= im.width - 1 ||
                im.NoseY <= 0 || im.NoseY >= im.height - 1)
            {
                // GameOver will become true
                GameOver = true;
            }

            // If it does not collide
            else
            {
                // GameOver will remain false
                GameOver = false;
            }

            // A for that will check if the snake's nose touches the body
            for (int i = 1; i < im.NTail; i++)
            {
                // If it collides
                if (im.TailX[i] == im.NoseX && im.TailY[i] == im.NoseY)
                {
                    // If it touches
                    if (horizontal || vertical)
                    {
                        // GameOver will become true
                        GameOver = true;
                    }
                    // If it doesn't touch
                    else
                    {
                        // GameOver will remain false
                        GameOver = false;
                    }
                }

                // An if that checks if the apple spawns on the same position
                // as the body/tail
                if (im.TailX[i] == im.AppleX && im.TailY[i] == im.AppleY)
                {
                    // Will respawn in another random position
                    im.AppleX = rnd.Next(1, im.width - 1);
                    im.AppleY = rnd.Next(1, im.height - 1);
                }
            }
        }

        // A method that will be used when the player loses
        public void Lose()
        {
            Console.WriteLine("You did an opsie :(\n");
            Console.Write("Press ESC to exit to menu\n");

            // A loop that will run until the player presses ESC
            while (true)
            {
                pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.Escape)
                    return;
            }
        }
    }
}