namespace ConsoleGame
{
    using System;

    using ConsoleGame.ShopThings;
    using ConsoleGame.PlayerNS;

    public class StartGame
    {
        public StartGame()
        {

        }

        public void Run()
        {

            Battlefield battlefield = new Battlefield();
            Shop s = new Shop();
            Player player = new Player();
            Enemy ePlayer = new Enemy();

            Game.PrintMainMenu(player, ePlayer, battlefield);
        }
    }
}
