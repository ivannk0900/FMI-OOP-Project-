namespace ConsoleGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ConsoleGame.Creatures;
    using ConsoleGame.PlayerNS;
    using ConsoleGame.ShopThings;
    public class Battlefield
    {
        private List<Creature>[,] field;

        public Battlefield()
        {
            this.field = new List<Creature>[10, 10];

            for (int i = 0; i < 10; i++)                          // initializing all positions on the field with empty lists
            {                                                     // in order not to give us exception when we try to acces empty position
                for (int j = 0; j < 10; j++)
                {
                    field[i, j] = new List<Creature>();
                }
            }
        }

        public List<Creature>[,] Field
        {
            get
            {
                return this.field;
            }
            set
            {
                this.field = value;
            }
        }

        public void AddToField(int xCoord, int yCoord, List<Creature> list)
        {

            if (xCoord > 9 || xCoord < 0 || yCoord > 9 || yCoord < 0)
            {
                Print.PrintOnPosition(15, 15, "Invalid position coordinates !");
            }
            if (Field[xCoord, yCoord].Count != 0)
            {
                Print.PrintOnPosition(15, 15, "The position is occupied !");
            }
            else
            {
                foreach (var cr in list)
                {
                    Field[xCoord, yCoord].Add(cr);
                }
                //  Field[xCoord, yCoord] = list;
            }
        }


        public void DoEnemyAction(Player player, Enemy enemy, Battlefield bfield)
        {
            if (Globals.onTurn == false)
            {
                bool isDone = false;


                int eMove = Globals.random.Next(0, 3); // random number choose which enemy units to go forward

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (bfield.Field[i, j].Count != 0 && bfield.Field[i, j].First().Team == 2)
                        {
                            // first check if enemey can attack the player
                            if (bfield.Field[i, j].First() is Peasant || bfield.Field[i, j].First() is Footman)  // attack range -> 1
                            {
                                if (i < 9 && i > 0 && j < 9 && j > 0)  // check in order not to access nonexistent element
                                {
                                    if (bfield.Field[i - 1, j - 1].Count != 0 && bfield.Field[i - 1, j - 1].First().Team == 1 && !isDone)
                                    {
                                        bfield.Attack(i, j, i - 1, j - 1);
                                        Print.PrintOnPosition(5, 15, "                                       ");
                                        Print.PrintOnPosition(5, 15, String.Format("Your units ({0},{1}) has been attacked      ", i - 1, j - 1));
                                        isDone = true;
                                    }
                                    if (bfield.Field[i, j - 1].Count != 0 && bfield.Field[i, j - 1].First().Team == 1 && !isDone)
                                    {
                                        bfield.Attack(i, j, i, j - 1);
                                        Print.PrintOnPosition(5, 15, "                                       ");
                                        Print.PrintOnPosition(5, 15, String.Format("Your units ({0},{1}) has been attacked      ", i, j - 1));
                                        isDone = true;
                                    }
                                    if (bfield.Field[i + 1, j - 1].Count != 0 && bfield.Field[i + 1, j - 1].First().Team == 1 && !isDone)
                                    {
                                        bfield.Attack(i, j, i + 1, j - 1);
                                        Print.PrintOnPosition(5, 15, "                                       ");
                                        Print.PrintOnPosition(5, 15, String.Format("Your units ({0},{1}) has been attacked      ", i + 1, j - 1));
                                        isDone = true;
                                    }
                                    if (bfield.Field[i - 1, j].Count != 0 && bfield.Field[i - 1, j].First().Team == 1 && !isDone)
                                    {
                                        bfield.Attack(i, j, i - 1, j);
                                        Print.PrintOnPosition(5, 15, "                                       ");
                                        Print.PrintOnPosition(5, 15, String.Format("Your units ({0},{1}) has been attacked      ", i - 1, j));
                                        isDone = true;
                                    }
                                    if (bfield.Field[i + 1, j].Count != 0 && bfield.Field[i + 1, j].First().Team == 1 && !isDone)
                                    {
                                        bfield.Attack(i, j, i + 1, j);
                                        Print.PrintOnPosition(5, 15, "                                      ");
                                        Print.PrintOnPosition(5, 15, String.Format("Your units ({0},{1}) has been attacked      ", i + 1, j));
                                        isDone = true;
                                    }
                                    if (bfield.Field[i - 1, j + 1].Count != 0 && bfield.Field[i - 1, j + 1].First().Team == 1 && !isDone)
                                    {
                                        bfield.Attack(i, j, i - 1, j + 1);
                                        Print.PrintOnPosition(5, 15, "                                      ");
                                        Print.PrintOnPosition(5, 15, String.Format("Your units  ({0},{1}) has been attacked      ", i - 1, j + 1));
                                        isDone = true;
                                    }
                                    if (bfield.Field[i, j + 1].Count != 0 && bfield.Field[i, j + 1].First().Team == 1 && !isDone)
                                    {
                                        bfield.Attack(i, j, i, j + 1);
                                        Print.PrintOnPosition(5, 15, "                                      ");
                                        Print.PrintOnPosition(5, 15, String.Format("Your units ({0},{1}) has been attacked      ", i - 1, j + 1));
                                        isDone = true;
                                    }
                                    if (bfield.Field[i + 1, j + 1].Count != 0 && bfield.Field[i + 1, j + 1].First().Team == 1 && !isDone)
                                    {
                                        bfield.Attack(i, j, i + 1, j + 1);
                                        Print.PrintOnPosition(5, 15, "                                      ");
                                        Print.PrintOnPosition(5, 15, String.Format("Your units ({0},{1}) has been attacked      ", i + 1, j + 1));
                                        isDone = true;
                                    }
                                }

                            }
                        }
                    }
                }

             
                    if (!isDone && eMove == 0) // moves peasants 
                    {

                        for (int p = 0; p < 10; p++)
                        {
                            for (int q = 0; q < 10; q++)
                            {
                                if (bfield.Field[p, q].Count != 0 && bfield.Field[p, q].First().Team == 2 && bfield.Field[p, q].First() is Peasant)
                                {
                                    bfield.Move(p, q, p, q - 1);
                                    isDone = true;
                                }

                            }
                        }

                    }
                  
                    if (!isDone && eMove == 1) // moves archers 
                    {
                        for (int p = 0; p < 10; p++)
                        {
                            for (int q = 0; q < 10; q++)
                            {
                                if (bfield.Field[p, q].Count != 0 && bfield.Field[p, q].First().Team == 2 && bfield.Field[p, q].First() is Archer)
                                {
                                    bfield.Move(p, q, p, q - 1);
                                    isDone = true;
                                }

                            }
                        }
                    }
                
                    if (!isDone && eMove == 2) // moves footmans 
                    {
                        for (int p = 0; p < 10; p++)
                        {
                            for (int q = 0; q < 10; q++)
                            {
                                if (bfield.Field[p, q].Count != 0 && bfield.Field[p, q].First().Team == 2 && bfield.Field[p, q].First() is Footman)
                                {
                                    bfield.Move(p, q, p, q - 1);
                                    isDone = true;

                                }

                            }
                        }
                    }

                Globals.onTurn = true;
            }
        }

        public void Move(int oldX, int oldY, int newX, int newY)
        {
            if (oldX > 9 || oldX < 0 || oldY > 9 || oldY < 0 || newX > 9 || newX < 0 || newY > 9 || newY < 0)
            {
                Print.PrintOnPosition(5, 15, "Invalid position coordinates !");
            }

            else if (Field[newX, newY].Count != 0)
            {
                Print.PrintOnPosition(5, 15, "The end position is already occupied !");
            }
            else if (Field[oldX, oldY].Count == 0)
            {
                Print.PrintOnPosition(5, 15, "Incorrect initial position");


            }
            else if (Field[oldX, oldY].FirstOrDefault() is Archer && (Math.Abs(oldX - newX) > 3 || Math.Abs(oldY - newY) > 3)
                || Field[oldX, oldY].FirstOrDefault() is Peasant && (Math.Abs(oldX - newX) > 3 || Math.Abs(oldY - newY) > 3))
            {
                Print.PrintOnPosition(5, 15, "This unit/s can't go too far !");
            }

            else if (Field[oldX, oldY].FirstOrDefault() is Footman && (Math.Abs(oldX - newX) > 4 || Math.Abs(oldY - newY) > 4))
            {
                Print.PrintOnPosition(5, 15, "This unit/s can't go too far !");
            }

            else if (Field[oldX, oldY].FirstOrDefault() is Griffon && (Math.Abs(oldX - newX) > 5 || Math.Abs(oldY - newY) > 5))
            {
                Print.PrintOnPosition(5, 15, "This unit/s can't go too far !");
            }

            else
            {

                foreach (var creature in Field[oldX, oldY])
                {
                    Field[newX, newY].Add(creature);
                }

                Field[oldX, oldY] = new List<Creature>();

                Print.PrintOnPosition(5, 15, "Successfully moved !");
                Globals.onTurn = !Globals.onTurn; // if someone has moved the other player is on turn

            }
        }

        public void Attack(int oldX, int oldY, int newX, int newY)
        {
            if (oldX > 9 || oldX < 0 || oldY > 9 || oldY < 0 || newX > 9 || newX < 0 || newY > 9 || newY < 0)
            {
                Print.PrintOnPosition(5, 15, "Invalid position coordinates !");
            }
            else if (Field[newX, newY].Count == 0)
            {
                Print.PrintOnPosition(5, 15, "No units to attack at this position !");
            }
            else if (Field[oldX, oldY].Count == 0)
            {
                Print.PrintOnPosition(5, 15, "No attacker units found !");
            }
            else if (Field[oldX, oldY].First().Team == Field[newX, newY].First().Team)
            {
                Print.PrintOnPosition(5, 15, "You can not attack your units !");
            }
            else if (Field[oldX, oldY].FirstOrDefault() is Peasant && (Math.Abs(oldX - newX) > 1 || Math.Abs(oldY - newY) > 1)
                || Field[oldX, oldY].FirstOrDefault() is Footman && (Math.Abs(oldX - newX) > 1 || Math.Abs(oldY - newY) > 1))
            {
                Print.PrintOnPosition(5, 15, "The distance between the units is too large !");
            }
            else if (Field[oldX, oldY].FirstOrDefault() is Griffon && (Math.Abs(oldX - newX) > 2 || Math.Abs(oldY - newY) > 2))
            {
                Print.PrintOnPosition(5, 15, "The distance between the units is too large !");
            }

            else
            {
                int totalDamage = 0;
                int totalDefence = 0;

                foreach (var creature in Field[oldX, oldY])   // total damage of attacker units
                {
                    totalDamage += creature.Damage;
                }
                foreach (var creature in Field[newX, newY])  // total defence of defending units
                {
                    totalDefence += creature.Defense;
                }

                int pureDamage = totalDamage - totalDefence;
                int damageToOneUnit = pureDamage / Field[newX, newY].Count();

                foreach (var creature in Field[newX, newY])
                {
                    creature.Health -= damageToOneUnit;
                }
                Print.PrintOnPosition(5, 15, String.Format("You attacked the units at position ({0},{1})", newX, newY));

                Globals.onTurn = !Globals.onTurn;
            }
        }


    }
}