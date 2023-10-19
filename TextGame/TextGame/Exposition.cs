using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Exposition
    {
        public bool Beginning;

        public Exposition()
        {
            Beginning = true;
        }


        public void BeginningExpostion()
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
            Beginning = false;
        }

        public bool GetBeginning()
        {
            return Beginning;
        }

    }
}
