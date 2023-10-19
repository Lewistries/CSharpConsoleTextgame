using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Base.Dragon
{
    class Bite : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }


        public Bite()
        {
            Name = "Bite";
            Damage = 10;
            Accuracy = .8;
            TargetsHit = 1;
            CritChance = .2;
        }

        public Bite(int stage)
        {
            Name = "Bite";
            Damage = stage == 1 ? 15 : stage == 2 ? 20 : 25;
            Accuracy = .8;
            TargetsHit = 1;
            CritChance = .3;
        }
    }
}
