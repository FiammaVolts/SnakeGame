using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class GameManager
    {
        private InterfaceManager im;
        private Random rnd;
        private Snake snake;


        public bool gameOver;


        public void Start()
        {
            snake = new Snake();
            im = new InterfaceManager();
            rnd = new Random();

            snake.dir = "RIGHT";
            snake.pre_dir = "";
            Snake.Points = 0;
            im.NTail = 0;

            gameOver = false;
            im.isPrinted = false;

            im.NoseX = im.width / 2;
            im.NoseY = im.height / 2;
            im.AppleX = rnd.Next(1, im.width - 1);
            im.AppleY = rnd.Next(1, im.height - 1);
        }

        public void GameLoop()
        {
            Start();
            
            while(true)
            {
                if (!gameOver)
                {
                    Console.Clear();
                    im.Update();
                    snake.Update();
                }
                else
                    snake.Lose();
            }
        }
    }
}
