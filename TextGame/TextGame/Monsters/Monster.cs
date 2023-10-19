using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextGame.Characters;

namespace TextGame
{
    abstract class Monster : Entity, IStandardMonster
    {
        public enum MonsterClass { Goblin, Ogre, Dragon, Vandal };
        public abstract string Name { get; }

        public abstract int MaxHealth { get; set; }

        public abstract double CurrentHealth { get; set; }

        public abstract MonsterClass Class { get; }

        public override EntityType EType { get; } = EntityType.Monster;

        public abstract bool IsBoss {get;}

        public abstract bool Living { get; set; }

        public abstract int MaxATK { get; set; }

        public abstract double BaseCrit { get; }

        public abstract int XPWorth { get; }

        public abstract double Defense { get; }

        public abstract List<Attacks.Attack> Attacks { get; set; }

        public virtual double Attacked(double amount)
        {
            CurrentHealth -= Math.Round(amount * Defense);

            if(CurrentHealth <= 0)
            {
                Living = false;
            }

            return Math.Round(amount * Defense);
        }

        public virtual double HealMonster(double amount)
        {
            CurrentHealth += amount;

            if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
            Console.WriteLine("\n" + Name + " was healed.");

            return CurrentHealth;
        }

        public virtual int PickTarget(Dictionary<int, Character> characters)
        {
            double chance = new Random().NextDouble();
            foreach(KeyValuePair<int, Character> c in characters)
            {
                switch(c.Key)
                {
                    case 1:
                        switch(c.Value.Class)
                        {
                            case Character.PlayerClass.Knight:
                                if (chance < .4) return c.Key;
                                break;
                            case Character.PlayerClass.Scout:
                                if (chance >= .4 && chance < .6) return c.Key;
                                break;
                            case Character.PlayerClass.Archer:
                                if (chance >= .6 && chance < .8) return c.Key;
                                break;
                            case Character.PlayerClass.Healer:
                                if (chance >= .8 && chance <= 1) return c.Key;
                                break;
                        }
                        break;
                    case 2:
                        switch (c.Value.Class)
                        {
                            case Character.PlayerClass.Knight:
                                if (chance < .4) return c.Key;
                                break;
                            case Character.PlayerClass.Scout:
                                if (chance >= .4 && chance < .6) return c.Key;
                                break;
                            case Character.PlayerClass.Archer:
                                if (chance >= .6 && chance < .8) return c.Key;
                                break;
                            case Character.PlayerClass.Healer:
                                if (chance >= .8 && chance <= 1) return c.Key;
                                break;
                        }
                        break;
                    case 3:
                        switch (c.Value.Class)
                        {
                            case Character.PlayerClass.Knight:
                                if (chance < .4) return c.Key;
                                break;
                            case Character.PlayerClass.Scout:
                                if (chance >= .4 && chance < .6) return c.Key;
                                break;
                            case Character.PlayerClass.Archer:
                                if (chance >= .6 && chance < .8) return c.Key;
                                break;
                            case Character.PlayerClass.Healer:
                                if (chance >= .8 && chance <= 1) return c.Key;
                                break;
                        }
                        break;
                    case 4:
                        switch (c.Value.Class)
                        {
                            case Character.PlayerClass.Knight:
                                if (chance < .4) return c.Key;
                                break;
                            case Character.PlayerClass.Scout:
                                if (chance >= .4 && chance < .6) return c.Key;
                                break;
                            case Character.PlayerClass.Archer:
                                if (chance >= .6 && chance < .8) return c.Key;
                                break;
                            case Character.PlayerClass.Healer:
                                if (chance >= .8 && chance <= 1) return c.Key;
                                break;
                        }
                        break;
                }
            }
            return characters.ElementAt(new Random().Next(0, characters.Count)).Key;
        }
       


        public virtual double PerformAttack(Attacks.Attack attack)
        {
            Random rand = new Random();
            if (attack.CritChance > rand.NextDouble())
            {
                return Math.Round(attack.Damage + (.3 * attack.Damage));
            }
            else
            {
                return attack.Damage;
            }
        }
    }
}
