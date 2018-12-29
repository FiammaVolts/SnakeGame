using System;
using System.Threading;

namespace SnakeGame
{
    class GameManager
    {
        private InterfaceManager im;
        private Random rnd;
        private Snake snake;

        public int points;
        
        public void Start()
        {            
            im = new InterfaceManager(this);
            snake = new Snake(im);
            rnd = new Random();

            snake.dir = "RIGHT";
            snake.pre_dir = "";
            im.NTail = 0;
            
            im.isPrinted = false;

            im.NoseX = im.width / 2;
            im.NoseY = im.height / 2;
            im.AppleX = rnd.Next(1, im.width - 1);
            im.AppleY = rnd.Next(1, im.height - 1);
        }

        public void GameLoop()
        {
            Start();
            Console.CursorVisible = false;
            
            while(!snake.GameOver)
            {
                points = snake.Points;
                im.Update();
                snake.Update();
                Thread.Sleep(30);
            }
            snake.Lose();
            Console.Clear();
            GameLoop();
        }
    }
}
