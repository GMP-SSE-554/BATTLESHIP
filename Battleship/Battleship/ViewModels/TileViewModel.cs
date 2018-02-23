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
        
        public SolidColorBrush BorderColor
        {
            get { return _tile.BorderColor; }
            set
            {
                _tile.BorderColor = value;
                OnPropertyChanged();
            }
        }

        ICommand _changeFill;
        public ICommand ChangeFill
        {
            get { return _changeFill ?? (_changeFill = new Command(p => true, a => Change(a))); }
        }

        void Change(object tile)
        {
            FillColor = new SolidColorBrush(Colors.Red);
        }

        /// <summary>
        /// Notifies listeners of property change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
