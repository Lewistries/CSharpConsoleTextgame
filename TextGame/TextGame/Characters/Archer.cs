using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Characters
{
    internal class Archer : Character
    {
        public override string Name { get; }

        public override int MaxHealth { get; set; }

        public override int CurrentHealth { get; set; }

        public override PlayerClass Class { get; }

        public override AdvancedClasses AdvancedClass { get; set; }

        public override bool Living { get; set; }

        public override  double BaseATK { get; set; }

        public override  double ATKMult { get; set; }

        public override  int Evasiveness { get; set; }

        public override  double Defense { get; set; }

        public override double BaseCrit { get; set; }

        public override int Efficiency { get; set; }

        public override int Priority { get; set; }

        public Archer(string name)
        {
            Class = PlayerClass.Archer;
            AdvancedClass = AdvancedClasses.None;
            Name = name;
            LVL = 1;
            MaxHealth = 15;
            CurrentHealth = 15;
            BaseATK = 6;
            Evasiveness = 4;
            BaseCrit = 1;
            Defense = .9;
            Efficiency = 1;
            Priority = 0;
            Attacks = new List<Attacks.Attack>
            {
                new Attacks.Archer.Arrow_Shot()
            };
            Living = true;
        }

        public override void Evolve()
        {
            Console.WriteLine("1. " + AdvancedClasses.Sharpshooter);
            Console.WriteLine("2. " + AdvancedClasses.Stormbringer);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    AdvancedClass = AdvancedClasses.Sharpshooter;
                    Attacks.Add(new Attacks.Archer.Sharpshooter.Arrow_Bolt());
                    break;
                case ConsoleKey.D2:
                    AdvancedClass = AdvancedClasses.Stormbringer;
                    Attacks.Add(new Attacks.Archer.Stormbringer.Storm_Shot());
                    Efficiency = 3;
                    break;
            }
        }
    }
}
