using System;
using System.Threading;

namespace SnakeGame
{
    class GameManager
    {
        // Instance of InterfaceManager
        private InterfaceManager im;
        // Instance of Random
        private Random rnd;
        // Instance of Snake
        private Snake snake;

        public int points;
        
        // Start() method that will start all our variables
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

        // GameLoop() method that will manage our game
        public void GameLoop()
        {
            Start();
            Console.CursorVisible = false;
            
            // Will run as long as GameOver is not true
            while(!snake.GameOver)
            {
                points = snake.Points;
                im.Update();
                snake.Update();
                Thread.Sleep(40);
            }
            // Will call the Lose() method
            snake.Lose();
            Console.Clear();
            GameLoop();
        }
    }
}
