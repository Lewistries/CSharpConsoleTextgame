using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Monsters.Special_Bosses
{
    class Dracelo : Monster
    {
        public override string Name { get; } = "Dracelo the Storm";

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


        public Dracelo(int characters)
        {
            Class = MonsterClass.Dragon;
            Living = true;
            MaxHealth = 40 * characters;
            CurrentHealth = MaxHealth;
            BaseCrit = 1;
            MaxATK = 35;
            Priority = 10;
            Defense = 1.1;
            XPWorth = 40;
            Attacks = new List<Attacks.Attack> {
                new Attacks.Monsters.Base.Dragon.Bite(2),
                new Attacks.Monsters.Bosses.Graphite.Earth_Tear(),
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
