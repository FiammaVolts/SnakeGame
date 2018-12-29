using System;
using System.Text;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uses the UTF8 on the console
            Console.OutputEncoding = Encoding.UTF8;
            // Creates a new instance of GameManager
            GameManager gm = new GameManager();
            
            // Calls GameLoop()
            gm.GameLoop();
            
            
        }
    }
}
