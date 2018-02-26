using Battleship.Models;
using Battleship.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI;
using System.Windows.Input;

namespace Battleship.ViewModels
{
    public class BoardViewModel
    {
        IBoardService _boardService;
        Board _humanBoard;
        Board _computerBoard;

        public BoardViewModel(IBoardService boardService)
        {
            _humanBoard = new Board();
            _computerBoard = new Board();
            _boardService = boardService;
            AddTiles(HumanTiles, _humanBoard);
            AddTiles(ComputerTiles, _computerBoard);
        }

        void AddTiles(List<TileViewModel> tiles, Board model)
        {
            _boardService.PerformInitialBoardSetup(model);
            foreach (var tileModel in model.Tiles)
            {
                tiles.Add(new TileViewModel(tileModel));
            }
        }

        public List<TileViewModel> HumanTiles { get; } = new List<TileViewModel>();

        public List<TileViewModel> ComputerTiles { get; } = new List<TileViewModel>();

        public Board HumanBoard { get { return _humanBoard; } }
        
        public Board ComputerBoard { get { return _computerBoard; } }

        ICommand _rotateShip;
        public ICommand RotateShip
        {
            get { return _rotateShip ?? (_rotateShip = new Command(p => true, a => Rotate())); }
        }

        void Rotate()
        {
            if (HumanBoard.ShipBeingPlaced != null)
            {
                HumanBoard.ShipBeingPlaced.IsHorizontal = !HumanBoard.ShipBeingPlaced.IsHorizontal;
            }
        }
    }
}
