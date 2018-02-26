using Battleship.Models;

namespace Battleship.Services
{
    public interface IBoardService
    {
        /// <summary>
        /// Performs the initial board setup.
        /// </summary>
        /// <param name="board">The board.</param>
        void PerformInitialBoardSetup(Board board);
    }
}
