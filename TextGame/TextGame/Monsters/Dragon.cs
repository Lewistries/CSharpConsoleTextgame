using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TextGame
{
    internal class Dragon : Monster
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

        public override List<Attacks.Attack> Attacks { get; set; }
        public override double Defense { get; }


        private readonly IList<string> Dragon_bosses = ConfigurationManager.AppSettings.Get("DragonBosses").Split(',');

        public Dragon(bool boss)
        {
            Class = MonsterClass.Dragon;
            Living = true;
            IsBoss = boss;
            Defense = 1;
            switch (boss)
            {
                case true:
                    Name = "Elder Dragon";
                    MaxHealth = 35;
                    CurrentHealth = MaxHealth;
                    BaseCrit = 1;
                    MaxATK = 20;
                    Defense = 1.1;
                    XPWorth = 25;
                    Priority = 8;
                    Attacks = new List<Attacks.Attack> {
                new Attacks.Monsters.Base.Dragon.Bite(1),
                new Attacks.Monsters.Base.Dragon.Breath_Attack(),
                new Attacks.Monsters.Base.Dragon.Tail_Swipe()
            };

                    break;
                case false:
                    Name = "Dragon";
                    MaxHealth = 25;
                    CurrentHealth = MaxHealth;
                    BaseCrit = 1;
                    MaxATK = 20;
                    XPWorth = 15;
                    Priority = 8;
                    Attacks = new List<Attacks.Attack> {
                new Attacks.Monsters.Base.Dragon.Bite(),
                new Attacks.Monsters.Base.Dragon.Breath_Attack(),
                new Attacks.Monsters.Base.Dragon.Tail_Swipe()
            };

                    break;
            }

        }


        public override double Attacked(double amount)
        {
            if(CurrentHealth < MaxHealth/2)
            {
                Attacks.Add(new Attacks.Monsters.Base.Dragon.Consume());
            }
            return base.Attacked(amount);
        }

        public override double PerformAttack(Attacks.Attack attack)
        {
            if(Name.Contains("Graphite"))
            {
                if (new Random().NextDouble() < .2) return 0;
            }
            return base.PerformAttack(attack);
        }
    }
}
