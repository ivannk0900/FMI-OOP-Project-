namespace ConsoleGame.PlayerNS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ConsoleGame.Creatures;

    public class Player
    {
       //  private int gold;
        private List<Creature> creaturesList;

        public Player()
        {
            this.Gold = 300;   // the initial gold of a player
            this.CreaturesList = new List<Creature>();
        }

        public int Gold { get; set; }

        public List<Creature> CreaturesList
        {
            get
            {
                return this.creaturesList;
            }
            set
            {
                this.creaturesList = value;
            }

        }
       
    }
}
