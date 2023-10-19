using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Attacks.Knight;

namespace TextGame.Characters
{
    internal class Knight : Character
    {
        public override string Name { get; }

        public override int MaxHealth { get; set; }

        public override int CurrentHealth { get; set; }

        public override PlayerClass Class { get; }
        //Shadow Knight idea
        public override AdvancedClasses AdvancedClass { get; set; }

        public override bool Living { get; set; }

        public override double BaseATK { get; set; }

        public override double ATKMult { get; set; }

        public override int Evasiveness { get; set; }

        public override double Defense { get; set; }

        public override double BaseCrit { get; set; }

        public override int Efficiency { get; set; }

        public override int Priority { get; set; }

        public Knight(string name)
        {
            Attacks = new List<Attacks.Attack>();
            Class = PlayerClass.Knight;
            AdvancedClass = AdvancedClasses.None;
            Name = name;
            LVL = 1;
            MaxHealth = 20;
            CurrentHealth = 20;
            BaseATK = 4;
            Evasiveness = 1;
            Defense = .6;
            BaseCrit = 1;
            Efficiency = 1;
            Priority = 5;
            Living = true;
            Attacks.Add(new Thrust());
            Attacks.Add(new Sweep());
        }

        public override void Evolve()
        {
            Console.WriteLine("1. " + AdvancedClasses.Paladin);
            Console.WriteLine("2. " + AdvancedClasses.Dredgen);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    AdvancedClass = AdvancedClasses.Paladin;
                    MaxHealth = (int)(MaxHealth * 1.5);
                    CurrentHealth = MaxHealth;
                    break;
                case ConsoleKey.D2:
                    AdvancedClass = AdvancedClasses.Dredgen;
                    MaxHealth = (int)(MaxHealth * 1.2);
                    CurrentHealth = MaxHealth;
                    BaseATK *= 1.5;
                    break;
            }
        }
    }
}
