using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnakeGame
{
    /// <summary>
    /// A class for the highscores
    /// </summary>
    class HighScores
    {
        public string path = "HighScores";
        /// <summary>
        /// Property for the scores
        /// </summary>
        public int[] Scores { get; set; }

        /// <summary>
        /// Constructor for the class
        /// </summary>
        public HighScores()
        {
            CreateHighScoreFile();

        }

        /// <summary>
        /// Method that creates a file for the scores
        /// </summary>
        private void CreateHighScoreFile()
        {

            // An if that will act if the file doesn't exist
            if (!File.Exists(path))
            {
                // Will create the file
                File.Create(path);
                // Calls InputScore()
                InputScore(0);

            }
            // If it exists
            else
            {
                // Creates a new instance of StreamReader that receives path
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    // Creates an array of ints
                    Scores = new int[10];

                    // A for that will place the scores
                    for (int i = 0; (line = sr.ReadLine()) != null; i++)
                    {
                        Scores[i] = Convert.ToInt32(line);
                    }
                }
            }
        }

        /// <summary>
        /// A method that will read the scores
        /// </summary>
        public void ReadScores()
        {
            // Creates a new instance of StreamReader that receives path
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                Console.WriteLine("HighScores");

                // A for that will print all the scores
                for (int i = 0; (line = sr.ReadLine()) != null; i++)
                {
                    Console.Write(i + " ");
                    Console.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// A method that will place all the scores
        /// </summary>
        /// <param name="points"></param>
        public void InputScore(int points)
        {
            // An if that checks if the score gotten is lower than the top 9
            if (Scores[9] < points)
            {
                // Will place the score on the array
                Scores[9] = points;
                // Will sort the scores
                Array.Sort(Scores);
                // And revert them, so the higher number comes on top
                Array.Reverse(Scores);
            }

            // Creates a new instance of StreamWriter
            using (StreamWriter sr = new StreamWriter(path))
            {
                // Will print all the scores on the array
                for (int i = 0; i < Scores.Length; i++)
                {
                    sr.WriteLine(Scores[i]);
                }
            }
        }
    }
}
