using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Base.Goblin
{
    class Rusty_Stab : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }


        public Rusty_Stab()
        {
            Name = "Rusty Stab";
            Damage = 3;
            Accuracy = .8;
            TargetsHit = 1;
            CritChance = .3;
        }
    }
}
