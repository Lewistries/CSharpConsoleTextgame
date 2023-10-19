using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Base.Ogre
{
    class Ground_Slam : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }


        public Ground_Slam()
        {
            Name = "Ground Slam";
            Damage = 5;
            Accuracy = 1;
            TargetsHit = 2;
            CritChance = .2;
        }
        public Ground_Slam(int stage)
        {
            Name = "Ground Slam";
            Damage = stage == 1 ? 8 : 10;
            Accuracy = 1;
            TargetsHit = 2;
            CritChance = .2;
        }
    }
}
