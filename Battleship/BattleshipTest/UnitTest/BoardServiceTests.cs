using Battleship.Models;
using Battleship.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipTest
{
    [TestClass]
    public class BoardServiceTests
    {
        [TestMethod]
        public void TestAddingShips()
        {
            BoardService boardService = new BoardService();
            Ship destroyer = new Ship(ShipType.DESTROYER);
            Board board = new Board();

            boardService.PerformInitialBoardSetup(board);

            destroyer.IsHorizontal = true;
            destroyer.RootTile = new Tile
            {
                Row = 2,
                Column = 2
            };

            boardService.PlaceShip(board, destroyer);

            Assert.IsTrue(board.tileAt(2, 2).ContainsShip);
            Assert.IsTrue(board.tileAt(2, 3).ContainsShip);
            Assert.IsFalse(board.tileAt(2, 4).ContainsShip);
            Assert.IsFalse(board.tileAt(2, 1).ContainsShip);
            Assert.IsFalse(board.tileAt(1, 2).ContainsShip);
            Assert.IsFalse(board.tileAt(3, 2).ContainsShip);
        }

        [TestMethod]
        public void TestShipWillIntersect()
        {
            BoardService boardService = new BoardService();
            Ship destroyer = new Ship(ShipType.DESTROYER);
            Board board = new Board();

            boardService.PerformInitialBoardSetup(board);

            destroyer.IsHorizontal = true;
            destroyer.RootTile = new Tile
            {
                Row = 2,
                Column = 2
            };

            boardService.PlaceShip(board, destroyer);

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

            Assert.IsTrue(boardService.ShipWillIntersect(board, destroyer2));

            Assert.IsTrue(boardService.ShipWillIntersect(board, destroyer3));

            Assert.IsFalse(boardService.ShipWillIntersect(board, destroyer4));
        }
    }
}
