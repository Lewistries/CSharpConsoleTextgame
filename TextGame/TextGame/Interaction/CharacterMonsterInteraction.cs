using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Characters;

namespace TextGame.Interaction
{
    class CharacterMonsterInteraction
    {

        private const double RESTORE_AMOUNT = .25;

        private const double RESTORE_AMOUNT_PRIEST = .5;

        private const double RESTORE_AMOUNT_DRUID = .1;

        public static int Character_Chooses_Target(IList<Monster> monsters, Character c)
        {
            int count = -1;
            while (true)
            {
                Console.WriteLine("\nWho would " + c.Name + " like to Attack?");
                int choice = 1;
                foreach (Monster m in monsters)
                {
                    Console.WriteLine(choice++ + "." + m.Name + " " + m.CurrentHealth + "/" + m.MaxHealth);
                }
                Console.WriteLine(choice + ".Return");
                try
                {
                    count = int.Parse(Console.ReadKey().KeyChar.ToString()) - 1;
                }
                catch(Exception) { }
                if (count >= 0 && count <= monsters.Count) return count;
            }
        }

        public static int Character_Chooses_Ally(Dictionary<int, Character> party, Character c)
        {
            while (true)
            {
                List<int> location = new List<int>();
                Console.WriteLine("\nWho would " + c.Name + " like to Choose?");
                int choice = 1;
                foreach (KeyValuePair<int, Character> member in party)
                {
                    location.Add(member.Key);
                    Console.WriteLine(choice++ + "." + member.Value.Name + " " + member.Value.CurrentHealth + "/" + member.Value.MaxHealth);
                }
                Console.WriteLine(choice + ".Return");
                int count = int.Parse(Console.ReadKey().KeyChar.ToString()) - 1;
                if (count == party.Count) return count;
                else if (count >= 0 && count <= party.Count) return location[count];
            }
        }

        public static Monster Character_Attacks_Monster(Monster m, Character c, Attacks.Attack attack)
        {
            if (attack.Perform())
            {
                double result = m.Attacked(c.PerformATK(attack));
                Console.WriteLine("\n" + c.Name + " attacked " + m.Name + " for " + result + " health.");
                if (!m.Living)
                {
                    c.GainExp(m.XPWorth);
                    Console.WriteLine("\n" + m.Name + " was defeated.");
                    return m;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Console.WriteLine("\n" + c.Name + " missed " + m.Name + "!");
                return null;
            }
        }

        public static void Character_Heals_Ally(Character Dealer, Character Recipient)
        {
            
                Recipient.HealCharacter((int)(Recipient.MaxHealth * (Dealer.AdvancedClass == Character.AdvancedClasses.Priest ? RESTORE_AMOUNT_PRIEST : RESTORE_AMOUNT)));
            
            
            if(Dealer.Class == Character.PlayerClass.Healer)
            {
                Dealer.HealCharacter((int)(Recipient.MaxHealth * RESTORE_AMOUNT));
            }
            Dealer.GainExp(5);
        }

        public static int Druid_Group_Heal(Dictionary<int, Character> party, Character c)
        {
            bool i = false;
            while(!i)
            {
                Console.WriteLine("\nWho would you like to heal?\n1.Full Party\n2.Party Member");
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        foreach (KeyValuePair<int, Character> key in party)
                        {
                            key.Value.HealCharacter((int)(key.Value.MaxHealth * RESTORE_AMOUNT_DRUID));
                        }
                        return 0;
                    case ConsoleKey.D2:
                        return 1;
                    default:
                        break;
                }
            }
            return -1;
            
        }


        public static Character Monster_Attacks_Character(Monster m, Character c, Attacks.Attack attack)
        {
            if (attack.Perform())
            {
                double am = m.PerformAttack(attack);
                if (c.IsAttacked(am, new Random().NextDouble()) && am != 0)
                {
                    Console.WriteLine("\n" + m.Name + " attacked " + c.Name + " with " + attack.Name + " for " + Math.Round(am * c.Defense) + " health!");
                }
                else if (am == 0)
                {
                    Console.WriteLine("\n" + c.Name + " blocked " + m.Name + ".");
                }
                else
                {
                    Console.WriteLine("\n" + c.Name + " evaded " + m.Name + "!");
                }
                if (!c.Living) return c;
                else return null;
            }
            else
            {
                Console.WriteLine("\n" + m.Name + " missed " + c.Name + "!");
                return null;
            }
        }

        public static Monster Monster_Attacks_Monster(Monster m, Monster m2, Attacks.Attack attack)
        {
            if (attack.Perform())
            {
                double am = m2.Attacked(m.PerformAttack(attack));
                Console.WriteLine("\n" + m.Name + " attacked " + m2.Name + " with " + attack.Name + " for " + am + " health.");
                if(attack.Name.Contains("Consumption"))
                {
                    m.HealMonster(am);
                }
                if (!m2.Living)
                {
                    Console.WriteLine("\n" + m2.Name + " was defeated.");
                    return m2;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                Console.WriteLine("\n" + m.Name + " missed " + m2.Name + "!");
                return null;
            }
        }

        



















    }
}
