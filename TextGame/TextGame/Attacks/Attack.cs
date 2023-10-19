using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Attacks
{
    abstract class Attack : IAttack
    {


        public abstract string Name { get; }

        public abstract int Damage { get; }

        public abstract double Accuracy { get; }

        public abstract int TargetsHit { get; }

        public abstract double CritChance { get; }

        public bool Friendly_Hit { get; set; } = false;


        public virtual bool Perform()
        {
            if(new Random().NextDouble() < Accuracy)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
