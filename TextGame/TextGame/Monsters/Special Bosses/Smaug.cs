using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Monsters.Special_Bosses
{
    class Smaug : Monster
    {
        public override string Name { get; } = "Smaug the Living Flame";

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


        public Smaug(int characters)
        {
            Class = MonsterClass.Dragon;
            Living = true;
            MaxHealth = 50 * characters;
            CurrentHealth = MaxHealth;
            BaseCrit = 1;
            MaxATK = 35;
            Defense = .9;
            Priority = 10;
            XPWorth = 40;
            Attacks = new List<Attacks.Attack> {
                new Attacks.Monsters.Base.Dragon.Bite(2),
                new Attacks.Monsters.Bosses.Smaug.Divine_Flames(),
                new Attacks.Monsters.Base.Dragon.Consume()
            };

        }

        public override double Attacked(double amount)
        {
            if (CurrentHealth < MaxHealth / 2)
            {
                Attacks.Add(new Attacks.Monsters.Base.Dragon.Consume());
            }
            return base.Attacked(amount);
        }
    }
}
