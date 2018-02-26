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

        /// <summary>
        /// Adds the player ships.
        /// </summary>
        /// <param name="player">The player.</param>
        void AddPlayerShips(Player player);
    }
}
