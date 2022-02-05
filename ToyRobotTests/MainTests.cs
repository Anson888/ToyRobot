using NUnit.Framework;
using ToyRobot.InstructionModels;

namespace ToyRobotTests
{
    public class MainTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestValidPlacementCreation()
        {
            var placementResult = ToyRobot.Program.ParseInput("place 0,0,north");
            Assert.AreEqual(placementResult.IsValidPlace(), true);
            Assert.AreEqual(placementResult, new Instruction
            {
                Direction = "north",
                X = 0,
                Y = 0,
                InstructionType = "place"
            }
            );
        }

        [Test]
        public void TestInvalidPlacementCreation_WrongInput()
        {
            var placementResult = ToyRobot.Program.ParseInput("place a");
            Assert.AreEqual(placementResult, null);
        }

        [Test]
        public void TestInvalidPlacementCreation_OutOfBounds()
        {
            var placementResult = ToyRobot.Program.ParseInput("place 6,10");
            Assert.AreEqual(placementResult.IsValidPlace(), false);
        }

        [Test]
        public void TestValidOtherInstructionCreation()
        {
            var placementResult = ToyRobot.Program.ParseInput("move");
            Assert.AreEqual(placementResult, new Instruction
            {
                Direction = null,
                X = -1,
                Y = -1,
                InstructionType = "move"
            }
            );
        }

        [Test]
        public void TestInvalidOtherInstructionCreation()
        {
            var placementResult = ToyRobot.Program.ParseInput("repot");
            Assert.AreEqual(placementResult.isValidType(), false);
        }
    }
}