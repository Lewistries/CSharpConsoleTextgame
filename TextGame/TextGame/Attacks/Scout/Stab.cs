using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Scout
{
    class Stab : Attack
    {



        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }
        public Stab()
        {
            Name = "Stab";
            Damage = 6;
            Accuracy = 1;
            TargetsHit = 1;
            CritChance = .4;
        }



    }
}
