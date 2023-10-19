using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Characters;
using TextGame.Monsters.Special_Bosses;

namespace TextGame
{
    class Level
    {


        public IList<Monster> monsters;

        public int CharCount;


        public Level(int characterCount)
        {
            CharCount = characterCount;
            monsters = new List<Monster>();
        }


        public void LoadLevel(int level, Dictionary<Entity, bool> TurnManager)
        {
            monsters.Clear();
            Console.Clear();
            Console.WriteLine("Loading Level " + level + "...");
            switch (level)
            {
                case 1:
                    LevelOne(CharCount);
                    break;
                case 2:
                    LevelTwo(CharCount);
                    break;
                case 3:
                    LevelThree(CharCount);
                    break;
                case 4:
                    LevelFour(CharCount);
                    break;
                case 5:
                    LevelFive(CharCount);
                    break;
                case 6:
                    LevelSix(CharCount);
                    break;
                case 7:
                    LevelSeven(CharCount);
                    break;
                case 8:
                    LevelEight(CharCount);
                    break;
                case 9:
                    LevelNine(CharCount);
                    break;
                case 10:
                    LevelTen(CharCount);
                    break;
                case 11:
                    LevelEleven(CharCount);
                    break;
            }
            foreach (Monster m in monsters)
            {
                Console.WriteLine(m.Name + " has appeared.");
                TurnManager.Add(m, true);
            }
        }

        public void LevelOne(int characters)
        {
            switch (characters) 
            {
                case 1:
                    monsters.Add(new Goblin(false));
                    break;
                case 2:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    break;
                case 3:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(false));
                    break;
                case 4:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    break;
        }
        }

        public void LevelTwo(int characters)
        {
            switch (characters)
            {
                case 1:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    break;
                case 2:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(false));
                    break;
                case 3:
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(false));
                    break;
                case 4:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(false));
                    break;
            }
        }

        public void LevelThree(int characters)
        {
            switch (characters)
            {
                case 1:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    break;
                case 2:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    break;
                case 3:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(false));
                    break;
                case 4:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(false));
                    break;
            }
        }

        public void LevelFour(int characters)
        {
            switch (characters)
            {
                case 1:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    break;
                case 2:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(false));
                    break;
                case 3:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(true));
                    break;
                case 4:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(true));
                    monsters.Add(new Vandal(true));
                    break;
            }
        }

        public void LevelFive(int characters)
        {
            switch (characters)
            {
                case 1:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Goblin(true));
                    break;
                case 2:
                    monsters.Add(new Goblin(true));
                    monsters.Add(new Vandal(false));
                    break;
                case 3:
                    monsters.Add(new Goblin(0));
                    monsters.Add(new Goblin(1));
                    break;
                case 4:
                    monsters.Add(new Goblin(0));
                    monsters.Add(new Goblin(1));
                    monsters.Add(new Goblin(2));
                    break;
            }
        }

        public void LevelSix(int characters)
        {
            switch (characters)
            {
                case 1:
                    monsters.Add(new Goblin(false));
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(false));
                    break;
                case 2:

                    monsters.Add(new Vandal(false));
                    monsters.Add(new Ogre(false));
                    monsters.Add(new Vandal(true));
                    break;
                case 3:
                    break;
                case 4:
                    monsters.Add(new Phogoth(characters));
                    break;
            }
        }

        public void LevelSeven(int characters)
        {
            switch (characters)
            {
                case 1:
                    monsters.Add(new Vandal(false));
                    monsters.Add(new Vandal(true));
                    break;
                case 2:


                    monsters.Add(new Vandal(false));
                    monsters.Add(new Ogre(false));
                    monsters.Add(new Ogre(false));
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        public void LevelEight(int characters)
        {
            switch (characters)
            {
                case 1:
                    monsters.Add(new Vandal(true));
                    monsters.Add(new Ogre(false));
                    break;
                case 2:
                    monsters.Add(new Ogre(false));
                    monsters.Add(new Ogre(false));
                    monsters.Add(new Vandal(true));
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        public void LevelNine(int characters)
        {
            switch (characters)
            {
                case 1:
                    monsters.Add(new Ogre(false));
                    monsters.Add(new Ogre(false));
                    break;
                case 2:
                    monsters.Add(new Ogre(false));
                    monsters.Add(new Ogre(true));
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        public void LevelTen(int characters)
        {
            switch (characters)
            {
                case 1:
                    monsters.Add(new Phogoth(1));
                    break;
                case 2:
                    monsters.Add(new Ogre(true));
                    monsters.Add(new Phogoth(2));
                    //if (monsters[0].Name.Contains("Smaug"))
                    //{
                    //    Console.WriteLine("The air...stings.");
                    //    Console.WriteLine("Press any button to continue...");
                    //    Console.ReadKey();
                    //    Console.WriteLine("Behold, the King of Fire.");
                    //}
                    //else if (monsters[0].Name.Contains("Graphite"))
                    //{
                    //    Console.WriteLine("The ground...breaths.");
                    //    Console.WriteLine("Press any button to continue...");
                    //    Console.ReadKey();
                    //    Console.WriteLine("Behold, the King of Earth.");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("The sky...breaks.");
                    //    Console.WriteLine("Press any button to continue...");
                    //    Console.ReadKey();
                    //    Console.WriteLine("Behold, the King of Sky.");
                    //}
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        public void LevelEleven(int characters)
        {
            switch (characters)
            {
                case 1:
                    monsters.Add(new Phogoth(1));
                    break;
                case 2:

                    int pick = new Random().Next(0, 3);
                    if(pick == 0)
                    {
                        Console.WriteLine("The air...stings.");
                        Console.WriteLine("Press any button to continue...");
                        Console.ReadKey();
                        Console.WriteLine("Behold, the King of Fire.");
                        monsters.Add(new Smaug(characters));
                    }
                    else if(pick == 1)
                    {
                        Console.WriteLine("The ground...breaths.");
                        Console.WriteLine("Press any button to continue...");
                        Console.ReadKey();
                        Console.WriteLine("Behold, the King of Earth.");
                        monsters.Add(new Graphite(characters));
                    }
                    else
                    {
                        Console.WriteLine("The sky...breaks.");
                        Console.WriteLine("Press any button to continue...");
                        Console.ReadKey();
                        Console.WriteLine("Behold, the King of Sky.");
                        monsters.Add(new Dracelo(characters));
                    }
                    break;
            }
        }
        public void GameFinished(Dictionary<int, Character> party)
        {
            Console.WriteLine("\nCongratulations! You have Cleared the Game!");
            Console.WriteLine("Your Champions:");
            foreach(KeyValuePair<int, Character> c in party)
            {
                c.Value.DisplayStatus(c.Value.LVL);
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
        }











    }
}
