using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Base.Vandal
{
    class Melee : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }


        public Melee()
        {
            Name = "Melee";
            Damage = 4;
            Accuracy = .9;
            TargetsHit = 1;
            CritChance = .1;
        }
    }
}
