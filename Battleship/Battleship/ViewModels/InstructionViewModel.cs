using Battleship.Models;
using Battleship.Services;

namespace Battleship.ViewModels
{
    public class InstructionViewModel
    {
        Instruction _instructions;
        IHelpService _helpService;

        public InstructionViewModel(IHelpService helpService)
        {
            _instructions = new Instruction();
            _helpService = helpService;
            _helpService.GetInstructions(_instructions);
        }

        public string Instructions
        {
            get { return _instructions.Instructions; }
        }
    }
}
