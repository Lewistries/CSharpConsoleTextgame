using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Base.Ogre
{
    class Eye_Beam : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }


        public Eye_Beam()
        {
            Name = "Eye Beam";
            Damage = 7;
            Accuracy = .8;
            TargetsHit = 1;
            CritChance = .05;
        }

        public Eye_Beam(int stage)
        {
            Name = "Eye Beam";
            Damage = stage == 1 ? 10 : 15;
            Accuracy = .8;
            TargetsHit = 1;
            CritChance = .05;
        }
    }
}
