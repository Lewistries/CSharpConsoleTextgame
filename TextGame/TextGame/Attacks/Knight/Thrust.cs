using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Knight
{
    class Thrust : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }

        public Thrust()
        {
            Name = "Stab";
            Damage = 4;
            Accuracy = .8;
            TargetsHit = 1;
            CritChance = .2;
        }
    }
}
