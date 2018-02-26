using Battleship.Models;
using Battleship.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Battleship.ViewModels
{
    public class TileViewModel : INotifyPropertyChanged
    {
        Tile _tile;
        TileService _tileService;
        
        public TileViewModel(Tile tile)
        {
            _tile = tile;
            _tileService = new TileService();
        }

        public int Row { get { return _tile.Row; } }

        public int Column { get { return _tile.Column; } }

        public Board Board
        {
            get { return _tile.Board; }
        }

        bool _shipsBeingPlaced;
        public bool ShipsBeingPlaced
        {
            get { return _shipsBeingPlaced; }
            set { _shipsBeingPlaced = value; }
        }

        public bool ContainsShip
        {
            get { return _tile.ContainsShip; }
            set
            {
                _tile.ContainsShip = value;
                OnPropertyChanged();
            }
        }

        public bool IsChecked
        {
            get { return _tile.IsChecked; }
            set
            {
                _tile.IsChecked = value;
                OnPropertyChanged();
            }
        }

        public bool IsPreviewTile
        {
            get { return _tile.IsPreviewTile; }
            set
            {
                _tile.IsPreviewTile = value;
                //Could have constants file with tile colors for each state and
                //a single UpdateColor method to update tile colors based on state
                if (IsPreviewTile) FillColor = new SolidColorBrush(Windows.UI.Colors.Aquamarine);
                else FillColor = new SolidColorBrush(Windows.UI.Colors.Blue);
                OnPropertyChanged();
            }
        }

        public SolidColorBrush FillColor
        {
            get { return new SolidColorBrush(_tile.FillColor); }
            set
            {
                _tile.FillColor = value.Color;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush BorderColor
        {
            get { return new SolidColorBrush(_tile.BorderColor); }
            set
            {
                _tile.BorderColor = value.Color;
                OnPropertyChanged();
            }
        }

        public bool IsMousedOver
        {
            get { return _tile.IsMousedOver; }
            set
            {
                _tile.IsMousedOver = value;
                _tileService.PreviewShip(this);
                OnPropertyChanged();
            }
        }

        ICommand _changeFill;
        public ICommand OnClick
        {
            get
            {
                if (!_shipsBeingPlaced)
                {
                    return _changeFill ?? (_changeFill = new Command(p => true, a => Change()));
                } else
                {
                    return _changeFill ?? (_changeFill = new Command(p => true, a => Change()));
                }
            }
        }

        /// <summary>
        /// Changes color of tile. Currently set up to demo binding. Needs to be fleshed out.
        /// </summary>
        void Change()
        {
            this.FillColor = new SolidColorBrush(Colors.Red);
        }

        /// <summary>
        /// Notifies listeners of property change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
