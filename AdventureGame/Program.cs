using System;
using System.Threading;

namespace AdventureGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            

            Console.WriteLine("Hello Adventurer!\nWhat is your name?");

            var name = Console.ReadLine();

            var adv = SqliteStuff.SqliteHelper.GetPlayerByName(name);

            if (adv.CurrentQuest == "Start")
            {
                Console.WriteLine($"Welcome {adv.Name}!");
                Thread.Sleep(2000);
                Console.WriteLine("And so our journey begins...");
                Thread.Sleep(2000);
            }
        }
    }
}