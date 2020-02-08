using AdventureGame.Quests;
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
                Console.WriteLine("What class are you?\nKnight\nArcher\nSorcerer");
                string playerclass = Console.ReadLine();
                SqliteStuff.SqliteHelper.Set_Class(playerclass,adv);
                adv.CurrentQuest = "SoItBegins";
                SqliteStuff.SqliteHelper.Update_Player(adv);
                Console.WriteLine($"And so our journey begins...{adv.Class}");
                Thread.Sleep(2000);

            }
            
            QuestManager manager = new QuestManager(adv);
            
        }
    }
}