using System.Collections.Generic;

namespace Battleship.Models
{
    public class Board
    {
        bool _isHumanBoard;
        public bool IsHumanBoard
        {
            get { return _isHumanBoard; }
            set { _isHumanBoard = value; }
        }

        public List<Tile> Tiles = new List<Tile>();

        public Tile TileAt(int row, int column)
        {
            return Tiles.Find(tile => tile.Column == column && tile.Row == row);
        }
    }
}
