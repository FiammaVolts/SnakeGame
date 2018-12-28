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

        public Snake()
        {
            rnd = new Random();
        }

        public void Update()
        {
           
        }

        void Movement() {
            int preX = TailX[0];
            int preY = TailY[0];

            switch (im.dir) {
                case "RIGHT":
                    im.noseX++;
                    horizontal = true;
                    break;
                case "LEFT":
                    im.noseX--;
                    horizontal = true;
                    break;
                case "UP":
                    im.noseY--;
                    vertical = true;
                    break;
                case "DOWN":
                    im.noseY++;
                    vertical = true;
                    break;
            }

            if (im.noseX <= 0 || im.noseX >= InterfaceManager.width - 1 ||
                im.noseY <= 0 || im.noseY >= InterfaceManager.height - 1) {
                gm.gameOver = true;
            }
            else {
                gm.gameOver = false;
            }

            if (im.noseX == im.appleX && im.noseY == im.appleY) {
                im.points += 10;
                im.nTail++;
                im.appleX = rnd.Next(1, InterfaceManager.width - 1);
                im.appleY = rnd.Next(1, InterfaceManager.height - 1);
            }

            for (int i = 1; i < im.nTail; i++) {
                if (TailX[i] == im.noseX && TailY[i] == im.noseY) {
                    if (horizontal || vertical) {
                        gm.gameOver = false;
                    }
                    else {
                        gm.gameOver = true;
                    }
                }
                if (TailX[i] == im.appleX && TailY[i] == im.appleY) {
                    im.appleX = rnd.Next(1, InterfaceManager.width - 1);
                    im.appleY = rnd.Next(1, InterfaceManager.height - 1);
                }
            }
        }
    }
}
