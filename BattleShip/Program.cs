using BattleShipLiteLibrary;
using BattleShipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static PlayerInfoModel CreatePlayer()
        {
            PlayerInfoModel player = new PlayerInfoModel();
            //Ask the User for their name
            player.UserName = GetUserName();

            //Load the shot grid
            GameLogic.InitilizerGrid(player);

            //Ask user for their 5 ship placements
            PlaceShips(player);
            //Clear
            Console.Clear();

            return player;

            
        
        }

        private static string GetUserName()
        {
            Console.WriteLine("Enter your Name");
            string name = Console.ReadLine();

            return name;
        }

        private static void PlaceShips(PlayerInfoModel model)
        {
            do
            {
                Console.WriteLine($"Where do you want to place the ship?{model.ShipLocation.Count +1}:");
                string location = Console.ReadLine();
                bool isValidLocation = GameLogic.StoreShip(model,location);// Taking location from the user and model object

            } while (model.ShipLocation.Count<5);
        }
    }
}
