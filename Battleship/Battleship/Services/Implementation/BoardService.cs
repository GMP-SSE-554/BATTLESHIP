﻿using Battleship.Constants;
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
                        Board = board,
                        FillColor = Colors.FloralWhite,
                        BorderColor = Colors.SlateGray
                    });
                }
            }
        }

        /// <summary>
        /// Adds the player ships.
        /// </summary>
        /// <param name="board">The board.</param>
        public void AddPlayerShips(Board board)
        {
            if (board != null)
            {
                foreach (ShipType ship in Enum.GetValues(typeof(ShipType)))
                {
                    board.Ships.Add(new Ship(ship));
                }
            }
        }
    }
}
