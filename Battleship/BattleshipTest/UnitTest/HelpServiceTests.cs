using Battleship.Models;
using Battleship.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipTest
{
    [TestClass]
    public class HelpServiceTests
    {
        HelpService _helpService;
        Instruction _instructionModel;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _helpService = new HelpService();
            _instructionModel = new Instruction();
        }
        
        [TestMethod]
        public void TestGetInstructions()
        {
            Assert.IsNull(_instructionModel.Instructions);
            _helpService.GetInstructions(_instructionModel);
            Assert.IsNotNull(_instructionModel.Instructions);
            Assert.AreNotEqual(_instructionModel.Instructions, string.Empty);
            Assert.IsInstanceOfType(_instructionModel.Instructions, typeof(string));
        }
    }
}
