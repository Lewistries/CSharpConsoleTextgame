using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Characters
{
    internal class Scout : Character
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

        public Scout(string name)
        {
            Class = PlayerClass.Scout;
            AdvancedClass = AdvancedClasses.None;
            Name = name;
            LVL = 1;
            MaxHealth = 15;
            CurrentHealth = 15;
            BaseATK = 6;
            Evasiveness = 4;
            Defense = 1.5;
            BaseCrit = 2;
            Efficiency = 1;
            Priority = 1;
            Attacks = new List<Attacks.Attack>();
            Attacks.Add(new Attacks.Scout.Stab());
            Living = true;
        }

        public override void Evolve()
        {
            Console.WriteLine("1. " + AdvancedClasses.Theif);
            Console.WriteLine("2. " + AdvancedClasses.Blitzer);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    AdvancedClass = AdvancedClasses.Theif;
                    Evasiveness += 2;
                    break;
                case ConsoleKey.D2:
                    AdvancedClass = AdvancedClasses.Blitzer;
                    Efficiency = 2;
                    BaseCrit *= 1.4;
                    break;
            }
        }
    }
}
