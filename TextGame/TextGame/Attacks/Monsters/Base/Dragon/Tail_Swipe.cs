using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Base.Dragon
{
    class Tail_Swipe : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }


        public Tail_Swipe()
        {
            Name = "Tail Swipe";
            Damage = 7;
            Accuracy = .8;
            TargetsHit = 2;
            CritChance = .1;
        }
    }
}
