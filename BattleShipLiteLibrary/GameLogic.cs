using BattleShipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLiteLibrary
{
   public class GameLogic
    {
       public static void InitilizerGrid(PlayerInfoModel model)
        {
            List<string> letters = new List<string>
            //letters.Add("A");
            //letters.Add("B");
            //letters.Add("C");
            //letters.Add("B");
            {
                "A",
                "B",
                "C",
                "D",
                "E"

            };

            List<int> numbers = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            foreach(var letter in letters)
            {
                foreach(var number in numbers)
                {
                    AddGridSpot(letter,number,model);
                }
            }
           
               
        }

        private static void AddGridSpot(string letter, int number,PlayerInfoModel model)
        {
            GridSpotModel spot = new GridSpotModel();
            spot.SpotLetter = letter;
            spot.SpotNumber = number;
            spot.Status = GridSpotStatus.Empty;

            model.ShotGrid.Add(spot); // Adding spot object to a ShotGrid
        }

        public static bool StoreShip(PlayerInfoModel model, string letter)
        {
            throw new NotImplementedException();
        }
    }
}
