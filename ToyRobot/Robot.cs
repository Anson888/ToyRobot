using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.InstructionModels;

namespace ToyRobot
{
    public class Robot
    {
        private int X { get; set; }
        private int Y { get; set; }
        public string Direction { get; set; }

        public Queue<Instruction> Instructions { get; set; } = new Queue<Instruction>();
        public Robot(int x, int y, string direction = "")
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int GetDirectionAsDegrees()
        {
            return (int)Enum.Parse(typeof(DirectionDegreeEnum), Direction);
        }

        public void SetDirectionFromDegrees(int degrees)
        {
            var newDirection = (DirectionDegreeEnum)degrees;
            Direction = newDirection.ToString();
        }

        public void ExecuteAllInstructions()
        {
            while (Instructions.Count > 0)
            {
                var instruction = Instructions.Dequeue();
                switch (instruction.InstructionType)
                {
                    case "place":
                        Place(instruction);
                        break;
                    case "left":
                        Left(instruction);
                        break;
                    case "right":
                        Right(instruction);
                        break;
                    case "move":
                        Move(instruction);
                        break;
                    case "report":
                        Report(instruction);
                        break;
                }
            }
        }

        public void Place(Instruction place)
        {
            if (place.IsValidPlace())
            {
                X = place.X;
                Y = place.Y;
                if (!string.IsNullOrEmpty(place.Direction))
                {
                    Direction = place.Direction;
                }
            }
        }

        public void Left(Instruction left)
        {
            int currentOrientation = GetDirectionAsDegrees();
            int newOrientation = currentOrientation - 90;
            if (newOrientation < 0)
            {
                SetDirectionFromDegrees(270);
            }
            else
            {
                SetDirectionFromDegrees(newOrientation);
            }
        }

        public void Right(Instruction right)
        {
            int currentOrientation = GetDirectionAsDegrees();
            int newOrientation = currentOrientation + 90;
            if (newOrientation > 270)
            {
                SetDirectionFromDegrees(0);
            }
            else
            {
                SetDirectionFromDegrees(newOrientation);
            }
        }

        public void Move(Instruction move)
        {
            switch (Direction)
            {
                case "north":
                    if (Y + 1 <= 5)
                        Y++;
                    break;
                case "south":
                    if (Y - 1 >= 0)
                        Y--;
                    break;
                case "east":
                    if (X + 1 <= 5)
                        X++;
                    break;
                case "west":
                    if (X - 1 >= 0)
                        X--;
                    break;
            }
        }

        public void Report(Instruction report)
        {
            Console.WriteLine("Output: {0},{1},{2}", X, Y, Direction.ToUpper());
        }

        public override bool Equals(object obj)
        {
            var comparison = obj as Robot;
            if (comparison.X == X && comparison.Y == Y && comparison.Direction == Direction)
                return true;
            else
                return false;
        }
    }
}
