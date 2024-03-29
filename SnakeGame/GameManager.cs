﻿using System;
using System.Threading;

namespace SnakeGame
{
    /// <summary>
    /// A class for GameManager
    /// </summary>
    class GameManager
    {
        /// <summary>
        /// Instance of InterfaceManager
        /// </summary>
        private InterfaceManager im;
        /// <summary>
        /// Instance of Random
        /// </summary>
        private Random rnd;
        /// <summary>
        /// Instance of Snake
        /// </summary>
        private Snake snake;

        private HighScores hs;

        public int points;


        /// <summary>
        /// Start() method that will start all our instances
        /// </summary>
        public void Start()
        {
            hs = new HighScores();
            im = new InterfaceManager(this, hs);
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

        /// <summary>
        /// GameLoop() method that will manage our game
        /// </summary>
        public void GameLoop()
        {
            Start();
            Console.CursorVisible = false;

            // Will run as long as GameOver is not true
            while (!snake.GameOver)
            {
                points = snake.Points;
                im.Update();
                snake.Update();
                Thread.Sleep(40);
            }
            // Will call the Lose() method
            snake.Lose();
            hs.InputScore(points);
            Console.Clear();
            GameLoop();
        }
    }
}
