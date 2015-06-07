namespace ConsoleGame.Creatures
{
    using System;


    public class Hero : Creature
    {
        public Hero(int health, int damage, int defence, int mana, int stamina, int crit,int team) 
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
