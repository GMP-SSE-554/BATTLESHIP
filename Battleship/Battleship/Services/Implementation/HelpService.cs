using Battleship.Models;

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
                instructions += "The game is played as explained in the following steps:\n";
                instructions += "1. Place your ships in the order they appear on the scoreboard " +
                    "from top to bottom.\n";
                instructions += "\ta. Right click to change the orientation of the ship.\n";
                instructions += "\tb. Left click to place the ship's root tile in specified tile.\n";
                instructions += "\tc. Currently, once a ship is placed, it can not be replaced.\n";
                instructions += "2. After all ships are placed, select tiles to try to sink the " +
                    "opponent's ships before the opponent sinks all of your ships.\n";
                instructions += "3. Once all ships for one player have been destoryed, the other " +
                    "player wins the game.\n\n";

                instructions += "Notes on tile colors:\n";
                instructions += "1. All tiles are initially filled in with Floral White and outlined " +
                    "with Slate Gray.\n";
                instructions += "2. Tiles containing player ships that have NOT been hit by the " +
                    "opponent are filled in with COLOR.\n";
                instructions += "3. Tiles containing player ships that have been hit by the " +
                    "opponent are filled in with COLOR.\n";
                instructions += "4. Tiles selected by the player that do NOT contain enemy ships " +
                    "are outlined with COLOR.\n";
                instructions += "5. Tiles selected by the player that do contain enemy ships are " +
                    "outlined with COLOR.";

                instruction.Instructions = instructions;
            }
        }
    }
}
