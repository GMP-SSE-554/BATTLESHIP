using Battleship.Models;

namespace Battleship.Services
{
    public interface IHelpService
    {
        /// <summary>
        /// Gets the instructions on how to play the game.
        /// </summary>
        /// <param name="instruction">The instruction model.</param>
        void GetInstructions(Instruction instruction);
    }
}
