namespace ConsoleGame.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Creature
    {
        private int damage;
        private int health;
        private int mana;
        private int defense;
        private int stamina;
        private int critChance;
        private int team;  // 1 for player's team    2 for computer's team

        protected Creature(int health)
        {
            this.Health = health;   // setting default values to other fields is not necessary
            // because the default value of type int is 0 and that is what we need
        }

        protected Creature(int health, int damage, int defence, int mana, int stamina, int crit, int team)
        {
            this.Health = health;
            this.Damage = damage;
            this.Defense = defence;
            this.Mana = mana;
            this.Stamina = stamina;
            this.CritChance = critChance;
            this.team = team;
        }


        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                this.damage = value;
            }
        }

        public int Defense
        {
            get
            {
                return this.defense;
            }
            set
            {
                this.defense = value;
            }
        }
        public int Mana
        {
            get
            {
                return this.mana;
            }
            set
            {
                this.mana = value;
            }
        }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }
            set
            {
                this.stamina = value;
            }
        }

        public int CritChance
        {
            get
            {
                return this.critChance;
            }
            set
            {
                this.critChance = value;
            }
        }

        public int Team
        {
            get
            {
                return this.team;
            }
            set
            {
                this.team = value;
            }
        }


    }
}
