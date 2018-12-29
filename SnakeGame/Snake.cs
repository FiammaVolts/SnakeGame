using System;

namespace SnakeGame
{
    class Snake
    {
        private Random rnd;
        private ConsoleKeyInfo pressedKey;
        private InterfaceManager im;

        private bool horizontal;
        private bool vertical;

        public bool GameOver { get; set; }

        public string dir;
        public string pre_dir;

        public static int Points { get; set; }

        public Snake(InterfaceManager im)
        {
            this.im = im;
            rnd = new Random();
        }

        public void Update()
        {
            CheckInput();
            Movement();
        }

        public void CheckInput()
        {
            while (Console.KeyAvailable)
            {
                pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }


                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    pre_dir = dir;
                    dir = "LEFT";
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    pre_dir = dir;
                    dir = "RIGHT";
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    pre_dir = dir;
                    dir = "UP";
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    pre_dir = dir;
                    dir = "DOWN";
                }
            }
        }

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

            switch (dir)
            {
                case "RIGHT":
                    im.NoseX++;
                    break;

                case "LEFT":
                    im.NoseX--;
                    break;

                case "UP":
                    im.NoseY--;
                    break;

                case "DOWN":
                    im.NoseY++;
                    break;
            }

            if ((dir == "LEFT") || (dir == "RIGHT"))
            {
                horizontal = true;
            }

            else
            {
                horizontal = false;
            }

            if ((dir == "UP") || (dir == "DOWN"))
            {
                vertical = true;
            }

            else
            {
                vertical = false;
            }

            if (im.NoseX == im.AppleX && im.NoseY == im.AppleY)
            {
                Points += 10;
                im.NTail++;
                im.AppleX = rnd.Next(1, im.width - 1);
                im.AppleY = rnd.Next(1, im.height - 1);
            }

            if (im.NoseX <= 0 || im.NoseX >= im.width - 1 ||
                im.NoseY <= 0 || im.NoseY >= im.height - 1)
            {
                GameOver = true;
            }

            else
            {
                GameOver = false;
            }

            for (int i = 1; i < im.NTail; i++)
            {
                if (im.TailX[i] == im.NoseX && im.TailY[i] == im.NoseY)
                {
                    if (horizontal || vertical)
                    {
                        GameOver = true;
                    }
                    else
                    {
                        GameOver = false;
                    }
                }

                if (im.TailX[i] == im.AppleX && im.TailY[i] == im.AppleY)
                {
                    im.AppleX = rnd.Next(1, im.width - 1);
                    im.AppleY = rnd.Next(1, im.height - 1);
                }
            }
        }

        public void Lose()
        {
            Console.WriteLine("You did an opsie :(\n");
            Console.Write("Press ESC to exit to menu\n");
            while (true)
            {
                pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.Escape)
                    return;
            }
        }
    }
}