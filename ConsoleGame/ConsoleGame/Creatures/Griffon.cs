
namespace ConsoleGame.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Griffon : Creature
    {
        public Griffon(int health, int damage, int defence, int mana, int stamina, int crit,int team) 
            : base(health)
        {
            this.Damage = damage;
            this.Defense = defence;
            this.Mana = mana;
            this.Stamina = stamina;
            this.CritChance = crit;
            this.Team = team;
        }
        //public override void Move()  // TODO
        //{
        //    base.Move();
        //}

        //public override void Attack(Creature otherCreature)  // TODO
        //{
        //    base.Attack(otherCreature);
        //}
    }
}
