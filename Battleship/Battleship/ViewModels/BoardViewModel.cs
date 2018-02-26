using Battleship.Models;
using Battleship.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI;

namespace Battleship.ViewModels
{
    public class BoardViewModel
    {
        IBoardService _boardService;
        Board _board;

        public BoardViewModel(IBoardService boardService)
        {
            _board = new Board();
            _boardService = boardService;
            _boardService.PerformInitialBoardSetup(_board);
            foreach (var tileModel in _board.Tiles)
            {
                Tiles.Add(new TileViewModel(tileModel));
            }
        }

        public void PreviewShip(Ship ship)
        {
            int rowOffset = 0;
            int columnOffset = 0;
            for(int i = 0; i < ship.Length; i++)
            {
                _board.TileAt(ship.RootTile.Row, ship.RootTile.Column).FillColor = Colors.Aquamarine;
                if (ship.IsHorizontal) columnOffset++;
                else rowOffset++;
            }
        }

        public int NumRows { get { return _board.NumRows; } }

        public int NumColumns { get { return _board.NumColumns; } }

        public List<TileViewModel> Tiles { get; } = new List<TileViewModel>();
    }
}
