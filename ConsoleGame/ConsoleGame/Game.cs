namespace ConsoleGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;

    using ConsoleGame.Creatures;
    using ConsoleGame.PlayerNS;
    using ConsoleGame.ShopThings;

    public class Game
    {

        public static void PrintMainMenu(Player player, Enemy ePlayer, Battlefield bfield)
        {

            Console.CursorVisible = false;

            Cursor cursor = new Cursor();
            cursor.x = 2;
            cursor.y = 2;
            cursor.text = ">";
            cursor.color = ConsoleColor.Green;

            Print.PrintOnPosition(13, 0, "Main Menu", ConsoleColor.Yellow);
            Print.PrintOnPosition(5, 2, "Start game", ConsoleColor.Magenta);
            Print.PrintOnPosition(5, 4, "Go to shop menu", ConsoleColor.Magenta);
            Print.PrintOnPosition(5, 6, "Exit", ConsoleColor.Magenta);


            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedkey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if (cursor.y == 2)
                    {
                        if (pressedkey.Key == ConsoleKey.DownArrow)
                        {
                            cursor.y = 4;
                            Print.PrintOnPosition(2, 2, " ", ConsoleColor.White);
                        }
                        else if (pressedkey.Key == ConsoleKey.UpArrow)
                        {
                            cursor.y = 6;
                            Print.PrintOnPosition(2, 2, " ", ConsoleColor.White);

                        }
                    }
                    else if (cursor.y == 4)
                    {
                        if (pressedkey.Key == ConsoleKey.DownArrow)
                        {
                            cursor.y = 6;
                            Print.PrintOnPosition(2, 4, " ", ConsoleColor.White);  // clears the last symbol that has been there
                        }
                        else if (pressedkey.Key == ConsoleKey.UpArrow)
                        {
                            cursor.y = 2;
                            Print.PrintOnPosition(2, 4, " ", ConsoleColor.White);
                        }
                    }

                    else if (cursor.y == 6)
                    {
                        if (pressedkey.Key == ConsoleKey.DownArrow)
                        {
                            cursor.y = 2;
                            Print.PrintOnPosition(2, 6, " ", ConsoleColor.White);
                        }
                        else if (pressedkey.Key == ConsoleKey.UpArrow)
                        {
                            cursor.y = 4;
                            Print.PrintOnPosition(2, 6, " ", ConsoleColor.White);
                        }
                    }


                    if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 2)
                    {

                        Console.Clear();



                        var peasants = (from creature in player.CreaturesList
                                        where creature is Peasant
                                        select creature).ToList();

                        var ePeasants = (from creature in ePlayer.CreaturesList
                                         where creature is Peasant
                                         select creature).ToList();

                        bfield.AddToField(0, 0, peasants);
                        bfield.AddToField(0, 9, ePeasants);

                        var footmans = (from creature in player.CreaturesList
                                        where creature is Footman
                                        select creature).ToList();
                        var eFootmans = (from creature in ePlayer.CreaturesList
                                         where creature is Footman
                                         select creature).ToList();
                        bfield.AddToField(2, 0, footmans);
                        bfield.AddToField(2, 9, eFootmans);

                        var archers = (from creature in player.CreaturesList
                                       where creature is Archer
                                       select creature).ToList();
                        var eArchers = (from creature in ePlayer.CreaturesList
                                        where creature is Archer
                                        select creature).ToList();
                        bfield.AddToField(4, 0, archers);
                        bfield.AddToField(4, 9, eArchers);

                        var griffons = (from creature in player.CreaturesList
                                        where creature is Griffon
                                        select creature).ToList();
                        var eGriffons = (from creature in ePlayer.CreaturesList
                                         where creature is Griffon
                                         select creature).ToList();
                        bfield.AddToField(6, 0, griffons);
                        bfield.AddToField(6, 9, eGriffons);




                        Game.PrintGameMenu(player, ePlayer, bfield);
                    }

                    else if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 4)
                    {
                        Console.Clear();
                        Shop.PrintShopMenu(player, ePlayer, bfield);
                    }
                    else if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 6)
                    {
                        Environment.Exit(0);
                    }

                }
                Print.PrintOnPosition(cursor.x, cursor.y, cursor.text, cursor.color);

            }
        }

        public static void PrintStatus(Player player, Enemy ePlayer, Battlefield bfield)
        {
            int startX = 49;
            int startY = 0;
            for (int i = 0; i <= 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Print.PrintHorizontalLine(startX, startY, 30);
                startY += 2;
            }
            startX = 49;
            startY = 0;
            for (int i = 0; i <= 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Print.PrintVerticalLine(startX, startY, 20);
                startX += 3;
            }

            //Console.SetCursorPosition(50, 1);
            //Console.Write("00");
            //Console.SetCursorPosition(53, 1);
            //Console.Write("10");
            //Console.SetCursorPosition(56, 1);
            //Console.Write("20");
            //Console.SetCursorPosition(50, 3);
            //Console.Write("01");
            //Console.SetCursorPosition(50, 5);
            //Console.Write("02");

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (bfield.Field[i, j].Count != 0)
                    {
                        Console.SetCursorPosition((i + 50) + i * 3 - i, (j + 1) + j * 2 - j);
                        if (bfield.Field[i, j].FirstOrDefault() is Archer)
                        {
                            if (bfield.Field[i, j].FirstOrDefault().Team == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("A{0}", bfield.Field[i, j].Count);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("A{0}", bfield.Field[i, j].Count);
                            }
                        }
                        if (bfield.Field[i, j].FirstOrDefault() is Peasant)
                        {
                            if (bfield.Field[i, j].FirstOrDefault().Team == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("P{0}", bfield.Field[i, j].Count);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("P{0}", bfield.Field[i, j].Count);
                            }
                        }
                        if (bfield.Field[i, j].FirstOrDefault() is Footman)
                        {
                            if (bfield.Field[i, j].FirstOrDefault().Team == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("F{0}", bfield.Field[i, j].Count);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("F{0}", bfield.Field[i, j].Count);
                            }
                        }
                        if (bfield.Field[i, j].FirstOrDefault() is Griffon)
                        {
                            if (bfield.Field[i, j].FirstOrDefault().Team == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("G{0}", bfield.Field[i, j].Count);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("G{0}", bfield.Field[i, j].Count);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (bfield.Field[i, j].Count != 0 && bfield.Field[i, j].FirstOrDefault().Health < 0)
                    {
                        bfield.Field[i, j] = new List<Creature>();
                    }
                }
            }

        }

        public static void PrintGameMenu(Player player, Enemy ePlayer, Battlefield bfield)
        {
            Console.CursorVisible = false;

            Cursor cursor = new Cursor();
            cursor.x = 2;
            cursor.y = 2;
            cursor.text = ">";
            cursor.color = ConsoleColor.Green;

            Print.PrintOnPosition(13, 0, "Game Menu", ConsoleColor.Yellow);
            Print.PrintOnPosition(5, 2, "Move", ConsoleColor.Magenta);
            Print.PrintOnPosition(5, 4, "Attack", ConsoleColor.Magenta);
            Print.PrintOnPosition(5, 6, "Print", ConsoleColor.Magenta);
            Print.PrintOnPosition(5, 8, "End move", ConsoleColor.Magenta);
            Print.PrintOnPosition(5, 10, "Exit", ConsoleColor.Magenta);

        Menu:
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedkey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if (cursor.y == 2)
                    {
                        if (pressedkey.Key == ConsoleKey.DownArrow)
                        {
                            cursor.y = 4;
                            Print.PrintOnPosition(2, 2, " ", ConsoleColor.White);
                        }
                        else if (pressedkey.Key == ConsoleKey.UpArrow)
                        {
                            cursor.y = 10;
                            Print.PrintOnPosition(2, 2, " ", ConsoleColor.White);

                        }
                    }
                    else if (cursor.y == 4)
                    {
                        if (pressedkey.Key == ConsoleKey.DownArrow)
                        {
                            cursor.y = 6;
                            Print.PrintOnPosition(2, 4, " ", ConsoleColor.White);  // clears the last symbol that has been there
                        }
                        else if (pressedkey.Key == ConsoleKey.UpArrow)
                        {
                            cursor.y = 2;
                            Print.PrintOnPosition(2, 4, " ", ConsoleColor.White);
                        }
                    }

                    else if (cursor.y == 6)
                    {
                        if (pressedkey.Key == ConsoleKey.DownArrow)
                        {
                            cursor.y = 8;
                            Print.PrintOnPosition(2, 6, " ", ConsoleColor.White);
                        }
                        else if (pressedkey.Key == ConsoleKey.UpArrow)
                        {
                            cursor.y = 4;
                            Print.PrintOnPosition(2, 6, " ", ConsoleColor.White);
                        }
                    }

                    else if (cursor.y == 8)
                    {
                        if (pressedkey.Key == ConsoleKey.DownArrow)
                        {
                            cursor.y = 10;
                            Print.PrintOnPosition(2, 8, " ", ConsoleColor.White);
                        }
                        else if (pressedkey.Key == ConsoleKey.UpArrow)
                        {
                            cursor.y = 6;
                            Print.PrintOnPosition(2, 8, " ", ConsoleColor.White);
                        }
                    }
                    else if (cursor.y == 10)
                    {
                        if (pressedkey.Key == ConsoleKey.DownArrow)
                        {
                            cursor.y = 2;
                            Print.PrintOnPosition(2, 10, " ", ConsoleColor.White);
                        }
                        else if (pressedkey.Key == ConsoleKey.UpArrow)
                        {
                            cursor.y = 8;
                            Print.PrintOnPosition(2, 10, " ", ConsoleColor.White);
                        }
                    }


                    if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 2)  // option move
                    {
                        Print.PrintOnPosition(5, 15, "                                   ");
                        Print.PrintOnPosition(5, 16, "                                   ");


                        Print.PrintOnPosition(5, 13, "Enter command {move} {(source coords)} \n     {(destination coords)}");

                        Console.SetCursorPosition(5, 15);
                        string input = Console.ReadLine();

                        string[] sinput = input.Split(' ');
                        if (sinput.Length != 3)
                        {
                            Print.PrintOnPosition(5, 16, "Unknown command !");
                            goto Menu;
                        }

                        string[] source = sinput[1].Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] destination = sinput[2].Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);

                        if (source.Length != 2 || destination.Length != 2)
                        {
                            Print.PrintOnPosition(5, 16, "Unknown command !");
                            goto Menu;

                        }

                        if (Globals.onTurn)
                        {
                            bfield.Move(int.Parse(source[0]), int.Parse(source[1]), int.Parse(destination[0]), int.Parse(destination[1]));
                        }
                        else
                        {
                            Print.PrintOnPosition(5, 16, "You are not on turn !                    ");

                        }

                    }

                    else if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 4)  // option attack
                    {
                        Print.PrintOnPosition(5, 16, "                                            ");
                        Print.PrintOnPosition(5, 15, "                                            ");


                        Print.PrintOnPosition(5, 13, "Enter command {attack} {(source coords)} \n     {(destination coords)}");

                        Console.SetCursorPosition(5, 15);
                        string input = Console.ReadLine();

                        string[] sinput = input.Split(' ');
                        if (sinput.Length != 3)
                        {
                            Print.PrintOnPosition(5, 16, "Unknown command !");
                            goto Menu;
                        }
                        string[] source = sinput[1].Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] destination = sinput[2].Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);

                        if (source.Length != 2 || destination.Length != 2)
                        {
                            Print.PrintOnPosition(5, 16, "Unknown command !");
                            goto Menu;

                        }
                        if (Globals.onTurn)
                        {
                            bfield.Attack(int.Parse(source[0]), int.Parse(source[1]), int.Parse(destination[0]), int.Parse(destination[1]));

                        }
                        else
                        {
                            Print.PrintOnPosition(5, 15, "                                       ");
                            Print.PrintOnPosition(5, 16, "You are not on turn !                  ");

                        }
                    }
                    else if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 6)
                    {
                        Print.PrintOnPosition(50, 0, "                              ");
                        Print.PrintOnPosition(50, 1, "                              ");
                        Print.PrintOnPosition(50, 2, "                              ");
                        Print.PrintOnPosition(50, 3, "                              ");
                        Print.PrintOnPosition(50, 4, "                              ");
                        Print.PrintOnPosition(50, 5, "                              ");
                        Print.PrintOnPosition(50, 6, "                              ");
                        Print.PrintOnPosition(50, 7, "                              ");
                        Print.PrintOnPosition(50, 8, "                              ");
                        Print.PrintOnPosition(50, 9, "                              ");
                        Print.PrintOnPosition(50, 10, "                              ");
                        Print.PrintOnPosition(50, 11, "                              ");
                        Print.PrintOnPosition(50, 12, "                              ");
                        Print.PrintOnPosition(50, 13, "                              ");
                        Print.PrintOnPosition(50, 14, "                              ");
                        Print.PrintOnPosition(50, 15, "                              ");
                        Print.PrintOnPosition(50, 16, "                              ");
                        Print.PrintOnPosition(50, 17, "                              ");
                        Print.PrintOnPosition(50, 18, "                              ");
                        Print.PrintOnPosition(50, 19, "                              ");
                        Print.PrintOnPosition(50, 20, "                              ");


                        PrintStatus(player, ePlayer, bfield);

                        bool alive = false;
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                if (bfield.Field[i, j].Count != 0 && bfield.Field[i, j].FirstOrDefault().Team == 2)
                                {
                                    alive = true;

                                }
                            }
                        }
                        if (!alive)
                        {   
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(@"

oooooo   oooo                                              o8o              
 `888.   .8'                                               `'              
  `888. .8'    .ooooo.  oooo  oooo       oooo oooo    ooo oooo  ooo. .oo.   
   `888.8'    d88' `88b `888  `888        `88. `88.  .8'  `888  `888P Y88b  
    `888'     888   888  888   888         `88..]88..8'    888   888   888  
     888      888   888  888   888          `888'`888'     888   888   888  
    o888o     `Y8bod8P'  `V88VV8P'          `8'  `8'     o888o o888o o888o 

");
                            Thread.Sleep(1000000000);
                            
                            
                        }

                    }
                    else if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 8)   // option end move -> add to field 
                    {
                        Print.PrintOnPosition(5, 16, "                                            ");
                        Print.PrintOnPosition(5, 15, "                                            ");
                        bfield.DoEnemyAction(player, ePlayer, bfield);

                    }
                    else if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 10)
                    {
                        Console.Clear();
                        Game.PrintMainMenu(player, ePlayer, bfield);
                    }

                }
                Print.PrintOnPosition(cursor.x, cursor.y, cursor.text, cursor.color);

            }

        }

    }
}

