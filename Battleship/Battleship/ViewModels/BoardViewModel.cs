using Battleship.Models;
using Battleship.Services;
using System.Collections.Generic;
using System.Windows.Input;

namespace Battleship.ViewModels
{
    public class BoardViewModel
    {
        IBoardService _boardService;
        Board _humanBoard;
        Board _computerBoard;
        Human _human;
        Computer _computer;

        public BoardViewModel(IBoardService boardService)
        {
            _humanBoard = new Board();
            _computerBoard = new Board();
            _human = new Human();
            _computer = new Computer();
            _boardService = boardService;
            AddTiles(HumanTiles, _humanBoard);
            AddTiles(ComputerTiles, _computerBoard);
            _boardService.AddPlayerShips(_human);
            _boardService.AddPlayerShips(_computer);
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

        public Player Human { get { return _human; } }

        public Player Computer { get { return _computer; } }

        public Board HumanBoard { get { return _humanBoard; } }

        public Board ComputerBoard { get { return _computerBoard; } }

        ICommand _rotateShip;
        public ICommand RotateShip
        {
            get { return _rotateShip ?? (_rotateShip = new Command(p => true, a => Rotate())); }
        }

        void Rotate()
        {
            Human.ShipBeingPlaced.IsHorizontal = !Human.ShipBeingPlaced.IsHorizontal;
        }
    }
}
