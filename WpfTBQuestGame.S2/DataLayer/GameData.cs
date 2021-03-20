using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.DataLayer
{
    public class GameData
    {
        #region CONSTANTS

        public const string DEFAULT_GAME_MESSAGE =
            "You awake lying on a stone path between rows of ornate buildings.  The last thing \n" +
            "you remember is working late in your lab.  A light mist is coming from the dense clouds \n" +
            "above.  You look around realizing you are in a different time period, unless this is\n" +
            "a very elaborate  hoax.  You notice a man pointing at you. \"Here!\" he yells.  A \n" +
            "group of men clad  in armor with swords at their sides round the corner towards you. \n" +
            "\"Take it to the Governor!\" one of them cries out." + "   " + "Click \'Next\' to continue...";

        #endregion
        
        public static Player DefaultPlayer(bool newPlayer = false, string name = "Player")
        {
            return new Player()
            {
                Id = 1000,
                Name = name,
                Location = 0,
                Kind = Character.Genus.Player,
                Lives = 3,
                BattleXP = 0,
                Health = 100,
                BattleRank = Player.BattleRankLevel.BlackBelt,
                NewPlayer = newPlayer
            
            };
        }
        public static Map MasterGameMap()
        {
            Map masterGameMap = new Map();

            //add all locations to the map

            masterGameMap.Locations.Add // The Village
                (new Location()
                {
                    Id = 100,
                    IsAccessible = true,
                    
                    Name = "The Village",
                    Description =
                    "CURRENT LOCATION:  The Village.  A small beautiful city born from the middle ages.\n" +
                    "Home base to all of your quests.",

                    LocationMessage =
                    "Welcome to the village.  You have one purpose, to get home.  Interact with everyone " +
                    "that you can as they may provide quests or gifts.  Battle in the village should be the " + 
                    "last resort..."
                }
                );       
            masterGameMap.Locations.Add //The mountains
                (new Location()
                {
                    Id = 101,
                    IsAccessible = true,
                    Name = "The Kranik Moutains",
                    Description =
                    "CURRENT LOCATION: The Kranik Moutains.  The mountains are treacherous, steep jagged\n " +
                    "peaks, and unforgiving terrain.  One must be prepared for unimaginably powerful beasts.\n",
                    LocationMessage =
                    "At the base of the mountain you see large handmade stone stairs covered in moss and " +
                    "wet from the unrelenting cold mist.  They appear to lead to oblivion, disappearing " +
                    "into the dense clouds above.  As you start to climb the gloom of clouds envelope you, " +
                    "making it impossible to see anything but a few steps in front of you.  You hear the " +
                    "cry of what sounds like an eagle, evolving into a blood curdling scream.  You feel " +
                    "the air rush past you and a massive beat of wings... Choose wisely..."
                }
                );
            masterGameMap.Locations.Add //the forest
                (new Location()
                {
                    Id = 102,
                    IsAccessible = true,
                    Name = "The Black Forest",
                    Description =
                    "CURRENT LOCATION: The Black Forest.  An ancient forest. Towering trees filter the\n" +
                    "sunlight, little of it reaches you, pine scent fills the air.",
                    LocationMessage =
                    "You hear a howling in the far distance.  Knowing few who have ventured through the forest " +
                    "have ever returned, you are not even sure how to get there.  Branches break in the darkness " +
                    "as it approaches dusk.  This may not be the best place to be at night.  Continue?"
                }
                );
            masterGameMap.Locations.Add //the aegis swamp
                (new Location()
                {
                    Id = 103,
                    IsAccessible = true,
                    Name = "The Aegis Swamp",
                    Description =
                    "CURRENT LOCATION: The Aegis Swamp.  Dark foreboding swamp.  Water floods the trees \n" +
                    "with little high ground.  The trunk of cedar trees hide all that is beyond.",
                    LocationMessage =
                    "The smell of stagnant water fills your nose as you make your way into the swamp.  Everything " +
                    "is wet, the water moves slowly flowing into the darkness.  The density of the undergrowth make it " +
                    "near impossible to travel but you push on.  Splashing erupts around you...  Continue.."
                    
                }
                );
            masterGameMap.Locations.Add // the harbor
                (new Location()
                {
                    Id = 104,
                    IsAccessible = true,
                    Name = "The Harbor",
                    Description =
                    "CURRENT LOCATION: The Harbor.  The docks are lined wih fishing trawlers.  Town folk \n" +
                    "walk about, all performing some daily task.",
                    LocationMessage =
                    "The smell low tide, and fish hits you strong.  You are looking for someone but not sure " +
                    "who.  You meander around looking for someone to talk to, everyone seems busy, as the " +
                    "boats have recently returned from the dark sea.  You can see an island out in the horizon and " +
                    "you smile as the sun warms your face, the sound of slow crashing waves calms you...  Continue"
                }
                );
            masterGameMap.Locations.Add // the abyss
                (new Location()
                {
                    Id = 105,
                    IsAccessible = true,
                    Name = "The Abyss",
                    Description =
                    "CURRENT LOCATION: The Abyss.  Darkness, fire and the end of everything\n",
                    LocationMessage =
                    "The unrelenting heat and pressure make you fall to your knees.  The smell of death makes you " +
                    "sick.  A deep guttural laugh starts in the distance and gets louder and louder.  Your vision " +
                    "begins to twist, the laughing gets louder and more sinister.  Your flesh begins to melt and you " +
                    "feel your bones cracking.  The laughter echoes through your head as you turn to dust...",
                    ModifyLives = -1
                }
                );
            masterGameMap.Locations.Add // the cave
                (new Location()
                {
                    Id = 201,
                    IsAccessible = false,
                    Name = "The Cave",
                    Description =
                    "CURRENT LOCATION: The Cave.  A place for refuge from the unrelenting death that awaits\n" +
                    "in the mountains.  Warmth and protection.",
                    LocationMessage =
                    "The entrance to the cave is proteced by a iron door, you wave the key gem infront of the " +
                    "insignia and the door seems to slide open easily.  The cave is dark, but you can feel " +
                    "the warmth and smell the food.  In the distance you see light against the wall of the cave."  +
                    "Cont..."
                }
                );
            masterGameMap.Locations.Add // the Elf citadel
                (new Location()
                {
                    Id = 202,
                    IsAccessible = false,
                    Name = "The Elf Citadel",
                    Description =
                    "CURRENT LOCATION: The Elf Citadel.  A well fortified imposing structure.  Archers \n"  +
                    "protect the flanks.  Well armored guardsmen stand at the gate.",
                    LocationMessage =
                    "The large looming structure before you looks like a picture of a 16th century castle.  " +
                    "You approach cautiously, you can feel the eyes on you.  \"Hault! Proceed no further\" a " +
                    "voice calls out to you.  Continue..."
                }
                );
            masterGameMap.Locations.Add // the witches encampment
                (new Location()
                {
                    Id = 203,
                    IsAccessible = false,
                    Name = "The Witches Encampment",
                    Description =
                    "CURRENT LOCATION: The Witches Encampment.  Weird earthly structures litter the area.  \n" +
                    "They appear to have grown out of the ground.",
                    LocationMessage =
                    "You finally reach high groud.  The only area out of the water for miles, weird smells fill your " +
                    "nostrils.  It feels like you are being watched.  A few cats scutter around you as you move.  It " +
                    "is vital you pick the right structure.  Continue..."
                }
                );
            masterGameMap.Locations.Add // the island of lost souls
                (new Location()
                {
                    Id = 204,
                    IsAccessible = false,
                    Name = "The Island of Lost Souls",
                    Description =
                        "CURRENT LOCATION: The Island of Lost Souls.  An island said to move at random in\n" +
                        "the sea, not always near land. A place of trapped tortured souls.",
                    LocationMessage =
                        "The Ferryman drops you at the dock and is simply gone.  There appears to be no life " +
                        "anywhere on the island.  You see some grave markers and hear weird ghoulish screams " +
                        "strange lights and ghostly shapes float around in the distance.  You were told it is " +
                        "always dark here.  The darkness is crushing, you feel a pull to lie on the ground " +
                        "and let them take you, your life blood feels like it is slipping away.  Continue...",
                    ModifyHealth = -50

                }
                ) ;
            masterGameMap.Locations.Add //home
                (new Location()
                    {
                        Id = 300,
                        IsAccessible = true,
                        Name = "Home",
                        Description =
                        "CURRENT LOCATION: Home.  \n",
                        LocationMessage =
                        "YOU WIN!"
                    }
                );

            //player will start the game in the village
            masterGameMap.CurrentLocation = masterGameMap.Locations.FirstOrDefault(l => l.Id == 100);

            return masterGameMap;
        }
    }
}
