using System;
using System.Linq;

namespace Exc1
{
    class Program
    {
        static void Main()
        {
            var normalBall = new NormalBall("Adidas");
            var youthBall = new YouthBall("Nike");

            // Generate random x-coordinates for the balls (20 positions each)
            var normalBallPositions = GenerateRandomCoordinates(20);
            var youthBallPositions = GenerateRandomCoordinates(20);
            // Test goal scoring for both balls using generated positions
            TestGoals(normalBall, normalBallPositions);
            TestGoals(youthBall, youthBallPositions);

            // Testing goal counting with some invalid values for both balls
            Console.WriteLine("\nTesting invalid goal positions");
            float[] invalidPositions = { -50, 50, -46, 46 }; // Invalid goal positions

            // Count goals with invalid positions for the NormalBall
            var normalBallInvalidGoals = normalBall.CountGoals(invalidPositions);

            // Count goals with invalid positions for the YouthBall
            var youthBallInvalidGoals = youthBall.CountGoals(invalidPositions);
            Console.WriteLine("No errors");

            Console.WriteLine("\nAverage speed calculations:");
            // Test 10 average speed calculations for the normal ball
            TestAverageSpeeds(normalBall, 10);

            Console.WriteLine("\nAverage speed calculations for Youth Ball:");
            // Test 10 average speed calculations for the youth ball
            TestAverageSpeeds(youthBall, 10);

            Console.WriteLine("\nKinetic energy calculations for Normal Ball:");
            // Test kinetic energy for velocities from 1 to 5
            TestKineticEnergy(normalBall, 1..6);

            Console.WriteLine("\nKinetic energy calculations for Youth Ball:");
            // Test kinetic energy for velocities from 1 to 5
            TestKineticEnergy(youthBall, 1..6);

            // Generate and display unique codes for both balls
            Console.WriteLine($"\nUnique codes:\nNormal: {normalBall.GenerateUniqueCode()}\nYouth: {youthBall.GenerateUniqueCode()}");
        }

        // Method to generate an array of random coordinates within the range of -45 to 45
        static float[] GenerateRandomCoordinates(int count) =>
            Enumerable.Range(0, count).Select(_ => (Random.Shared.NextSingle() * 90 - 45)).ToArray();

        // Method to test whether the ball scored goals based on the given positions
        static void TestGoals(Ball ball, float[] positions)
        {
            // Count goals using the ball's CountGoals method
            var goals = ball.CountGoals(positions);
            // Print the number of goals and no-goals
            Console.WriteLine($"{ball.GetType().Name}: Goals: {goals}, No Goals: {positions.Length - goals}");
        }

        // Method to test average speed calculations for a ball
        static void TestAverageSpeeds(Ball ball, int count) =>
            // Generate specified number of random start and end positions and time intervals
            Enumerable.Range(0, count).ToList().ForEach(_ =>
            {
                var (start, end, time) = (
                Random.Shared.NextSingle() * 90 - 45, // Random start position
                Random.Shared.NextSingle() * 90 - 45 , // Random end position
                Random.Shared.NextSingle() * 5 + 1); // Random time (1 to 6 seconds)

                // Calculate average speed and print the results
                Console.WriteLine($"From {Math.Round(start, 2)} to {Math.Round(end, 2)} in {Math.Round(time, 2)} sec: {Math.Round(ball.CalculateAverageSpeed(start, end, time), 2)} m/s");
            });

        // Method to test kinetic energy calculations for a ball given a range of velocities
        static void TestKineticEnergy(Ball ball, Range velocities) =>
        // Generate kinetic energy calculations for velocities in the specified range 
            Enumerable.Range(velocities.Start.Value, velocities.End.Value - velocities.Start.Value)
                   .ToList()
                   .ForEach(v => ball.PrintKineticEnergy(v)); // Print kinetic energy for each velocity

    }
}