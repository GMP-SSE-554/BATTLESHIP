using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Models;
using System.Threading.Tasks;

namespace Battleship.Services
{
    public class TileService : ITileService
    {
        public void PlaceShip(Board board, Ship ship)
        {
            int rowOffset = 0;
            int columnOffset = 0;
            for (int i = 0; i < ship.Length; i++)
            {
                board.TileAt(ship.Row + rowOffset, ship.Column + columnOffset).ContainsShip = true;

                if (ship.IsHorizontal) { columnOffset += 1; }
                else { rowOffset += 1; }
            }
        }

        public bool ShipWillIntersect(Board board, Ship ship)
        {
            int rowOffset = 0;
            int columnOffset = 0;
            for (int i = 0; i < ship.Length; i++)
            {
                if (board.TileAt(ship.Row + rowOffset, ship.Column + columnOffset).ContainsShip) return true;

                if (ship.IsHorizontal) { columnOffset += 1; }
                else { rowOffset += 1; }
            }

            return false;
        }
    }
}
