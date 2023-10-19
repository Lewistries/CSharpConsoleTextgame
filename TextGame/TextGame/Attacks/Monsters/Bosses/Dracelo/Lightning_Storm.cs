using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Bosses.Dracelo
{
    class Lightning_Storm : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }
        public Lightning_Storm()
        {
            Name = "Lightning Storm";
            Damage = 15;
            Accuracy = 1;
            TargetsHit = 4;
            CritChance = .4;

        }
    }
}
