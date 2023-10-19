using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Attacks;

namespace TextGame.Characters
{
    internal class Healer : Character
    {
        public override string Name { get; }

        public override int MaxHealth { get; set; }

        public override int CurrentHealth { get; set; }

        public override PlayerClass Class { get; }

        public override AdvancedClasses AdvancedClass { get; set; }

        public override bool Living { get; set; }

        public override double BaseATK { get; set; }

        public override double ATKMult { get; set; }

        public override int Evasiveness { get; set; }

        public override double Defense { get; set; }

        public override double BaseCrit { get; set; }

        public override int Efficiency { get; set; }

        public override int Priority { get; set; }
        public Healer(string name)
        {
            Class = PlayerClass.Healer;
            AdvancedClass = AdvancedClasses.None;
            Name = name;
            LVL = 1;
            MaxHealth = 10;
            CurrentHealth = 10;
            BaseATK = 2;
            Defense = .8;
            Evasiveness = 2;
            BaseCrit = 1;
            Efficiency = 1;
            Priority = 3;
            Living = true;
            Attacks = new List<Attacks.Attack>();
            Attacks.Add(new Attacks.Healer.Life_Drain());
        }

        public override double PerformATK(Attack attack)
        {
            double amount = base.PerformATK(attack);
            HealCharacter((int) amount);
            return amount;
        }

        public override void Evolve()
        {
            Console.WriteLine("1. " + AdvancedClasses.Priest);
            Console.WriteLine("2. " + AdvancedClasses.Druid);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    AdvancedClass = AdvancedClasses.Priest;
                    break;
                case ConsoleKey.D2:
                    AdvancedClass = AdvancedClasses.Druid;
                    BaseATK = 4;
                    break;
            }
        }
    }
}
