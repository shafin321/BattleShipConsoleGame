using BattleShipLiteLibrary;
using BattleShipLiteLibrary.Models;
using System;
using System.CodeDom.Compiler;
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
          
            PlayerInfoModel activePlayer = CreatePlayer("player1");
            PlayerInfoModel Opponent = CreatePlayer("player2");
            PlayerInfoModel winner = null;



            do
            {
                //Display grid from activePlayer on where they fired
                 DisplayShotGrid(activePlayer);

                //Ask active player for shot
                //Determine if its valid shot
                //Determine shot result

                RecordPlayerShot(activePlayer, Opponent);

                //Determine if the game should continue
                bool doseGameContinue = GameLogic.PlayerIsActive(Opponent);
                //if over, set activePlayer is winner
                //else, swap positon(activePlayer to oppnent)
                if (doseGameContinue == true)
                {
                    //Swaping using temp 
                    PlayerInfoModel temp = Opponent;
                    Opponent = activePlayer;
                    activePlayer = temp;

                    //Swap using tuple
                    (activePlayer, Opponent) = (Opponent, activePlayer);
                }
                else
                {
                    activePlayer = winner;
                }



            } while (winner == null);

        }

        private static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            throw new NotImplementedException();
            //Ask for shot
            //Determine what row and column that is split is apart
            //Determine its a valid shot
            // Go back to begaining if not a valid shot
        }

        private static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            foreach(var gridSpot in activePlayer.ShotGrid)
            {
                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.WriteLine($" {gridSpot.SpotLetter}{gridSpot.SpotNumber} ");
                }
                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.WriteLine(" X ");
                }
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.WriteLine(" O ");
                }
                else
                {
                    Console.WriteLine(" ? ");
                }
            }
        }

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            Console.WriteLine($"Player Information for{playerTitle}");
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
                Console.WriteLine($"Where do you want to place the ship ? {model.ShipLocation.Count +1}:");
                string location = Console.ReadLine();
                bool isValidLocation = GameLogic.StoreShip(model,location);// Taking location from the user and model object

            } while (model.ShipLocation.Count<5);
        }
    }
}
