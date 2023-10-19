using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TextGame
{
    internal class Vandal : Monster
    {

        public override string Name { get; }
        public override Monster.MonsterClass Class { get; }
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


        private readonly IList<string> Vandal_bosses = ConfigurationManager.AppSettings.Get("VandalBosses").Split(',');

        public Vandal(bool boss)
        {
            IsBoss = boss;
            Class = MonsterClass.Vandal;
            Living = true;
            Priority = 4;
            Defense = 1;
            Attacks = new List<Attacks.Attack> {
                new Attacks.Monsters.Base.Vandal.Melee(),
                new Attacks.Monsters.Base.Vandal.Precise_Shot()
            };
            switch (boss)
            {
                case true:
                    
                    double val = new Random().NextDouble();
                    if (val < .15) Name = Vandal_bosses[0].Trim();
                    else Name = Vandal_bosses[1].Trim();
                    
                    switch (Name)
                    {
                        case "Randal the Vandal":
                            MaxHealth = 25;
                            CurrentHealth = MaxHealth;
                            BaseCrit = 1;
                            MaxATK = 3;
                            XPWorth = 20;
                            break;
                        case "Elite Vandal":
                            MaxHealth = 12;
                            CurrentHealth = MaxHealth;
                            BaseCrit = 1;
                            MaxATK = 12;
                            XPWorth = 10;
                            break;
                    }
                    break;
                case false:
                    Name = "Vandal";
                    MaxHealth = 8;
                    CurrentHealth = MaxHealth;
                    BaseCrit = 1;
                    MaxATK = 12;
                    XPWorth = 5;

                    break;
            }
        }
    }
}

