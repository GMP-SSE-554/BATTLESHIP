using Windows.UI;

namespace Battleship.Models
{
    public class Tile
    {
        int _row;
        public int Row
        {
            get { return _row; }
            set
            {
                _row = value;
            }
        }

        int _column;
        public int Column
        {
            get { return _column; }
            set
            {
                _column = value;
            }
        }

        bool _containsShip;
        public bool ContainsShip
        {
            get { return _containsShip; }
            set
            {
                _containsShip = value;
            }
        }

        bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
            }
        }

        Color _color;
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
            }
        }
    }
}
