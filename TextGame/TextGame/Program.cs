using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TextGame.Characters;
using TextGame.Interaction;

namespace TextGame
{
    class Program
    {

        public static void Main(string[] args)
        {


            bool valid = false;
            int answer;
            int characterCount = 0;
            Console.WriteLine("Welcome to DSText RPG!");
            while (!valid)
            {

                Console.Write("Please Select an option:\n1.Start\n2.Exit\n>> ");
                if (Int32.TryParse(Console.ReadLine(), out answer))
                {
                    valid = true;

                    switch (answer)
                    {
                        case 1:
                            bool valid2 = false;
                            /**Collects input for how many characters the user would like to create*/
                            while (!valid2)
                            {
                                Console.Write("\nHow Many Characters would you like in your party? (1-4) >> ");
                                if (Int32.TryParse(Console.ReadLine(), out characterCount) && characterCount >= 1 && characterCount <= 4)
                                {
                                    valid2 = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input.");
                                }
                            }

                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                    }

                }
                /**If the input is invalid (not 1 or 2) the user is prompted to enter again*/
                else
                {
                    Console.WriteLine("\nInvalid input.");
                }
            }
            /**A dictionary of party location keys to character values*/
            Dictionary<int, Character> party = new Dictionary<int, Character>();
            Dictionary<Entity, bool> TurnOrderTest = new Dictionary<Entity, bool>();
            for (int i = 0; i < characterCount; i++)
            {
                Character c = CharacterCreator();
                party.Add(i + 1, c);
                TurnOrderTest.Add(c, true);
            }
            /**Displays the created characters*/
            Console.WriteLine("Displaying Created Characters...");
            Console.WriteLine("------------------------------------------------");
            foreach (KeyValuePair<int, Character> c in party)
            {
                Console.WriteLine("{0, 5}{1, 5}{2, 5}{3, 5}{4, 5}{5, 5}", "Name: " + c.Value.Name, "\nClass: " + c.Value.Class, "\nHealth: " + c.Value.MaxHealth, "\nAttack: " + c.Value.BaseATK, "\nDefense:" + c.Value.Defense, "\nEvasivness: " + c.Value.Evasiveness);
                Console.WriteLine("------------------------------------------------");
            }

            Console.WriteLine("Press a key to Continue...");
            Console.ReadKey();

            BeginningExpostion();

            int LvlCount = 1;
            /**Main gameplay loop*/
            while (true && LvlCount <= 11)
            {
                Console.Clear();
                Console.WriteLine("Loading Level " + LvlCount + "...");
                /**Refresh character health at the start of a new level*/
                foreach (KeyValuePair<int, Character> c in party)
                {
                    c.Value.RefreshCharacter(); 
                }
                /**Loads the level, difficulty based on number of characters and level number.*/
                Level level = new Level(characterCount);
                level.LoadLevel(LvlCount, TurnOrderTest);
                Console.WriteLine();
                /**Level loop, repeats until all monsters are defeated or all players are defeated*/
                while (level.monsters.Count > 0 && party.Count > 0)
                {
                    
                    List<KeyValuePair<Entity, bool>> list = TurnOrderTest.ToList();
                    list.Sort(new TurnOrderSorterTwo());
                    /*Characters decide their actions before monsters, in order of creation*/
                    foreach (KeyValuePair<Entity,bool> entity in SortTurnOrder(TurnOrderTest))
                    {
                        if (party.Count == 0) break;
                        if (level.monsters.Count == 0) break;
                        if (entity.Value)
                        {
                            switch (entity.Key.EType)
                            {
                                case Entity.EntityType.Character:
                                    if (level.monsters.Count <= 0) break;
                                    Character c = (Character)entity.Key;
                                    if (!c.Living) break;
                                    bool decided = false;
                                    while (!decided)
                                    {
                                        bool action = false;
                                        string decision = "";
                                        /*Repeats until the user has declared a valid action for their character*/
                                        while (!action)
                                        {
                                            decision = c.DeclareAction().Trim().ToUpper();
                                            if (!decision.Equals("I") && !decision.Equals("DS")) action = true;
                                            if (decision.Equals("DS")) c.DisplayStatus(c.LVL);
                                        }
                                        /*Handles the decided action*/
                                        switch (decision)
                                        {
                                            /*If the action is attack*/
                                            case "A":
                                                Attacks.Attack attack = c.ChooseAttack();
                                                for (int i = 0; i < attack.TargetsHit; i++)
                                                {
                                                    if (level.monsters.Count <= 0) break;
                                                    int chose = CharacterMonsterInteraction.Character_Chooses_Target(level.monsters, c);
                                                    if (chose == level.monsters.Count) decided = false;
                                                    else
                                                    {
                                                        
                                                        Monster am = CharacterMonsterInteraction.Character_Attacks_Monster(level.monsters[chose], c, attack);
                                                        if (am != null)
                                                        {
                                                            level.monsters.Remove(am);
                                                            TurnOrderTest[am] = false;
                                                            TurnOrderTest.Remove(am);
                                                            
                                                        }
                                                        decided = true;
                                                    }
                                                }
                                                break;
                                            case "H":

                                                if (c.AdvancedClass != Character.AdvancedClasses.Druid)
                                                {
                                                    int choseh = CharacterMonsterInteraction.Character_Chooses_Ally(party, c);
                                                    if (choseh == party.Count) decided = false;
                                                    else
                                                    {
                                                        CharacterMonsterInteraction.Character_Heals_Ally(c, party[choseh]);
                                                        decided = true;
                                                    }
                                                }
                                                else
                                                {
                                                    int dec = -1;
                                                    while (dec == -1)
                                                    {
                                                        dec = CharacterMonsterInteraction.Druid_Group_Heal(party, c);
                                                    }
                                                    if (dec == 1)
                                                    {
                                                        int chosen = CharacterMonsterInteraction.Character_Chooses_Ally(party, c);
                                                        if (chosen == party.Count) decided = false;
                                                        else
                                                        {
                                                            CharacterMonsterInteraction.Character_Heals_Ally(c, party[chosen + 1]);
                                                            decided = true;
                                                        }
                                                    }
                                                    else if (dec == 0)
                                                    {
                                                        decided = true;
                                                    }

                                                }

                                                break;
                                        }

                                    }
                                    break;
                                case Entity.EntityType.Monster:
                                    Monster m = (Monster)entity.Key;
                                    if (!m.Living) break;
                                    Attacks.Attack MonsterAttack = m.Attacks[new Random().Next(0, m.Attacks.Count)];
                                    if (MonsterAttack.Friendly_Hit && level.monsters.Count > 1)
                                    {
                                        Monster picked = level.monsters[new Random().Next(0, level.monsters.Count)];
                                        while(m == picked)
                                        {
                                            picked = level.monsters[new Random().Next(0, level.monsters.Count)];
                                        }
                                        CharacterMonsterInteraction.Monster_Attacks_Monster(m, picked, MonsterAttack);
                                    }
                                    else
                                    {
                                        for (int i = 0; i < MonsterAttack.TargetsHit && i < party.Count; i++)
                                        {
                                            int target = m.PickTarget(party);
                                            Character c2 = CharacterMonsterInteraction.Monster_Attacks_Character(m, party[target], MonsterAttack);
                                            if (c2 != null)
                                            {
                                                Console.WriteLine(c2.Name + " has fallen...");
                                                party.Remove(target);
                                                TurnOrderTest[c2] = false;
                                                TurnOrderTest.Remove(c2);
                                            }
                                            if (party.Count == 0) break;
                                        }
                                        if (party.Count == 0) break;
                                    }
                                        
                                    break;
                            }
                        }
                    }



                }
                CheckLevelCompleted(party.Count, level.monsters.Count, party, LvlCount, level);
                LvlCount++;
                if (LvlCount > 11)
                {
                    CheckLevelCompleted(party.Count, level.monsters.Count, party, LvlCount, level);
                }
            }

        }

