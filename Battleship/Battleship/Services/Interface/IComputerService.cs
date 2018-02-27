using Battleship.Models;

namespace Battleship.Services
{
    public interface IComputerService
    {
        /// <summary>
        /// checks if top left tile in tile line is avaible to attack
        /// </summary>
        /// <param name="tile">The tile checked.</param>
        bool IsTopLeftTileAvaible(Tile tile);

        /// <summary>
        /// checks if bottom right tile in tile line is avaible to attack
        /// </summary>
        /// <param name="tile">The tile checked.</param>
        bool IsBottomRightTileAvaible(Tile tile);

        /// <summary>
        /// Checks if computer player knows anything
        /// </summary>
        /// <param name="computer">The computer player.</param>
        bool IsUninformed(ComputerPlayer computer);

        /// <summary>
        /// Checks if computer has only made a first hit
        /// </summary>
        /// <param name="computer">The computer player.</param>
        bool IsFirstHit(ComputerPlayer computer);
    }
}