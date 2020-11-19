using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class LeverController
{
    private static List<GameObject> LeverALgameObj = new List<GameObject>();
    private static List<LeverFlip> leverALcsFile = new List<LeverFlip>();


    public static void addLever(GameObject go, LeverFlip lf)
    {
        LeverALgameObj.Add(go);
        leverALcsFile.Add(lf);

    }

    public static bool getStateOfLever(string name)
    {
        bool temp = false;
        for (int i = 0; i < LeverALgameObj.Count; i++)
        {
            if (LeverALgameObj[i].name == name)
            {
                temp = leverALcsFile[i].getFlipped();
                break;
            }
        }
        return temp;
    }

    public static void flipLever(GameObject go)
    {
        int temp = -1;

        for (int i = 0; i < LeverALgameObj.Count; i++)
        {
            if (LeverALgameObj[i].name == go.name)
            {
                temp = i;
            }
        }
        if (temp != -1)
        {
            LeverFlip tempLF = leverALcsFile[temp];
            tempLF.FlipLever();
        }
    }

    public static bool checkAll(List<LeverFlip> t)
    {
        bool temp = true;
        foreach (LeverFlip i in t)
        {
            if (i.getFlipped() == false)
            {
                temp = false;
            }
        }
        return temp;
    }

    public static void changedScene()
    {
        leverALcsFile.Clear();
        LeverALgameObj.Clear();
    }
}
