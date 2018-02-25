using System.Collections.Generic;

namespace Battleship.Models
{
    public class Board
    {
        int _numRows;
        public int NumRows
        {
            get { return _numRows; }
            set { _numRows = value; }
        }

        int _numColumns;
        public int NumColumns
        {
            get { return _numColumns; }
            set { _numColumns = value; }
        }

        public List<Tile> Tiles = new List<Tile>();

        public Tile tileAt(int row, int column)
        {
            return Tiles.Find(tile => tile.Column == column && tile.Row == row);
        }
    }
}
