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
        Board _board;
        Board _humanBoard;
        Board _computerBoard;
        Human _human;
        Computer _computer;

        public BoardViewModel(IBoardService boardService)
        {
            _board = new Board();
            _humanBoard = new Board();
            _computerBoard = new Board();
            _human = new Human();
            _computer = new Computer();
            _boardService = boardService;
            _boardService.PerformInitialBoardSetup(_board);
            foreach (var tileModel in _board.Tiles)
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
                Tiles.Add(new TileViewModel(tileModel));
                tiles.Add(new TileViewModel(tileModel));
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

        public List<TileViewModel> HumanTiles { get; } = new List<TileViewModel>();

        public List<TileViewModel> ComputerTiles { get; } = new List<TileViewModel>();

        public Player Human { get { return _human; } }

        public Player Computer { get { return _computer; } }

        public Board HumanBoard { get { return _humanBoard; } }

        public List<TileViewModel> Tiles { get; } = new List<TileViewModel>();
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
