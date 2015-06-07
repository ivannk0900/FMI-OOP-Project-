namespace ConsoleGame.ShopThings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ConsoleGame.PlayerNS;
    using ConsoleGame.Creatures;

    public class Shop
    {
        public static void PrintShopMenu(Player player,Enemy ePlayer, Battlefield bfield)
        {
            Console.CursorVisible = false;

            Cursor cursor = new Cursor();
            cursor.x = 2;
            cursor.y = 2;
            cursor.color = ConsoleColor.Green;
            cursor.text = ">";

            Print.PrintOnPosition(13, 0, "Shop Menu", ConsoleColor.Yellow);
            Print.PrintOnPosition(5, 2, "View available creatures", ConsoleColor.Magenta);
            Print.PrintOnPosition(5, 4, "Buy", ConsoleColor.Magenta);
            Print.PrintOnPosition(5, 6, "Check gold", ConsoleColor.Magenta);
            Print.PrintOnPosition(5, 8, "Go to main menu", ConsoleColor.Magenta);

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


                    if (cursor.y == 2)  // Option view available creatures
                    {
                        if (pressedkey.Key == ConsoleKey.DownArrow)
                        {
                            cursor.y = 4;
                            Print.PrintOnPosition(2, 2, " ", ConsoleColor.White);
                        }
                        else if (pressedkey.Key == ConsoleKey.UpArrow)
                        {
                            cursor.y = 8;
                            Print.PrintOnPosition(2, 2, " ", ConsoleColor.White);

                        }
                    }
                    else if (cursor.y == 4) // Option buy
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
                    else if (cursor.y == 6) // Option check gold
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
                            cursor.y = 2;
                            Print.PrintOnPosition(2, 8, " ", ConsoleColor.White);
                        }
                        else if (pressedkey.Key == ConsoleKey.UpArrow)
                        {
                            cursor.y = 6;
                            Print.PrintOnPosition(2, 8, " ", ConsoleColor.White);

                        }
                    }
                    if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 2)
                    {
                        Print.PrintOnPosition(5, 13, "                                                    ");  // clears this part of the screen
                        Print.PrintOnPosition(5, 14, "                                                    ");
                        Print.PrintOnPosition(5, 15, "                                                    ");
                        Print.PrintOnPosition(5, 16, "                                                    ");
                        Print.PrintOnPosition(5, 17, "                                                    ");


                        Print.PrintOnPosition(5, 13, "Peasant -  30 gold");
                        Print.PrintOnPosition(5, 14, "Archer  -  50 gold");
                        Print.PrintOnPosition(5, 15, "Footman -  90 gold");
                        Print.PrintOnPosition(5, 16, "Griffon - 150 gold");
                        Print.PrintOnPosition(5, 17, "Hero    - 100 gold");
                    }
                    else if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 4)
                    {
                        Print.PrintOnPosition(5, 13, "                                                    ");  // clears this part of the screen
                        Print.PrintOnPosition(5, 14, "                                                    ");
                        Print.PrintOnPosition(5, 15, "                                                    ");
                        Print.PrintOnPosition(5, 16, "                                                    ");
                        Print.PrintOnPosition(5, 17, "                                                    ");



                        Print.PrintOnPosition(5, 13, "Enter command {buy} {unit} {count}");

                        Console.SetCursorPosition(5, 14);
                        string input = Console.ReadLine();

                        string[] sinput = input.Split(' ');
                        if (sinput.Length != 3)
                        {
                            Print.PrintOnPosition(5, 15, "Unknown command !");
                            goto Menu;
                        }
                        switch (sinput[1])
                        {
                            case "hero":
                                {
                                    int count;
                                    bool isCount = int.TryParse(sinput[2], out count);
                                    if (!isCount)
                                    {
                                        Print.PrintOnPosition(5, 15, "Incorrect input!");
                                        goto Menu;
                                    }
                                    if (player.Gold >= count * 100)
                                    {
                                        player.Gold -= count * 100;
                                        for (int i = 0; i < count; i++)
                                        {
                                            player.CreaturesList.Add(new Hero(100, 100, 0, 100, 3, 5, 1));
                                        }
                                        Print.PrintOnPosition(5, 15, String.Format("You have just successfully bought {0} hero/s !", count));
                                        goto Menu;

                                    }
                                    else
                                    {
                                        Print.PrintOnPosition(5, 15, "You don't have enough gold !   ");
                                    }
                                    break;
                                }
                            case "peasant":
                                {
                                    int count;
                                    bool isCount = int.TryParse(sinput[2], out count);
                                    if (!isCount)
                                    {
                                        Print.PrintOnPosition(5, 15, "Incorrect input!");
                                        goto Menu;
                                    }
                                    if (player.Gold >= count * 30)
                                    {
                                        player.Gold -= count * 30;
                                        for (int i = 0; i < count; i++)
                                        {
                                            player.CreaturesList.Add(new Peasant(100, 1, 0, 100, 3, 5, 1));
                                        }
                                        Print.PrintOnPosition(5, 15, String.Format("You have just successfully bought {0} peasant/s !", count));
                                        goto Menu;

                                    }
                                    else
                                    {
                                        Print.PrintOnPosition(5, 15, "You don't have enough gold !   ");
                                    }
                                    break;
                                }
                            case "archer":
                                {
                                    int count;
                                    bool isCount = int.TryParse(sinput[2], out count);
                                    if (!isCount)
                                    {
                                        Print.PrintOnPosition(5, 15, "Incorrect input !");
                                        goto Menu;
                                    }
                                    if (player.Gold >= count * 50)
                                    {
                                        player.Gold -= count * 50;
                                        for (int i = 0; i < count; i++)
                                        {
                                            player.CreaturesList.Add(new Archer(100, 200, 1, 100, 3, 5, 1));
                                        }
                                        Print.PrintOnPosition(5, 15, String.Format("You have just successfully bought {0} archer/s !", count));
                                        goto Menu;

                                    }
                                    else
                                    {
                                        Print.PrintOnPosition(5, 15, "You don't have enough gold !             ");
                                    }
                                    break;
                                }
                            case "footman":
                                {
                                    int count;
                                    bool isCount = int.TryParse(sinput[2], out count);
                                    if (!isCount)
                                    {
                                        Print.PrintOnPosition(5, 15, "Incorrect input !");
                                        goto Menu;
                                    }
                                    if (player.Gold >= count * 90)
                                    {
                                        player.Gold -= count * 90;
                                        for (int i = 0; i < count; i++)
                                        {
                                            player.CreaturesList.Add(new Footman(100, 3, 1, 100, 4, 10, 1));
                                        }
                                        Print.PrintOnPosition(5, 15, String.Format("You have just successfully bought {0} footman/s !", count));
                                        goto Menu;

                                    }
                                    else
                                    {
                                        Print.PrintOnPosition(5, 15, "You don't have enough gold !         ");
                                    }
                                    break;
                                }
                            case "griffon":
                                {
                                    int count;
                                    bool isCount = int.TryParse(sinput[2], out count);
                                    if (!isCount)
                                    {
                                        Print.PrintOnPosition(5, 15, "Incorrect input !");
                                        goto Menu;
                                    }
                                    if (player.Gold >= count * 150)
                                    {
                                        player.Gold -= count * 150;
                                        for (int i = 0; i < count; i++)
                                        {
                                            player.CreaturesList.Add(new Griffon(100, 50, 2, 100, 5, 30, 1));
                                        }
                                        Print.PrintOnPosition(5, 15, String.Format("You have just successfully bought {0} griffon/s !", count));
                                        goto Menu;

                                    }
                                    else
                                    {
                                        //Console.Clear();
                                        //Shop.PrintShopMenu(player);
                                        //PrintOnPosition(30, 6, "Enter command {buy} {unit} {count}");
                                        Print.PrintOnPosition(5, 15, "You don't have enough gold !  ");
                                    }
                                    break;
                                }
                            default:
                                {
                                    Print.PrintOnPosition(5, 15, "Unknown command !");
                                    goto Menu;

                                }
                        }
                    }
                    else if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 6)
                    {
                        Print.PrintOnPosition(5, 13, "                                                    ");  // clears this part of the screen
                        Print.PrintOnPosition(5, 14, "                                                    ");
                        Print.PrintOnPosition(5, 15, "                                                    ");
                        Print.PrintOnPosition(5, 16, "                                                    ");
                        Print.PrintOnPosition(5, 17, "                                                    ");

                        Print.PrintOnPosition(5, 13, String.Format("You have {0} gold !", player.Gold));
                    }
                    else if (pressedkey.Key == ConsoleKey.Enter && cursor.y == 8)
                    {
                        Console.Clear();
                        Game.PrintMainMenu(player,ePlayer,bfield);
                    }

                }
                Print.PrintOnPosition(cursor.x, cursor.y, cursor.text, cursor.color);
            }

        }


    }
}
