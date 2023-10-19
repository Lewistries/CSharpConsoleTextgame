using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Knight
{
    class Sweep : Attack
    {


        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }

        public Sweep()
        {
            Name = "Sweep";
            Damage = 2;
            Accuracy = 1;
            TargetsHit = 2;
            CritChance = .1;
        }





        public override bool Perform()
        {
            return base.Perform();
        }


    }
}
