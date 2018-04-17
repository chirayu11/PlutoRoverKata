using NUnit.Framework;
using Rover;

namespace Rover.Tests
{
    public class RoverTests
    {
        [TestCase(Direction.North, "F")]
        [TestCase(Direction.East, "F")]
        [TestCase(Direction.South, "F")]
        [TestCase(Direction.West, "F")]

        [TestCase(Direction.North, "B")]
        [TestCase(Direction.East, "B")]
        [TestCase(Direction.South, "B")]
        [TestCase(Direction.West, "B")]
        public void MoveForwardBackward_DoesNotChangeDirection(Direction expected, string command)
        {
            // Given
            var roverController = new RoverController(expected);

            // When
            roverController.Execute(command);

            // Then
            Assert.AreEqual(expected, roverController.GetDirection());
        }
    }
}