using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Models;
using Battleship.ViewModels;
using System.Threading.Tasks;

namespace Battleship.Services
{
    public class TileService : ITileService
    {
        public void PlaceShip(Board board, Ship ship)
        {
            int rowOffset = 0;
            int columnOffset = 0;
            for (int i = 0; i < ship.Length; i++)
            {
                board.TileAt(ship.Row + rowOffset, ship.Column + columnOffset).ContainsShip = true;

                if (ship.IsHorizontal) { columnOffset += 1; }
                else { rowOffset += 1; }
            }
        }

        public bool ShipWillIntersect(Board board, Ship ship)
        {
            int rowOffset = 0;
            int columnOffset = 0;
            for (int i = 0; i < ship.Length; i++)
            {
                if (board.TileAt(ship.Row + rowOffset, ship.Column + columnOffset).ContainsShip) return true;

                if (ship.IsHorizontal) { columnOffset += 1; }
                else { rowOffset += 1; }
            }

            return false;
        }

        public void PreviewShip(TileViewModel tileVM)
        {
            Board board = tileVM.Board;
            Ship shipToPreview = tileVM.Board.ShipBeingPlaced;
            int rowOffset = 0;
            int columnOffset = 0;
            ClearOldPreview(tileVM);
            if (shipToPreview != null)
            {
                for (int i = 0; i < shipToPreview.Length; i++)
                {
                    board.TileAt(shipToPreview.RootTile.Row, shipToPreview.RootTile.Column).IsPreviewTile = true;
                    if (shipToPreview.IsHorizontal) columnOffset++;
                    else rowOffset++;
                }
            } else
            {
                tileVM.IsPreviewTile = true;
            }
        }

        private void ClearOldPreview(TileViewModel tileVM)
        {
            foreach(Tile t in tileVM.Board.Tiles)
            {
                //t.IsPreviewTile = false;
            }
        }
    }
}
