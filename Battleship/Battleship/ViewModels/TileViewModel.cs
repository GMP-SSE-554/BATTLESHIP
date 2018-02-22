using Battleship.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Battleship.ViewModels
{
    public class TileViewModel : INotifyPropertyChanged
    {
        Tile _tile;

        public TileViewModel()
        {
            _tile = new Tile();
        }
        
        public int Row { get { return _tile.Row; } }
        
        public int Column { get { return _tile.Column; } }
        
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
            get { return _tile.FillColor; }
            set
            {
                _tile.FillColor = value;
                OnPropertyChanged();
            }
        }

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
