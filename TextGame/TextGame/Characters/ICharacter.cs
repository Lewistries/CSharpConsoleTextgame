using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Attacks;

namespace TextGame.Characters
{
    internal interface ICharacter
    {

        
        public string Name { get; }

        public int MaxHealth { get; set; }

        public int CurrentHealth { get; set; }

        public bool Living { get; set; }

        public double BaseATK { get; set; }

        public double ATKMult { get; set; }

        public int Evasiveness { get; }

        public double Defense { get; set; }

        public double BaseCrit { get; set; }

        public List<Attack> Attacks { get; set; }




    }
}
