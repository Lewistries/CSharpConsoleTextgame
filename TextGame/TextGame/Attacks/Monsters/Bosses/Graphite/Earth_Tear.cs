using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Bosses.Graphite
{
    class Earth_Tear : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }
        public Earth_Tear()
        {
            Name = "Earth Tear";
            Damage = 15;
            Accuracy = 1;
            TargetsHit = 4;
            CritChance = .15;

        }
    }
}
