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
                var allDirections = (Direction[]) Enum.GetValues(typeof(Direction));
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
            var roverController = new RoverController(rover);

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
            var roverController = new RoverController(rover);

            // When
            roverController.Execute(command);

            // Then
            Assert.AreEqual(expectedX, rover.X);
            Assert.AreEqual(expectedY, rover.Y);
        }
    }
}