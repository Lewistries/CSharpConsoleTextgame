using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    abstract class Entity
    {
        public abstract int Priority { get; set; }

        public enum EntityType { Character, Monster};

        public abstract EntityType EType { get; }
    }
}
