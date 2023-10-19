using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Base.Vandal
{
    class Precise_Shot : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }


        public Precise_Shot()
        {
            Name = "Precise Shot";
            Damage = 7;
            Accuracy = .95;
            TargetsHit = 1;
            CritChance = .5;
        }
    }
}
