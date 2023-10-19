using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Monsters.Special_Bosses
{
    class Phogoth : Monster
    {
        public override string Name { get; } = "Phogoth the Untamed";

        public override int MaxHealth { get; set; }
        public override double CurrentHealth { get; set; }

        public override MonsterClass Class { get; }

        public override bool IsBoss { get; } = true;

        public override bool Living { get; set; }
        public override int MaxATK { get; set; }

        public override double BaseCrit { get; }

        public override int XPWorth { get; }

        public override int Priority { get; set; }

        public override double Defense { get; }

        public override List<Attacks.Attack> Attacks { get; set; }


        public Phogoth(int characters)
        {
            Class = MonsterClass.Ogre;
            Living = true;
            MaxHealth = 25 * characters;
            CurrentHealth = MaxHealth;
            BaseCrit = 1;
            MaxATK = 35;
            Priority = 10;
            Defense = .8;
            XPWorth = 12;
            Attacks = new List<Attacks.Attack> {
                new Attacks.Monsters.Base.Ogre.Eye_Beam(2),
                new Attacks.Monsters.Base.Ogre.Ground_Slam(2)
            };

        }
    }
}
