
namespace Battleship.Models
{
    public class Ship
    {
        Tile _rootTile;
        public Tile RootTile
        {
            get { return _rootTile; }
            set { _rootTile = value; }
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

        bool _isDestroyed;
        public bool IsDestroyed
        {
            get { return _isDestroyed; }
            set { _isDestroyed = value; }
        }
    }
}
