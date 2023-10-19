using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Archer
{
    class Arrow_Shot : Attack
    {

        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }

        public Arrow_Shot()
        {
            Name = "Arrow Shot";
            Damage = 7;
            Accuracy = .85;
            TargetsHit = 1;
            CritChance = .3;
        }
    }
}