        private static void CheckLevelCompleted(int charsremaining, int monstersremaining, Dictionary<int, Character> party, int LvlCount, Level level)
        {
            if (monstersremaining == 0 && charsremaining > 0 && LvlCount <= 10)
            {
                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine("Level Completed!");
                foreach (KeyValuePair<int, Character> c in party)
                {
                    Console.WriteLine(c.Value.Name + " gained experiance.");
                    c.Value.GainExp(6 * charsremaining);
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.WriteLine("------------------------------------------------");
                Console.ReadKey();
                if (LvlCount == 5)
                {
                    LevelFiveCompleted(party);
                }
                if (LvlCount == 12)
                {
                    level.GameFinished(party);
                }
            }
            else if (party.Count == 0)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Game Over!");
                Console.WriteLine("Press any key to exit.");
                Console.WriteLine("------------------------------------------------");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                level.GameFinished(party);
            }


        }

        private static List<KeyValuePair<Entity,bool>> SortTurnOrder(Dictionary<Entity,bool> pairs)
        {
            List<KeyValuePair<Entity, bool>> list = pairs.ToList();
            list.Sort(new TurnOrderSorterTwo());
            return list;
        }

        private static Character CharacterCreator()
        {

            string[] answers = new string[2];
            Console.Write("Enter the Characters Name >> ");
            answers[0] = (Console.ReadLine().Trim());
            bool valid = false;
            int Class = 0;
            while (!valid)
            {
                Console.Write("\nEnter the Characters Class:\n1.Knight\n2.Scout\n3.Archer\n4.Healer\n>> ");
                answers[1] = (Console.ReadLine());
                if (Int32.TryParse(answers[1], out Class) && Class >= 1 && Class <= 4)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid Input");
                }
            }
            Class--;

