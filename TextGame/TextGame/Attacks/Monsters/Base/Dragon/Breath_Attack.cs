using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks.Monsters.Base.Dragon
{
    class Breath_Attack : Attack
    {
        public override string Name { get; }

        public override int Damage { get; }

        public override double Accuracy { get; }

        public override int TargetsHit { get; }

        public override double CritChance { get; }
        public Breath_Attack()
        {
            Name = "Dragon's Breath";
            Damage = 7;
            Accuracy = .6;
            TargetsHit = 4;
            CritChance = .05;

        }
    }
}
