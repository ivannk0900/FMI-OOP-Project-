namespace ConsoleGame.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Archer : Creature
    {
        public Archer(int health, int damage, int defence, int mana, int stamina, int crit,int team)
            : base(health)
        {
            this.Damage = damage;
            this.Defense = defence;
            this.Mana = mana;
            this.Stamina = stamina;
            this.CritChance = crit;
            this.Team = team;
        }

    }
}
