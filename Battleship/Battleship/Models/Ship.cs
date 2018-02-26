
using System;
using Windows.UI.Xaml.Media;

namespace Battleship.Models
{
    public class Ship
    {
        public Ship(ShipType shipType)
        {
            this.Name = Enum.GetName(typeof(ShipType), (int)shipType);
            this.Length = (int)shipType;
        }

        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        Tile _rootTile;
        public Tile RootTile
        {
            get { return _rootTile; }
            set { _rootTile = value; }
        }

        int _row;
        public int Row
        {
            get { return _rootTile.Row; }
        }

        int _column;
        public int Column
        {
            get { return _rootTile.Column; }
        }

        int _length;
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        bool _isHorizontal;
        public bool IsHorizontal
        {
            get { return _isHorizontal; }
            set { _isHorizontal = value; }
        }

        int _remainingHealth;
        public int RemainingHealth
        {
            get { return _remainingHealth; }
            set { _remainingHealth = value; }
        }

        bool _isDestroyed;
        public bool IsDestroyed
        {
            get { return _isDestroyed; }
            set { _isDestroyed = value; }
        }

        SolidColorBrush _color;
        public SolidColorBrush Color
        {
            get { return _color; }
            set { _color = value; }
        }
    }
}
