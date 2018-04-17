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
            var roverController = new RoverController(expected);

            // When
            roverController.Execute(command);

            // Then
            Assert.AreEqual(expected, roverController.GetDirection());
        }
    }
}