using Battleship.Models;
using Battleship.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

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

        public int NumRows { get { return _board.NumRows; } }

        public int NumColumns { get { return _board.NumColumns; } }

        public List<TileViewModel> Tiles { get; } = new List<TileViewModel>();
    }
}
