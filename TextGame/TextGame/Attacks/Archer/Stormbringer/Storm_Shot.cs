using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Archer.Stormbringer
{
    class Storm_Shot : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }

        public Storm_Shot()
        {
            Name = "Storm Shot";
            Damage = 4;
            Accuracy = .85;
            TargetsHit = 3;
            CritChance = .4;
        }
    }
}
