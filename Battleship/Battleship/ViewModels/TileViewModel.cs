using Battleship.Models;
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

        public TileViewModel(Tile tile)
        {
            _tile = tile;
        }

        public int Row { get { return _tile.Row; } }

        public int Column { get { return _tile.Column; } }

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
