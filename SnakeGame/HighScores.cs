using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnakeGame
{
    class HighScores
    {

        public string path = "HighScores";
        public int[] Scores { get; set; }

        public HighScores()
        {
            CreateHighScoreFile();

        }

        private void CreateHighScoreFile()
        {

            if (!File.Exists(path))
            {
                File.Create(path);
                InputScore(0);

            }
            else
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    Scores = new int[10];

                    for (int i = 0; (line = sr.ReadLine()) != null; i++)
                    {
                        Scores[i] = Convert.ToInt32(line);
                    }
                }
            }
        }

        public void ReadScores()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                Console.WriteLine("HighScores");

                for (int i = 0; (line = sr.ReadLine()) != null; i++)
                {
                    Console.Write(i + " ");
                    Console.WriteLine(line);
                }
            }
        }

        public void InputScore(int points)
        {
            if (Scores[9] < points)
            {
                Scores[9] = points;
                Array.Sort(Scores);
                Array.Reverse(Scores);
            }
            using (StreamWriter sr = new StreamWriter(path))
            {
                for (int i = 0; i < Scores.Length; i++)
                {
                    sr.WriteLine(Scores[i]);
                }

            }
        }
    }
}
