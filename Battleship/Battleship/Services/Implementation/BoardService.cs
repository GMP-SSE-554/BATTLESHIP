using Battleship.Constants;
using Battleship.Models;
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
            board.NumRows = NumericalConstants.BOARD_ROWS;
            board.NumColumns = NumericalConstants.BOARD_COLUMNS;
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
