using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services.Implementation
{
    class ComputerService
    {
        /// <summary>
        /// checks if top left tile in tile line is avaible to attack
        /// </summary>
        /// <param name="tile">The tile checked.</param>
        bool IsTopLeftTileAvaible(Tile tile)
        {
            return false;
        }

        /// <summary>
        /// checks if bottom right tile in tile line is avaible to attack
        /// </summary>
        /// <param name="tile">The tile checked.</param>
        bool IsBottomRightTileAvaible(Tile tile)
        {
            return false;
        }

        /// <summary>
        /// Checks if computer player knows anything
        /// </summary>
        /// <param name="computer">The computer player.</param>
        bool IsUninformed(ComputerPlayer computer)
        {
            return false;
        }

        /// <summary>
        /// Checks if computer has only made a first hit
        /// </summary>
        /// <param name="computer">The computer player.</param>
        bool IsFirstHit(ComputerPlayer computer)
        {
            return false;
        }
    }
}
