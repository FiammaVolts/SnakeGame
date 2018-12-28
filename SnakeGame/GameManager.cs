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
        
        public bool gameOver;


        public void Start() {

            Console.WriteLine("Entrou no start");

            Snake snake = new Snake();

            snake.dir = "RIGHT";
            snake.pre_dir = "";
            snake.points = 0;
            im.nTail = 0;

            gameOver = false;
            im.isPrinted = false;

            im.noseX = InterfaceManager.width / 2;
            im.noseY = InterfaceManager.height / 2;
            im.appleX = rnd.Next(1, InterfaceManager.width - 1);
            im.appleY = rnd.Next(1, InterfaceManager.height - 1);
        }

        public void GameLoop()
        {
            InterfaceManager im = new InterfaceManager();

            Start();

            do
            {
                Console.Clear();
                im.ShowMenu();
            }
            while (gameOver == false);            
        }      
    }
}
