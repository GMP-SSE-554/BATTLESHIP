using Windows.UI.Xaml.Media;

namespace Battleship.Models
{
    public class Tile
    {
        int _row;
        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        int _column;
        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        bool _containsShip;
        public bool ContainsShip
        {
            get { return _containsShip; }
            set { _containsShip = value; }
        }

        bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }

        Windows.UI.Color _fillColor;
        public Windows.UI.Color FillColor
        {
            get { return _fillColor; }
            set { _fillColor = value; }
        }

        Windows.UI.Color _borderColor;
        public Windows.UI.Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }
    }
}
