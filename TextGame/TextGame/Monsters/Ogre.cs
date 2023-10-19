using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TextGame
{
    internal class Ogre : Monster
    {
        public override string Name { get; }
        public override MonsterClass Class { get; }
        public override int MaxHealth { get; set; }
        public override double CurrentHealth { get; set; }
        public override bool Living { get; set; }

        public override int MaxATK { get; set; }

        public override bool IsBoss { get; }

        public override double BaseCrit { get; }

        public override int XPWorth { get; }

        public override int Priority { get; set; }

        public override double Defense { get; }

        public override List<Attacks.Attack> Attacks { get; set; }

        private readonly IList<string> Ogre_bosses = ConfigurationManager.AppSettings.Get("OgreBosses").Split(',');

        public Ogre(bool boss)
        {
            Class = MonsterClass.Ogre;
            Living = true;
            IsBoss = boss;
            Priority = 7;
            Defense = 1;
            
            switch (boss)
            {
                case true:
                    Name = "Hallowed Ogre";
                    MaxHealth = 25;
                    CurrentHealth = MaxHealth;
                    BaseCrit = 1;
                    XPWorth = 15;
                    Defense = .8;
                    Attacks = new List<Attacks.Attack> {
                new Attacks.Monsters.Base.Ogre.Eye_Beam(1),
                new Attacks.Monsters.Base.Ogre.Ground_Slam(1)
            };

                    break;
                case false:
                    Name = "Ogre";
                    MaxHealth = 15;
                    CurrentHealth = MaxHealth;
                    BaseCrit = 1;
                    MaxATK = 15;
                    XPWorth = 8;
                    Attacks = new List<Attacks.Attack> {
                new Attacks.Monsters.Base.Ogre.Eye_Beam(),
                new Attacks.Monsters.Base.Ogre.Ground_Slam()
            };

                    break;
            }
        }
    }
}
