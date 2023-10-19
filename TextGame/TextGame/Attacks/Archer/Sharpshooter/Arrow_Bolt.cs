using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Archer.Sharpshooter
{
    class Arrow_Bolt : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }

        public Arrow_Bolt()
        {
            Name = "Arrow Bolt";
            Damage = 10;
            Accuracy = .9;
            TargetsHit = 1;
            CritChance = .45;
        }
    }
}