            switch (Class)
            {
                case 0:
                    return new Knight(answers[0]);
                case 1:
                    return new Scout(answers[0]);
                case 2:
                    return new Archer(answers[0]);
                case 3:
                    return new Healer(answers[0]);
                default:
                    return null;
            }



        }


        //private static void DragonAttack(Monster m, Dictionary<int, Character> party, Dictionary<Entity,bool> entities)
        //{

        //    if (!m.Name.Contains("Smaug"))
        //    {
        //        BasicAttack(m, party,entities);
        //    }
        //    else
        //    {
        //        int flames = new Random().Next(1, party.Count);
        //        for (int k = 0; k < flames; k++)
        //        {
        //            BasicAttack(m, party,entities);
        //        }
        //    }

        //}

        //private static void BasicAttack(Monster m, Dictionary<int, Character> party, Dictionary<Entity,bool> entities)
        //{
        //    IList<int> att = new List<int>();

        //    for (int i = 0; i < party.Count * 2; i++)
        //    {

        //        att.Add(m.PickTarget(party));
        //    }
        //    int acc = att[0];
        //    foreach (int i in att)
        //    {
        //        if (party[i].Class == Character.PlayerClass.Knight) acc = i; break;
        //    }
        //    double am = m.PerformAttack();
        //    if (party[acc].IsAttacked(am, new Random().Next(1, 11)) && am != 0)
        //    {
        //        Console.WriteLine("\n" + m.Name + " attacked " + party[acc].Name + " for " + Math.Round(am * party[acc].Defense) + " health!");
        //    }
        //    else if (am == 0)
        //    {
        //        Console.WriteLine("\n" + party[acc].Name + " blocked " + m.Name + ".");
        //    }
        //    else
        //    {
        //        Console.WriteLine("\n" + m.Name + " missed " + party[acc].Name + "!");
        //    }
        //    if (!party[acc].Living)
        //    {
        //        Console.WriteLine(party[acc].Name + " has fallen...");
        //        Character c = party[acc];
        //        party.Remove(acc);
        //        entities[c] = false;
        //        entities.Remove(c);
        //    }
        //}



        private static void BeginningExpostion()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("You open your eyes to a deep darkness.");
            Console.WriteLine("A chill envelops your weary bones.");
            Console.WriteLine("The sound of the wind reminds you of a distant scream.");
            Console.WriteLine("Lighting a torch, you find yourself in a cave.");
            Console.WriteLine("Monsters eyes glow in the darkness.");
            Console.WriteLine("You grab your equipment and begin the journey.");
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine("------------------------------------------------");
            Console.ReadKey();
        }

        private static void LevelFiveCompleted(Dictionary<int, Character> party)
        {
            foreach (KeyValuePair<int, Character> h in party)
            {
                h.Value.MaxHealth += 5;
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("With the fall of the Goblin King and his court\nyou find new life pushing you forwards.");
            Console.WriteLine("Character health + 5");
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine("------------------------------------------------");
            Console.ReadKey();
        }




    }


    internal class TurnOrderSorter : IComparer<Entity>
    {
        public int Compare([AllowNull] Entity x, [AllowNull] Entity y)
        {
            if (x.Priority < y.Priority) return -1;
            else if (x.Priority > y.Priority) return 1;
            else if (x.EType == Entity.EntityType.Character) return -1;
            else if (y.EType == Entity.EntityType.Monster) return 1;
            else return 0;
        }
    }

    //internal class TurnOrderSorterTwo : IComparer<KeyValuePair<Entity,bool>>
    //{
    //    public int Compare([AllowNull] KeyValuePair<Entity,bool> x, [AllowNull] KeyValuePair<Entity,bool> y)
    //    {
    //        if (x.Key.Priority < y.Key.Priority) return -1;
    //        else if (x.Key.Priority > y.Key.Priority) return 1;
    //        else if (x.Key.EType == Entity.EntityType.Character) return -1;
    //        else if (y.Key.EType == Entity.EntityType.Monster) return 1;
    //        else return 0;
    //    }
    //}
}
