using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DartGameConsole
{
    class Game
    {
        private List<Player> PlayerList;
        private List<int> ColorIndex = new List<int> { 9, 11, 10, 12, 13, 14 };
        private Random random;

        public Game()
        {
            PlayerList = new List<Player>();
            random = new Random();
        }

        public void AddPlayer(string Name)
        {
            int ColorIndexInt = random.Next(0, ColorIndex.Count);
            int PlayerColor = ColorIndex[ColorIndexInt];
            PlayerList.Add(new Player(Name, PlayerColor));
            ColorIndex.Remove(PlayerColor);
        }

        public void PlayGame()
        {
            string input = String.Empty;
            Console.WriteLine("Welcome to a game of Darts!\nAdd Players by entering names and when you are done, type in Start!");
            while(true)
            {
                Console.WriteLine("Player {0}:", PlayerList.Count + 1);
                input = Console.ReadLine();
                if (input == "Start!")
                {
                    break;
                }
                AddPlayer(input);
            }

            bool GameOver = false;
            while (!GameOver)
            {
                foreach (Player player in PlayerList)
                {
                    Console.WriteLine("Player {0}'s turn!", player.ToString());
                    string aim = String.Empty;
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Enter a number between 1 and 20 to aim or leave blank to throw at random");
                        aim = Console.ReadLine();
                        int aimInt = 0;
                        Int32.TryParse(aim, out aimInt);
                        if (aim == "" || aim == String.Empty)
                        {
                            player.Add_Turn();
                        }
                        else if (aimInt > 0 && aimInt < 21)
                        {
                            player.Add_Turn(aimInt);
                        }
                        else
                        {
                            Console.WriteLine("You entered a number larger than 20, we will throw at random for you");
                            player.Add_Turn();
                        }
                    }
                    player.UpdateScore();
                    Console.ForegroundColor = (ConsoleColor)player.GetColor();
                    Console.WriteLine(player.ToString() + " " + player.GetScore());
                    Console.ForegroundColor = ConsoleColor.White;

                    if (player.GetScore() >= 301)
                    {
                        Console.WriteLine("{0} won!", player.ToString());
                        GameOver = true;
                        break;
                    }
                    Thread.Sleep(100);
                }
            }
        }
    }
}
