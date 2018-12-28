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

        private bool horizontal;
        private bool vertical;

        void Movement() {
            int preX = TailX[0];
            int preY = TailY[0];
            int tempX, tempY;

            if (dir != "STOP") {
                TailX[0] = noseX;
                TailY[0] = noseY;
                for (int i = 1; i < nTail; i++) {
                    tempX = TailX[i];
                    tempY = TailY[i];
                    TailX[i] = preX;
                    TailY[i] = preY;
                    preX = tempX;
                    preY = tempY;
                }
            }

            switch (dir) {
                case "RIGHT":
                    noseX++;
                    horizontal = true;
                    break;
                case "LEFT":
                    noseX--;
                    horizontal = true;
                    break;
                case "UP":
                    noseY--;
                    vertical = true;
                    break;
                case "DOWN":
                    noseY++;
                    vertical = true;
                    break;
            }

            if (noseX <= 0 || noseX >= width - 1 || noseY <= 0 || noseY >= height - 1) {
                gameOver = true;
            }
            else {
                gameOver = false;
            }

            if (noseX == appleX && noseY == appleY) {
                score += 10;
                nTail++;
                appleX = rnd.Next(1, InterfaceManager.width - 1);
                appleY = rnd.Next(1, InterfaceManager.height - 1);
            }

            for (int i = 1; i < nTail; i++) {
                if (TailX[i] == noseX && TailY[i] == noseY) {
                    if (horizontal || vertical) {
                        gameOver = false;
                    }
                    else {
                        gameOver = true;
                    }
                }
                if (TailX[i] == appleX && TailY[i] == appleY) {
                    appleX = rnd.Next(1, InterfaceManager.width - 1);
                    appleY = rnd.Next(1, InterfaceManager.height - 1);
                }
            }
        }
    }
}
