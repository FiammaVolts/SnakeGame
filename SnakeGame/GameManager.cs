using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class GameManager
    {

        public Draw draw;
        public bool gameOver;
        public bool reset;   

        public void Update()
        {

        }

        public int ReadEntry() {
            // A loop that will run while the condition is true, and while the
            // player doesn't choose to leave
            while (true) {
                // A variable needed for the cases
                int entry;

                // A switch case that will work based on the player's input
                switch (Console.ReadLine()) {

                    // If the player chooses 1
                    case "1":
                        // Will save the input, place it on id and then convert it
                        entry = Convert.ToInt32(Console.ReadLine());
                        draw.ShowWorld(entry);
                        break;

                    // If the player chooses 2
                    case "2":
                        Console.WriteLine("There are no highscores yet :<\n");
                        Console.ReadKey();
                        draw.ShowMenu(entry);
                        break;

                    // If the player chooses 3
                    case "3":
                        draw.ShowCredits(entry);
                        break;

                    case "4":
                        // Will break the loop and exit the program
                        Environment.Exit(0);
                        break;

                    // A default message in case the player chooses an
                    // unavailable number
                    default:
                        // Will print an error message, and ask them to type a
                        // number again
                        Console.WriteLine("Not a valid number. Try again.");
                        // Reads the input
                        Console.ReadLine();
                        // Will clear the console
                        Console.Clear();
                        // Calls for the ShowMenu() method
                        ShowMenu();
                        break;
                }
            }
        }

    }
}
