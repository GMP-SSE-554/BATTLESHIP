using Battleship.Constants;
using Battleship.Models;
using System;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Battleship.Services
{
    public class BoardService : IBoardService
    {
        /// <summary>
        /// Performs the initial board setup.
        /// </summary>
        /// <param name="board">The board.</param>
        public void PerformInitialBoardSetup(Board board)
        {
            for (int i = 0; i < NumericalConstants.BOARD_ROWS; i++)
            {
                for (int j = 0; j < NumericalConstants.BOARD_COLUMNS; j++)
                {
                    board.Tiles.Add(new Tile() {
                        Row = i,
                        Column = j,
                        FillColor = Colors.FloralWhite,
                        BorderColor = Colors.SlateGray
                    });
                }
            }
        }

        /// <summary>
        /// Adds the player ships.
        /// </summary>
        /// <param name="player">The player.</param>
        public void AddPlayerShips(Player player)
        {
            if (player != null)
            {
                foreach (ShipType ship in Enum.GetValues(typeof(ShipType)))
                {
                    player.PlayerShips.Add(new Ship(ship));
                }
            }
        }

        public void PlaceShip(Board board, Ship ship)
        {
            int rowOffset = 0;
            int columnOffset = 0;
            for (int i = 0; i < ship.Length; i++)
            {
                board.tileAt(ship.Row + rowOffset, ship.Column + columnOffset).ContainsShip = true;

                if (ship.IsHorizontal) { columnOffset += 1; }
                else { rowOffset += 1; }
            }
        }
    }
}
