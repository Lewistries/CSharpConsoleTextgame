using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Healer
{
    class Life_Drain : Attack
    {

        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }

        public Life_Drain()
        {
            Name = "Life Drain";
            Damage = 3;
            Accuracy = 1;
            TargetsHit = 1;
            CritChance = .2;
        }
    }
}
