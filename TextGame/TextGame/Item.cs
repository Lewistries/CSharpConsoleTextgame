using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Item
    {


        public enum ItemType { Weapon, Healing, Armor};

        public string Name { get; }

        public ItemType type { get; }

        public int HealPwr { get; }

        public enum Rarity { Common, Rare, Legendary};

        public int Defense { get; }


        public Item(string name, ItemType type)
        {
            Name = name;
            this.type = type;
            Random random = new Random();
            switch(type)
            {
                case ItemType.Weapon:
                    //ATKPower = random.Next(1, 11);
                    break;
                case ItemType.Armor:
                    Defense = random.Next(1, 11);
                    break;

                case ItemType.Healing:
                    random.Next(1, 11);
                    break;
            }




        }










        private class Weapon
        {
            private enum WeaponType { Close, Ranged };

            public int ATKPower { get; }

            private WeaponType type { get; }

            public Weapon(int attack)
            {
                ATKPower = attack;
            }


        }





    }
}
