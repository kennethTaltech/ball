using System;
using System.Linq;

namespace Exc1
{
    public class YouthBall : Ball
    {
        public YouthBall(string sponsor) : base(sponsor) // Corrected constructor syntax
        {
        }

        protected override float Diameter => 0.56f;
        protected override float GoalDepth => 1.4f;
        protected override float Mass => 0.38f;

        public override string GenerateUniqueCode() =>
            $"{Sponsor[..Math.Min(3, Sponsor.Length)].ToUpper()}{Random.Shared.Next(100, 999)}";
    }
}