using AdventureGame.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Quests
{
    public class SoItBeginsQuest
    {
        private Adventurer _player { get; set; }

        public SoItBeginsQuest(Adventurer adventurer)
        {
            _player = adventurer;

            string dialog = "You awake to the sound of chaos. Screams...barely audible over the explosive shockwaves that seem to be crumbling " +
                "the very foundation beneath you. Though you've never seem one before, you know exactally what it is. \"A Titan!...Fuck!\"" +
                $" You leap from your bed and grab your {_player.Weapon} on the way out the door.\"For whatever good it will do\" you think to yourself. " +
                $"As you exit into the night you get pelted rocks and dirt. They are not being thrown, but rather falling upon you as if the sky was raining earth. " +
                $"You look up to the night sky not to see the stars but a floating mountain. The very scale of the Titan " +
                $"makes you question if you ever really woke up at all, or if this is just a dream. That must be it...this is a nightmare. " +
                $"Only in a nightmare should you be forced to watch a giant foot begin its decent down to obliterate all you've ever known. " +
                $"Suddenly a loud shriek snaps you out of your daze and you look to a woman pointing up in terror. You look to where she is " +
                $"pointing and see a huge boulder hurling at the both of you. You react on instinct and...\n\n";
            
            Console.WriteLine(dialog);

            if(_player.Class == "Sorcerer")
            {
                Console.WriteLine("A: Point your staff into the air and shout an encantation.\nB: Jump and tackle the woman out of the way.\nC: Run back into your house.");

            }
            
        }


        
    }
}
