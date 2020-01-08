 using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Player
{
    public class Adventurer
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public string CurrentQuest { get; set; }

        public string Class { get; set; }


        public Adventurer()
        {
            
        }

        

        public void set_quest(string quest_name)
        {
            CurrentQuest = quest_name;
        }
    }
}
