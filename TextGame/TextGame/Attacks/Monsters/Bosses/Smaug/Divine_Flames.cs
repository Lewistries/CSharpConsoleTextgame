using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Bosses.Smaug
{
    class Divine_Flames : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }
        public Divine_Flames()
        {
            Name = "Divine Flames";
            Damage = 15;
            Accuracy = 1;
            TargetsHit = 4;
            CritChance = .05;

        }
    }
}

