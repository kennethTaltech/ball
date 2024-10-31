using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exc1
{
    public class NormalBall : Ball
    {
        public NormalBall(string sponsor) : base(sponsor) // Corrected constructor syntax
        {
        }
        protected override float Diameter => 0.70f;
        protected override float GoalDepth => 1.7f;
        protected override float Mass => 0.45f;

        public override string GenerateUniqueCode() =>
            $"{Sponsor[..Math.Min(4, Sponsor.Length)].ToUpper()}{Random.Shared.Next(10000, 99999)}";
    }
}
