using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Base.Goblin
{
    class Bloody_Club : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }


        public Bloody_Club()
        {
            Name = "Bloody Club";
            Damage = 5;
            Accuracy = .6;
            TargetsHit = 1;
            CritChance = .1;
        }
    }
}
