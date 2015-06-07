namespace ConsoleGame
{
    using System;
    using System.Collections.Generic;

    using ConsoleGame.Creatures;
    using ConsoleGame.PlayerNS;
    using ConsoleGame.ShopThings;
    public class Enemy
    {
        
        private List<Creature> creaturesList;

        public Enemy()
        {
           this.CreaturesList = new List<Creature>();
           CreaturesList.Add(new Peasant(100, 1, 0, 100, 3, 5, 2));
           CreaturesList.Add(new Peasant(100, 1, 0, 100, 3, 5, 2));
           CreaturesList.Add(new Archer(100, 2, 1, 100, 3, 5, 2));
           CreaturesList.Add(new Footman(100, 3, 1, 100, 4, 10, 2));
           CreaturesList.Add(new Footman(100, 3, 1, 100, 4, 10, 2));


        }

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
