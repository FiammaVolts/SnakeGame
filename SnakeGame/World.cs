using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class World
    {

        public Random rnd = new Random();
        public ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();

        public int noseX;
        public int noseY;
        public int nTail;
        public int appleX;
        public int appleY;
        public int points;

        public int[] TailX = new int[100];
        public int[] TailY = new int[100];

        public const int height = 20;
        public const int width = 60;

        public bool isPrinted;
        public bool horizontal;
        public bool vertical;
        public string dir;
        public string pre_dir;
    }
}
