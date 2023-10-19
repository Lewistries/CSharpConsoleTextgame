using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Base.Dragon
{
    class Consume : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }


        public Consume()
        {
            Name = "Consumption";
            Damage = 25;
            Accuracy = 1;
            TargetsHit = 1;
            CritChance = .1;
            Friendly_Hit = true;
        }
    }
}
