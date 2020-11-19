using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConversationHolder
{
    private static List<string> Scene0Strings;
    private static List<string> Scene1Strings;
    private static List<string> Scene2Strings;
    private static List<string> Library1Strings;
    private static List<string> Dungeon1Strings;
    private static List<string> Scene3Strings;
    private static List<string> AfterKeyScene3Strings;
    private static List<string> Library2Strings;
    private static List<string> Dungeon2Strings;
    private static List<string> AfterEnemiesDeadDungeon2;
    private static List<string> AfterPuzzleSolvedLibrary2;
    private static List<string> AfterScrollFound;
    private static List<string> Scene5Strings;

    public static List<string> AddCurrentStrings(string _sceneName)
    {
        List<string> temp = new List<string>();
        switch(_sceneName)
        {
            case "StageZero":
                AddScene0Strings();
                temp = Scene0Strings;
                break;
            case "StageOne":
                AddScene1Strings();
                temp = Scene1Strings;
                break;
            case "StageTwo":
                AddScene2Strings();
                temp = Scene2Strings;
                break;
            case "StageTwoPointOneDungeon":
                AddDungeon1Strings();
                temp = Dungeon1Strings;
                break;
            case "StageTwoPointTwoLibrary":
                AddLibrary1Strings();
                temp = Library1Strings;
                break;
            case "StageThree":
                AddScene3Strings();
                temp = Scene3Strings;
                break;
            case "SceneFourPointOneDungeon":
                AddDungeon2Strings();
                temp = Dungeon2Strings;
                break;
            case "StageFourPointTwoLibrary":
                AddLibrary2Strings();
                temp = Library2Strings;
                break;
            case "StageFive":
                AddScene5Strings();
                temp = Scene5Strings;
                break;
        }
        return temp;
    }

    public static void AddScene0Strings()
    {
        //Scene5Strings.Clear();
        Scene0Strings = new List<string>();
        Scene0Strings.Add("Hi there, I'm Luther");
        Scene0Strings.Add("I’ve heard rumours someone has been sent to seek out the most valuable hidden stone, located here in my tower");
        Scene0Strings.Add("I must tell you I am forbidden from telling anyone where it is, but I may assist you on your quest, for I know this tower very well.");
        Scene0Strings.Add("Find me at any time if you need guidance, for I must warn you once you enter there is only one way out");
    }
    
    public static void AddScene1Strings()
    {
        if (Scene0Strings != null)
        {
            Scene0Strings.Clear();
        }
        Scene1Strings = new List<string>();
        Scene1Strings.Add("Welcome to my dining hall, they say this room was recreated as a trap to stop " +
            "trespassers from entering any further, but between you I I’ve seen the gate open after all hidden levers have been flipped");
        Scene1Strings.Add("Be warned once the gate has been lifted, there is no turning back");
    }

    public static void AddScene2Strings()
    {
        if (Scene1Strings != null)
        {
            Scene1Strings.Clear();
        }
        Scene2Strings = new List<string>();
        Scene2Strings.Add("Congratulations! You aren’t half bad at this. Now the tower gets a bit scary. Glad you brought a gun.");
        Scene2Strings.Add("Up there is the library, filled with the skeletons of travellers that came before you. " +
            "Down there is the dungeon, where even I dare not go, for there are ghosts not as friendly as I.");
        Scene2Strings.Add("Which do you choose? There's no turning back.");
    }

    public static void AddDungeon1Strings()
    {
        if (Scene2Strings != null)
        {
            Scene2Strings.Clear();
        }
        Dungeon1Strings = new List<string>();
        Dungeon1Strings.Add("2.2 was intented but not implemented fully");
        Dungeon1Strings.Add("You’ve entered the forbidden dungeon, Good luck but I’m definitely not coming in there with you...");
        Dungeon1Strings.Add("I hear the key to the chest you may be looking for lies right outside of these walls... If you can survive to get it...");
    }

    public static void AddLibrary1Strings()
    {
        if (Scene2Strings != null)
        {
            Scene2Strings.Clear();
        }
        Library1Strings = new List<string>();
        Library1Strings.Add("intention but not implemented fully");
        
    }

    public static void AddScene3Strings()
    {
        if (Dungeon1Strings != null || Library1Strings != null)
        {
            
        }
        Scene3Strings = new List<string>();
        Scene3Strings.Add("Glad you made it out alive. I think I see the key up ahead!");
    }

    public static List<string> AddAfterStage3KeyStrings()
    {
        AfterKeyScene3Strings = new List<string>();
        AfterKeyScene3Strings.Add("That's the key! now all that's left is to find the stone!");
        AfterKeyScene3Strings.Add("Up ahead is another split road. " +
            "On the left is a winding maze that may trap you for good.");
        AfterKeyScene3Strings.Add("On the right is a trap that even " +
            "I cannot get past alone. I hope you pick the right one...");
        return AfterKeyScene3Strings;
    }

    public static void AddDungeon2Strings()
    {
        if (Scene3Strings != null)
        {
            Scene3Strings.Clear();
        }
        Dungeon2Strings = new List<string>();
        Dungeon2Strings.Add("They caught me again! Please Nicolas, " +
            "protect me from them! I don’t want to be trapped here again!");
    }

    public static List<string> AddAfterEnemiesDeadDungeon2()
    {
        AfterEnemiesDeadDungeon2 = new List<string>();
        AfterEnemiesDeadDungeon2.Add("You’re really special Nicolas. " +
            "I owe you my life… or whatever is left of it.");
        AfterEnemiesDeadDungeon2.Add("We should be just about there, let’s keep going!");
        return AfterEnemiesDeadDungeon2;
    }

    public static void AddLibrary2Strings()
    {
        if (Scene3Strings != null)
        {
            Scene3Strings.Clear();
        }
        Library2Strings = new List<string>();
        Library2Strings.Add("Good luck getting out of this one. Many have tried, " +
            "but no one has successfully figured out this puzzle.");
        Library2Strings.Add("Fail and you’ll be trapped here forever. Good luck Nicolas");
    }

    public static List<string> AddAfterPuzzleSolvedLibrary2()
    {
        AfterPuzzleSolvedLibrary2 = new List<string>();
        AfterPuzzleSolvedLibrary2.Add("Impressive Nicolas, you’re more capable than I initially thought");
        AfterPuzzleSolvedLibrary2.Add("We should be just about there, let’s keep going!");
        return AfterPuzzleSolvedLibrary2;
    }

    public static List<string> AddAfterScrollFound()
    {
        AfterScrollFound = new List<string>();
        AfterScrollFound.Add("Oh no… that’s not just a treasure…");
        AfterScrollFound.Add("In the wrong hands, that stone could lay waste on the world…");
        AfterScrollFound.Add("You can’t possibly give that stone to Sebastiano… Not even for your brother’s life…");
        AfterScrollFound.Add("There’s no time to think! You need to get out of here!");
        return AfterScrollFound;
    }

    public static void AddScene5Strings()
    {
        if (Dungeon2Strings != null || Library2Strings != null)
        {
        }
        Scene5Strings = new List<string>();
        Scene5Strings.Add("Oh no looks like Sebastiano made it in the tower before you could escape, " +
            "defeat him to keep the stone from getting in the wrong hands!!");
    }
}
