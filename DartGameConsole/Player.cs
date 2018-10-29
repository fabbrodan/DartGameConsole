using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGameConsole
{
    class Player
    {
        private string Name;
        private List<Turn> PlayerTurns;
        private int Score;
        private int ColorIndex;

        public Player(string Name, int ColorIndex)
        {
            this.Name = Name;
            this.ColorIndex = ColorIndex;
            PlayerTurns = new List<Turn>();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public int GetScore()
        {
            return this.Score;
        }

        public int GetColor()
        {
            return this.ColorIndex;
        }

        public void Add_Turn()
        {
            PlayerTurns.Add(new Turn());
        }

        public void Add_Turn(int Aim)
        {
            PlayerTurns.Add(new Turn(Aim));
        }

        public void UpdateScore()
        {
            Score = 0;

            foreach (Turn turn in PlayerTurns)
            {
                Score += turn.GetTurnPoints();
            }
        }
    }
}
