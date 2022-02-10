using System;
using System.Collections;
using System.Collections.Generic;
using ToyRobot.InstructionModels;

namespace ToyRobot
{
    public class Program
    {
        public static List<string> Directions = new List<string> { "north", "south", "east", "west" };
        static void Main(string[] args)
        {
            StartMovement();
        }

        static void StartMovement()
        {
            Robot robot = new Robot(0, 0);
            Console.WriteLine("Please enter lines of instructions to move the toy robot:");
            bool validPlacementMade = false;
            while (!validPlacementMade) //keep waiting for input until 
            {
                var input = Console.ReadLine();
                var instruction = ParseInput(input);
                //first command must be a valid place and must include a valid direction
                if (instruction != null && (instruction.IsValidPlace() && Directions.Contains(instruction.Direction)))
                {
                    robot.Instructions.Enqueue(instruction);
                    validPlacementMade = true;
                }
                else
                {
                    Console.WriteLine("The first command must be a valid PLACE command. For example PLACE 0,0,NORTH");
                }
            }
            bool reportCommandMade = false;
            while (!reportCommandMade)
            {
                var input = Console.ReadLine();
                var instruction = ParseInput(input);
                if (instruction != null && instruction.isValidType())
                {
                    robot.Instructions.Enqueue(instruction);
                    if (instruction.InstructionType == "report")
                    {
                        reportCommandMade = true;
                    }
                }
            }
            robot.ExecuteAllInstructions();
            StartMovement();
        }

        public static Instruction ParseInput(string input)
        {
            try
            {
                string commandType = input.Substring(0, input.IndexOf(" ") > 0 ? input.IndexOf(" ") : input.Length).ToLower();
                input = input.Remove(0, commandType.Length);
                var parsedInput = input.Trim().ToLower().Split(',');
                if (commandType == "place" && parsedInput.Length > 0)
                {
                    int x = 0;
                    int y = 0;
                    string direction = "";
                    if (parsedInput.Length > 0)
                    {
                        x = int.Parse(parsedInput[0]);
                        y = int.Parse(parsedInput[1]);
                    }
                    if (parsedInput.Length > 2)
                        direction = parsedInput[2];
                    return new Instruction
                    {
                        InstructionType = commandType,
                        X = x,
                        Y = y,
                        Direction = direction
                    };
                }
                else
                {
                    return new Instruction
                    {
                        InstructionType = commandType,
                    };
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}
