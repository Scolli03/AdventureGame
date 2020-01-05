using AdventureGame.Player;
using System;

namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Adventurer!\nWhat is your name?");

            var name = Console.ReadLine();

            Adventurer adv = new Adventurer(name.ToLower());

            Console.WriteLine($"Welcome {adv.Name}!");

            if (adv.CurrentQuest == null)
            {

                Console.WriteLine("Current quest: The Beginning");
            }

        }
    }
}
