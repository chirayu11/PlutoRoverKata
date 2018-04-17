using NUnit.Framework;
using Rover;

namespace Rover.Tests
{
    public class RoverTests
    {
        [TestCase(Direction.North)]
        [TestCase(Direction.East)]
        [TestCase(Direction.South)]
        [TestCase(Direction.West)]
        public void MoveForward_DoesNotChangeDirection(Direction expected)
        {
            // Given
            var roverController = new RoverController(expected);

            // When
            roverController.Execute("F");

            // Then
            Assert.AreEqual(expected, roverController.GetDirection());
        }
    }
}