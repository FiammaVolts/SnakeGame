using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Snake
    {
        private int[] TailX = new int[100];
        private int[] TailY = new int[100];

        private Random rnd;
        private ConsoleKeyInfo pressedKey;
        private InterfaceManager im;
        private GameManager gm;

        private bool horizontal;
        private bool vertical;

        public string dir;
        public string pre_dir;

        public static int Points { get; set; }

        public Snake()
        {
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
            int preX = TailX[0];
            int preY = TailY[0];

            switch (dir)
            {
                case "RIGHT":
                    im.NoseX++;
                    //horizontal = true;
                    break;

                case "LEFT":
                    im.NoseX--;
                    //horizontal = true;
                    break;

                case "UP":
                    im.NoseY--;
                    //vertical = true;
                    break;

                case "DOWN":
                    im.NoseY++;
                    //vertical = true;
                    break;
            }

            if ((dir == "LEFT") || (dir == "RIGHT")) {
                horizontal = true;
            }

            else {
                horizontal = false;
            }

            if ((dir == "UP") || (dir == "DOWN")) {
                vertical = true;
            }

            else {
                vertical = false;
            }

            if (im.NoseX == im.AppleX && im.NoseY == im.AppleY) {
                Points += 10;
                im.NTail++;
                im.AppleX = rnd.Next(1, im.width - 1);
                im.AppleY = rnd.Next(1, im.height - 1);
            }

            if (im.NoseX <= 0 || im.NoseX >= im.width - 1 ||
                im.NoseY <= 0 || im.NoseY >= im.height - 1)
            {
                gm.gameOver = true;
            }

            else
            {
                gm.gameOver = false;
            }

            for (int i = 1; i < im.NTail; i++)
            {
                if (TailX[i] == im.NoseX && TailY[i] == im.NoseY)
                {
                    if (horizontal || vertical)
                    {
                        gm.gameOver = false;
                    }
                    else
                    {
                        gm.gameOver = true;
                    }
                }

                if (TailX[i] == im.AppleX && TailY[i] == im.AppleY)
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
                {
                    im.ShowMenu();
                }
            }
        }
    }
}