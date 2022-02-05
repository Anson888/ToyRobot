using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.InstructionModels
{
    public class Instruction
    {
        private static List<string> Directions = new List<string> { "north", "south", "east", "west" };
        public string InstructionType { get; set; }
        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;
        public string Direction { get; set; }

        public bool isValidType()
        {
            if (InstructionType == "place" || InstructionType == "left" || InstructionType == "right" || InstructionType == "move" || InstructionType == "report")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidPlace()
        {
            if (InstructionType == "place" && X >= 0 && X <= 5
            && Y >= 0 && Y <= 5)
            {
                if (!string.IsNullOrEmpty(Direction))
                {
                    if (Directions.Contains(Direction))
                    {
                        return true;
                    }
                }
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            var comparison = obj as Instruction;
            if (comparison.X == X && comparison.Y == Y && comparison.Direction == Direction && comparison.InstructionType == InstructionType)
                return true;
            else
                return false;
        }
    }
}
