using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Attacks;
using TextGame.Characters;

namespace TextGame
{
    internal interface IStandardMonster
    {

        public string Name { get; }

        public int MaxHealth { get; set; }

        public double CurrentHealth { get; set; }

        public double Defense { get; }

        public Monster.MonsterClass Class { get; }


        public bool Living { get; set; }

        public int MaxATK { get; set; }

        public double BaseCrit { get; }

        public int XPWorth { get; }

        public bool IsBoss { get; }

        public List<Attack> Attacks { get; set; }

        public double Attacked(double amount);

        public double HealMonster(double amount);

        public int PickTarget(Dictionary<int, Character> character);

        public double PerformAttack(Attack attack);





    }
}
