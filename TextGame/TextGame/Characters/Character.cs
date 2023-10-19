using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Attacks;

namespace TextGame.Characters
{
    [Serializable]
    abstract class Character : Entity, ICharacter
    {

        public enum PlayerClass { Knight, Scout, Archer, Healer };
        public enum AdvancedClasses { Paladin, Dredgen, Stormbringer, Sharpshooter, Theif, Blitzer, Priest, Druid, None };

        public override EntityType EType { get; } = EntityType.Character;

        public abstract string Name { get; }

        public abstract int MaxHealth { get; set; }

        public abstract int CurrentHealth { get; set; }

        public abstract PlayerClass Class { get; }

        public abstract AdvancedClasses AdvancedClass { get; set; }

        public abstract bool Living { get; set; }

        public abstract double BaseATK { get; set; }

        public abstract double ATKMult { get; set; }

        public abstract int Evasiveness { get; set;  }

        public abstract double Defense { get; set; }

        public abstract double BaseCrit { get; set; }

        public abstract int Efficiency { get; set; }

        private const float XP_MODIFIER = .33f;

        private float CurrentExp = 0;

        private float XPToLVL = 5;

        public int LVL { get; set; } = 1;
        public List<Attack> Attacks { get; set; }

        public double HealCharacter(int amount)
        {
            CurrentHealth += amount;

            if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
            Console.WriteLine("\n" + Name + " was healed.");

            return CurrentHealth;
        }

        public void DisplayStatus(int level)
        {

            Console.WriteLine("\n------------------------------------------------");
            if (level < 10)
            {
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Class: " + Class);
                Console.WriteLine("Health: " + CurrentHealth + "/" + MaxHealth);
                Console.WriteLine("Attack: " + BaseATK);
                Console.WriteLine("Defense: " + Defense);
                Console.WriteLine("Evasiveness: " + Evasiveness);
            }
            else
            {
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Class: " + AdvancedClass);
                Console.WriteLine("Health: " + CurrentHealth + "/" + MaxHealth);
                Console.WriteLine("Attack: " + BaseATK);
                Console.WriteLine("Defense: " + Defense);
                Console.WriteLine("Evasiveness: " + Evasiveness);
            }
            Console.WriteLine("------------------------------------------------");
        }

        public string DeclareAction()
        {

            Console.WriteLine("\nWhat will " + Name + " do?");
            if (Class == PlayerClass.Healer || AdvancedClass == AdvancedClasses.Paladin)
            {
                Console.WriteLine("1.Attack\n2.Heal\n3.Display Status");
                return Console.ReadKey(true).Key switch
                {
                    ConsoleKey.D1 => "A",
                    ConsoleKey.D2 => "H",
                    ConsoleKey.D3 => "DS",
                    _ => "I",
                };
            }
            else
            {
                Console.WriteLine("1.Attack\n2.Display Status");
                return Console.ReadKey(true).Key switch
                {
                    ConsoleKey.D1 => "A",
                    ConsoleKey.D2 => "DS",
                    _ => "I",
                };
            }


        }


        public bool IsAttacked(double damage, double accuracy)
        {
            /*Make better*/
            if (Evasiveness/10 <= accuracy) CurrentHealth -= (int) Math.Round(damage * Defense);
            if (CurrentHealth <= 0) Living = false;
            return Evasiveness/10 <= accuracy;
        }

        public void GainExp(float exp)
        {
            CurrentExp += exp;
            if (CurrentExp >= XPToLVL) GainLVL();
        }

        private void GainLVL()
        {
            LVL++;
            if (LVL != 10)
            {
                Console.WriteLine("\n" + Name + " has leveled up!\nCurrent Level: " + LVL);
                MaxHealth = (int) (MaxHealth * .1 + MaxHealth);
                ATKMult += .1;
            }
            else
            {
                Console.WriteLine("Level 10 reached, select advanced class");
                Evolve();
            }

            float next = XPToLVL + XPToLVL * XP_MODIFIER;
            XPToLVL = next;
            CurrentExp = 0;
        }

        public abstract void Evolve();

        public virtual double PerformATK(Attack attack)
        {

            Random rand = new Random();
            if(attack.CritChance > rand.NextDouble())
            {
                Console.WriteLine("\n" + "Critical Hit!");
                return Math.Round(attack.Damage + ATKMult * attack.Damage + .3 * (attack.Damage + ATKMult * attack.Damage));
            }
            else
            {
                return Math.Round(attack.Damage + ATKMult * attack.Damage);
            }
        }

        public void RefreshCharacter()
        {
            CurrentHealth = MaxHealth;
        }

        public Attack ChooseAttack()
        {
            
            int choice = 0;
            while (true)
            {
                int count = 1;
                Console.WriteLine("Choose an Attack:");
                foreach (Attack a in Attacks)
                {
                    Console.WriteLine(count++ + "." + a.Name);
                }
                try
                {
                    choice = Int32.Parse(Console.ReadKey(true).KeyChar.ToString());
                }
                catch (Exception) { }
                if (choice >= 1 && choice <= Attacks.Count) return Attacks[choice - 1];

            }
        }






    }
}
