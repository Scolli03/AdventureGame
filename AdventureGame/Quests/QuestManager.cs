using AdventureGame.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Quests
{
    public class QuestManager
    {
        public QuestManager(Adventurer player)
        {
            string questname = player.CurrentQuest;
            switch (questname)
            {
                case "SoItBegins":
                    var quest = new SoItBeginsQuest(player);
                    break;
            }
        }
    }
}
