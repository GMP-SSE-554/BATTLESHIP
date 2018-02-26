using Battleship.Services;
using Battleship.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddingShips()
        {
            BoardService boardService = new BoardService();
            TileService tileService = new TileService();
            Ship destroyer = new Ship(ShipType.DESTROYER);
            Board board = new Board();

            boardService.PerformInitialBoardSetup(board);

            destroyer.IsHorizontal = true;
            destroyer.RootTile = new Tile
            {
                Row = 2,
                Column = 2
            };

            tileService.PlaceShip(board, destroyer);

            Assert.IsTrue(board.TileAt(2, 2).ContainsShip);
            Assert.IsTrue(board.TileAt(2, 3).ContainsShip);
            Assert.IsFalse(board.TileAt(2, 4).ContainsShip);
            Assert.IsFalse(board.TileAt(2, 1).ContainsShip);
            Assert.IsFalse(board.TileAt(1, 2).ContainsShip);
            Assert.IsFalse(board.TileAt(3, 2).ContainsShip);
        }

        [TestMethod]
        public void TestShipWillIntersect()
        {
            BoardService boardService = new BoardService();
            TileService tileService = new TileService();
            Ship destroyer = new Ship(ShipType.DESTROYER);
            Board board = new Board();

            boardService.PerformInitialBoardSetup(board);

            destroyer.IsHorizontal = true;
            destroyer.RootTile = new Tile
            {
                Row = 2,
                Column = 2
            };

            tileService.PlaceShip(board, destroyer);

            Ship destroyer2 = new Ship(ShipType.DESTROYER)
            {
                RootTile = new Tile { Row = 1, Column = 2 }
            };

            Ship destroyer3 = new Ship(ShipType.DESTROYER)
            {
                RootTile = new Tile { Row = 2, Column = 3 }
            };

            Ship destroyer4 = new Ship(ShipType.DESTROYER)
            {
                RootTile = new Tile { Row = 5, Column = 5 }
            };

            Assert.IsTrue(tileService.ShipWillIntersect(board, destroyer2));

            Assert.IsTrue(tileService.ShipWillIntersect(board, destroyer3));

            Assert.IsFalse(tileService.ShipWillIntersect(board, destroyer4));
        }
    }
}
