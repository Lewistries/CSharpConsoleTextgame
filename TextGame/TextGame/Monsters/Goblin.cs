using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TextGame
{
    internal class Goblin : Monster
    {

        public override string Name { get; }
        public override MonsterClass Class { get; }
        public override int MaxHealth { get; set; }
        public override double CurrentHealth { get; set; }
        public override bool Living { get; set; }

        public override bool IsBoss { get; }
        public override int MaxATK { get; set; }

        public override double BaseCrit { get; }

        public override int XPWorth { get; }

        public override int Priority { get; set; }
        public override double Defense { get; }

        public override List<Attacks.Attack> Attacks { get; set; }


        private readonly IList<string> Goblin_bosses = ConfigurationManager.AppSettings.Get("GoblinBosses").Split(',');

        public Goblin(bool boss) 
        {
            Class = MonsterClass.Goblin;
            Living = true;
            IsBoss = boss;
            Attacks = new List<Attacks.Attack> {
                new Attacks.Monsters.Base.Goblin.Rusty_Stab(),
                new Attacks.Monsters.Base.Goblin.Bloody_Club()
            };
            Defense = 1;
            switch (boss)
            {
                case true:
                    Name = Goblin_bosses[new Random().Next(0, Goblin_bosses.Count)].Trim();
                    switch(Name)
                    {
                        case "Verag the Goblin King":
                            MaxHealth = 20;
                            CurrentHealth = MaxHealth;
                            BaseCrit = 1;
                            MaxATK = 10;
                            XPWorth = 6;
                            Priority = 7;
                            break;
                        case "Cesil the Goblin Knight":
                            MaxHealth = 15;
                            CurrentHealth = MaxHealth;
                            BaseCrit = 1;
                            MaxATK = 15;
                            XPWorth = 8;
                            Priority = 5;
                            break;
                        case "Indo the Goblin Scourge":
                            MaxHealth = 10;
                            CurrentHealth = MaxHealth;
                            BaseCrit = 1.5;
                            MaxATK = 15;
                            XPWorth = 8;
                            Priority = 0;
                            break;
                    }
                    break;
                case false:
                    Name = "Goblin";
                    MaxHealth = 5;
                    CurrentHealth = MaxHealth;
                    BaseCrit = 1;
                    MaxATK = 8;
                    XPWorth = 2;
                    Priority = 2;

                    break;
            }

        }

        public Goblin(int selectBoss)
        {
            Class = MonsterClass.Goblin;
            Living = true;
            IsBoss = true;
            switch (selectBoss)
            {
                case 1:
                    Name = Goblin_bosses[1].Trim();
                    MaxHealth = 15;
                    CurrentHealth = MaxHealth;
                    BaseCrit = 1;
                    MaxATK = 15;
                    XPWorth = 6;
                    break;
                case 2:
                    Name = Goblin_bosses[2].Trim();
                    MaxHealth = 10;
                    CurrentHealth = MaxHealth;
                    BaseCrit = 1;
                    MaxATK = 20;
                    XPWorth = 6;
                    break;
                default:
                    Name = Goblin_bosses[0].Trim();
                    MaxHealth = 20;
                    CurrentHealth = MaxHealth;
                    BaseCrit = 1;
                    MaxATK = 10;
                    XPWorth = 6;
                    break;
            }
        }


        public override double Attacked(double amount)
        {
            switch(Name)
            {
                case "Verag the Goblin King":
                    return base.Attacked(amount * .9);
                    
                case "Cesil the Goblin Knight":
                    return base.Attacked(amount * .7);
                    
                case "Indo the Goblin Scourge":
                    return base.Attacked(amount * 1.2);
                 default:
                    return base.Attacked(amount);
                    
            }
          
        }




    }
}
