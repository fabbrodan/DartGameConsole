using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGameConsole
{
    class Turn
    {
        private int[] Points = new int[] {20,1,18,4,13,6,10,15,2,17,3,19,7,16,8,11,14,9,12,5};
        private Random random;
        private int TurnPoints;

        public Turn()
        {
            random = new Random();
            SetTurnPoints();
        }

        public Turn(int Aim)
        {
            random = new Random();
            SetTurnPoints(Aim);
        }

        private void SetTurnPoints()
        {
            int x = random.Next(19);
            TurnPoints += Points[x];
            Console.WriteLine("Your random throw gave you {0} points!", Points[x]);   
        }

        private void SetTurnPoints(int Aim)
        {
            int probability = random.Next(0, 101);
            if (probability <= 60)
            {
                TurnPoints += Aim;
                Console.WriteLine("You hit your aim! {0} points", Aim);
            }
            else if (probability > 60 && probability <= 75)
            {
                for (int i = 0; i < Points.Length; i++)
                {
                    if (Points[i] == Aim)
                    {
                        if (i == 0)
                        {
                            TurnPoints += Points[Points.Length - 1];
                            Console.WriteLine("You missed and hit the one to the left. {0} points", Points[Points.Length - 1]);
                            break;
                        }
                        else
                        {
                            TurnPoints += Points[i - 1];
                            Console.WriteLine("You missed and hit the one to the left. {0} points", Points[i - 1]);
                            break;
                        }
                    }
                }
            }
            else if (probability > 75 && probability <= 90)
            {
                for (int i = 0; i < Points.Length; i ++)
                {
                    if (Points[i] == Aim)
                    {
                        if(i == 19)
                        {
                            TurnPoints += Points[0];
                            Console.WriteLine("You missed and hit the one to the right. {0} points", Points[0]);
                            break;
                        }
                        else
                        {
                            TurnPoints += Points[i + 1];
                            Console.WriteLine("You missed and hit the one to the right. {0} points", Points[i + 1]);
                            break;
                        }
                    }
                }
            }
            else if (probability > 90 && probability <= 95)
            {
                int x = random.Next(19);
                TurnPoints += Points[x];
                Console.WriteLine("You missed and hit A random point. {0} points", Points[x]);
            }
            else
            {
                Console.WriteLine("You missed the entire board!");
                TurnPoints += 0;
            }
        }

        public int GetTurnPoints()
        {
            return this.TurnPoints;
        }
    }
}
