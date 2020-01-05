 using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Player
{
    class Adventurer
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public string CurrentQuest { get; set; }


        public Adventurer(string _name)
        {
            Name = _name;
            set_hp(100);
        }

        public void set_hp(int hp)
        {
            HP = hp;
        }

        public void set_quest(string quest_name)
        {
            CurrentQuest = quest_name;
        }
    }
}
