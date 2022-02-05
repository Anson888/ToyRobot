using NUnit.Framework;
using ToyRobot;
using ToyRobot.InstructionModels;

namespace ToyRobotTests
{
    class RobotTests
    {
        public Robot robot;

        [SetUp]
        public void Setup()
        {
            robot = new Robot(0, 0, "north");
        }

        [Test]
        public void TestPlace()
        {
            var instruction = new Instruction
            {
                X = 1,
                Y = 1,
                Direction = "south",
                InstructionType = "place"
            };
            robot.Instructions.Enqueue(instruction);
            robot.ExecuteAllInstructions();
            Assert.AreEqual(robot, new Robot(1, 1, "south"));
        }

        [Test]
        public void TestInvalidPlace()
        {
            var instruction = new Instruction
            {
                X = 6,
                Y = 6,
                Direction = "south",
                InstructionType = "place"
            };
            robot.Instructions.Enqueue(instruction);
            robot.ExecuteAllInstructions();
            Assert.AreEqual(robot, new Robot(0, 0, "north"));
        }
        [Test]
        public void TestLeftChangeOrientation()
        {
            var instruction = new Instruction
            {
                X = -1,
                Y = -1,
                Direction = null,
                InstructionType = "left"
            };
            robot.Instructions.Enqueue(instruction);
            robot.ExecuteAllInstructions();
            Assert.AreEqual(robot, new Robot(0, 0, "west"));
        }

        [Test]
        public void TestRightChangeOrientation()
        {
            var instruction = new Instruction
            {
                X = -1,
                Y = -1,
                Direction = null,
                InstructionType = "right"
            };
            robot.Instructions.Enqueue(instruction);
            robot.ExecuteAllInstructions();
            Assert.AreEqual(robot, new Robot(0, 0, "east"));
        }

        [Test]
        public void TestValidMove()
        {
            var instruction = new Instruction
            {
                X = -1,
                Y = -1,
                Direction = null,
                InstructionType = "move"
            };
            robot.Instructions.Enqueue(instruction);
            robot.ExecuteAllInstructions();
            Assert.AreEqual(robot, new Robot(0, 1, "north"));
        }

        [Test]
        public void TestInvalidMove()
        {
            robot = new Robot(5, 5, "north");
            var instruction = new Instruction
            {
                X = -1,
                Y = -1,
                Direction = null,
                InstructionType = "move"
            };
            robot.Instructions.Enqueue(instruction);
            robot.ExecuteAllInstructions();
            Assert.AreEqual(robot, new Robot(5, 5, "north"));
        }
    }
}
