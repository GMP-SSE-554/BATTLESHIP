using Battleship.Models;
using System.IO;

namespace Battleship.Services
{
    public class HelpService : IHelpService
    {
        /// <summary>
        /// Gets the instructions on how to play the game.
        /// </summary>
        /// <param name="instruction">The instruction model.</param>
        public void GetInstructions(Instruction instruction)
        {
            string instructions = string.Empty;

            if (instruction != null)
            {
                foreach (var line in File.ReadAllLines("Assets/HelpMessage.txt"))
                {
                    instructions += $"{line}\n";
                }

                instruction.Instructions = instructions;
            }
        }
    }
}
