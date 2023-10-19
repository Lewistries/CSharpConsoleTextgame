using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using TextGame.Characters;
using TextGame.Interaction;

namespace TextGame
{
    public enum States
    {
        Battle,
        Town,
        Start,
        GameOver,
        Save,
        Close
    }
    public enum Command
    {
        Advance,
        EndG,
        EndB,
        Save,
        Exit
    }
    public class StateMachine
    {
        class Transition 
        {
            private readonly States State;
            private readonly Command Command;

            public Transition(States current, Command command)
            {
                State = current;
               Command = command;
            }

            public override int GetHashCode()
            {
                return 17 + 31 * State.GetHashCode() + 31 * Command.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                Transition other = obj as Transition;

                return other != null && State == other.State && Command == other.Command;
            }





        }

        Dictionary<Transition, States> Transitions;
        public States CurrentState { get; set; }

        public StateMachine()
        {
            CurrentState = States.Start;
            Transitions = new Dictionary<Transition, States>
            {
                { new Transition(States.Start, Command.Advance), States.Battle },
                { new Transition(States.Start, Command.Exit), States.Close },
                { new Transition(States.Battle, Command.Exit), States.Close },
                { new Transition(States.Battle, Command.EndG), States.Town},
                { new Transition(States.Battle, Command.EndB), States.GameOver},
                { new Transition(States.Battle, Command.Advance), States.Battle},
                { new Transition(States.Town, Command.Exit), States.Close },
                { new Transition(States.Town, Command.Advance), States.Battle },
                { new Transition(States.Town, Command.Save), States.Save },
                { new Transition(States.GameOver, Command.Exit), States.Close },
                { new Transition(States.Save, Command.Exit), States.Close },

            };
        }

        public States GetNext(Command command)
        {
            Transition transition = new Transition(CurrentState, command);
            States nextState;
            if (!Transitions.TryGetValue(transition, out nextState)) throw new Exception("Invalid transtion:" + CurrentState + " -> " + command);
            return nextState;

        }

        public States MoveNext(Command command)
        {
            CurrentState = GetNext(command);
            return CurrentState;
        }



    }

    public class StateProgram
    {
        public static void Main()
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
            Dictionary<Entity, bool> TurnManager = new Dictionary<Entity, bool>();
            for (int i = 0; i < characterCount; i++)
            {
                Character c = CharacterCreator();
                party.Add(i + 1, c);
                TurnManager.Add(c, true);
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

            StateMachine machine = new StateMachine();

            Exposition exposition = new Exposition();
            int LevelCount = 1;
            Level level = new Level(party.Count);
            while(true)
            {
                switch (machine.CurrentState) 
                    {
                    case States.Start:
                        if(exposition.GetBeginning())
                        {
                            exposition.BeginningExpostion();
                            machine.MoveNext(Command.Advance);
                        }
                        break;
                    case States.Battle:
                        level.LoadLevel(LevelCount, TurnManager);
                        while (level.monsters.Count > 0 && party.Count > 0)
                        {

                            List<KeyValuePair<Entity, bool>> list = TurnManager.ToList();
                            list.Sort(new TurnOrderSorterTwo());
                            /*Characters decide their actions before monsters, in order of creation*/
                            foreach (KeyValuePair<Entity, bool> entity in SortTurnOrder(TurnManager))
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
                                                                    TurnManager[am] = false;
                                                                    TurnManager.Remove(am);

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
                                                while (m == picked)
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
                                                        TurnManager[c2] = false;
                                                        TurnManager.Remove(c2);
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
                        if (party.Count <= 0) machine.MoveNext(Command.EndB);
                        else if(level.monsters.Count <= 0)
                        {

                        }
                        break;
                }
                
            }



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

            return Class switch
            {
                0 => new Knight(answers[0]),
                1 => new Scout(answers[0]),
                2 => new Archer(answers[0]),
                3 => new Healer(answers[0]),
                _ => null,
            };
        }

        private static List<KeyValuePair<Entity, bool>> SortTurnOrder(Dictionary<Entity, bool> pairs)
        {
            List<KeyValuePair<Entity, bool>> list = pairs.ToList();
            list.Sort(new TurnOrderSorterTwo());
            return list;
        }
    }

    internal class TurnOrderSorterTwo : IComparer<KeyValuePair<Entity, bool>>
    {
        public int Compare([AllowNull] KeyValuePair<Entity, bool> x, [AllowNull] KeyValuePair<Entity, bool> y)
        {
            if (x.Key.Priority < y.Key.Priority) return -1;
            else if (x.Key.Priority > y.Key.Priority) return 1;
            else if (x.Key.EType == Entity.EntityType.Character) return -1;
            else if (y.Key.EType == Entity.EntityType.Monster) return 1;
            else return 0;
        }
    }
}
