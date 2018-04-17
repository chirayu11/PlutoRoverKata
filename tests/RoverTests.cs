using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rover;

namespace Rover.Tests
{
    public class RoverTests
    {

        public static IEnumerable<TestCaseData> GetAllDirections
        {
            get
            {
                var allDirections = (Direction[])Enum.GetValues(typeof(Direction));
                foreach (var d in allDirections)
                {
                    yield return new TestCaseData(d, "F");
                    yield return new TestCaseData(d, "B");
                }
            }
        }

        [TestCaseSource("GetAllDirections")]
        public void MoveForwardBackward_DoesNotChangeDirection(Direction expected, string command)
        {
            // Given
            var rover = new Rover(0, 0, expected);
            var roverController = new RoverController(rover, new Terrain(10, 10));

            // When
            roverController.Execute(command);

            // Then
            Assert.AreEqual(expected, rover.Direction);
        }

        [TestCase("F", 1, 1, Direction.North, 1, 2)]
        [TestCase("F", 1, 1, Direction.East, 2, 1)]
        [TestCase("F", 1, 1, Direction.South, 1, 0)]
        [TestCase("F", 1, 1, Direction.West, 0, 1)]
        [TestCase("B", 1, 1, Direction.North, 1, 0)]
        [TestCase("B", 1, 1, Direction.East, 0, 1)]
        [TestCase("B", 1, 1, Direction.South, 1, 2)]
        [TestCase("B", 1, 1, Direction.West, 2, 1)]
        public void MoveForwardBackward_MovesOneInTheCorrectDirection(
                    string command, int startX, int startY, Direction facing, int expectedX, int expectedY)
        {
            // Given
            var rover = new Rover(startX, startY, facing);
            var roverController = new RoverController(rover, new Terrain(10, 10));

            // When
            roverController.Execute(command);

            // Then
            Assert.AreEqual(expectedX, rover.X);
            Assert.AreEqual(expectedY, rover.Y);
        }

        [TestCase("L")]
        [TestCase("R")]
        public void TurnLeftOrRight_DoesNotChangeGridPosition(string command)
        {
            // Given
            var expectedX = 0;
            var expectedY = 0;
            var rover = new Rover(expectedX, expectedY, Direction.North);
            var roverController = new RoverController(rover, new Terrain(10, 10));

            // When
            roverController.Execute(command);

            // Then
            Assert.AreEqual(expectedX, rover.X);
            Assert.AreEqual(expectedY, rover.Y);
        }

        [TestCase("L", Direction.North, Direction.West)]
        [TestCase("L", Direction.East, Direction.North)]
        [TestCase("L", Direction.South, Direction.East)]
        [TestCase("L", Direction.West, Direction.South)]
        [TestCase("R", Direction.North, Direction.East)]
        [TestCase("R", Direction.East, Direction.South)]
        [TestCase("R", Direction.South, Direction.West)]
        [TestCase("R", Direction.West, Direction.North)]
        public void TurnLeftOrRight_ChangesDirectionFacingCorrectly(
                        string command, Direction start, Direction expected)
        {
            // Given
            var rover = new Rover(0, 0, start);
            var roverController = new RoverController(rover, new Terrain(10, 10));

            // When
            roverController.Execute(command);

            // Then
            Assert.AreEqual(expected, rover.Direction);
        }

        [TestCase("F", 2, 2, Direction.North, 3, 3, 2, 0)]
        [TestCase("F", 2, 2, Direction.East, 3, 3, 0, 2)]
        [TestCase("F", 2, 0, Direction.South, 3, 3, 2, 2)]
        [TestCase("F", 0, 2, Direction.West, 3, 3, 2, 2)]
        [TestCase("B", 0, 0, Direction.North, 3, 3, 0, 2)]
        [TestCase("B", 0, 2, Direction.East, 3, 3, 2, 2)]
        [TestCase("B", 2, 2, Direction.South, 3, 3, 2, 0)]
        [TestCase("B", 2, 0, Direction.West, 3, 3, 0, 0)]
        public void MoveForwardBackward_WrapsAroundCorrectly(
            string command, int startX, int startY, Direction facing,
            int terrainX, int terrainY, int expectedX, int expectedY)
        {
            // Given
            var rover = new Rover(startX, startY, facing);
            var roverController = new RoverController(rover, new Terrain(terrainX, terrainY));

            // When
            roverController.Execute(command);

            // Then
            Assert.AreEqual(expectedX, rover.X);
            Assert.AreEqual(expectedY, rover.Y);
            Assert.AreEqual(facing, rover.Direction);
        }
    }
}