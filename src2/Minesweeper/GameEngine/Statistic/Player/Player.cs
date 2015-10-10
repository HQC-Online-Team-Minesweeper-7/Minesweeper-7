using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Statistic.Player
{
    public class Player : IPlayer
    {
        private string name;
        private int score;

        public Player(string name,int score =0)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("name is invalid");
                }

                this.name = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("score is less than zero");
                }

                this.score = value;
            }
        }

        public void RestoreFromMemento(PlayerMemento memento)
        {
            this.Name = memento.Name;
            this.Score = memento.Score;
        }

        public PlayerMemento StoreToMemento()
        {
            var memento = new PlayerMemento(this.Name, this.Score);

            return memento;
        }
    }
}
