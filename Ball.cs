using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exc1
{
    public abstract class Ball : IBall
    {
        protected string Sponsor { get; }

        protected Ball(string sponsor) 
        {
            Sponsor = sponsor;
        }

        protected abstract float Diameter { get; }
        protected abstract float GoalDepth { get; }
        protected abstract float Mass { get; }

        // All of these methods should be pretty self-explanatory
        public float CalculateAverageSpeed(float start, float end, float time) => Math.Abs(end - start) / time;
        // Note: it would be impractical to make a separate function, for checking whether the value is inbetween -45 and 45, as that would total in more lines of code, which would be unnecessary
        public bool IsGoal(float pos) => 
            (Math.Abs(pos - Diameter / 2) >= 45 - GoalDepth) && 
            pos >= -45 && pos <= 45;
        public int CountGoals(float[] pos) => pos.Count(IsGoal);
        public void PrintKineticEnergy(float velocity) => Console.WriteLine($"v={velocity} m/s: {Math.Round((Mass * velocity * velocity) / 2, 2)} J");

        public abstract string GenerateUniqueCode();
    }
}
