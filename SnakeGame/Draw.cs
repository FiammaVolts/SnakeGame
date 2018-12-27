﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Draw
    {
        public World world;

        private readonly string snake = "\u20E2";
        private readonly string apple = "\u20D8";

        public void ShowMenu() {
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

        public void ShowWorld() {
            for (int i = 0; i < World.height; i++) {
                for (int j = 0; j < World.width; j++) {
                    if (i == 0 || i == World.height - 1) {
                        Console.Write("|");
                    }
                    else if (j == 0 || j == World.width - 1) {
                        Console.Write("_ ");
                    }
                    else if (j == world.appleX && i == world.appleY) {
                        Console.Write(apple);
                    }
                    else if (j == world.noseX && i == world.noseY) {
                        Console.Write(snake);
                    }
                    else {
                        world.isPrinted = false;
                        for (int k = 0; k < world.nTail; k++) {
                            if (world.TailX[k] == j && world.TailY[k] == i) {
                                Console.Write(snake);
                                world.isPrinted = true;
                            }
                        }
                        if (!world.isPrinted)
                            Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}