using Battleship.Models;
using Battleship.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Battleship.ViewModels
{
    public class BoardViewModel : INotifyPropertyChanged
    {
        IBoardService _boardService;
        Board _board;

        public BoardViewModel(IBoardService boardService)
        {
            _board = new Board();
            _boardService = boardService;
            _boardService.PerformInitialBoardSetup(_board);
        }

        public int NumRows { get { return _board.NumRows; } }

        public int NumColumns { get { return _board.NumColumns; } }

        public ObservableCollection<Tile> Tiles { get { return _board.Tiles; } }

        /// <summary>
        /// Notifies listeners of property change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
