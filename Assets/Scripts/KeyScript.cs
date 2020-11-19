using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class KeyScript
{
    private static List<GameObject> keyObjs = new List<GameObject>();
    private static List<Keys> keyScripts = new List<Keys>();
    private static List<string> keyTags = new List<string>();

    public static void addKey(string tag, Keys k)
    {
        keyObjs.Add(k.gameObject);
        keyScripts.Add(k);
        keyTags.Add(tag);
    }

    public static bool getKeyResponse(Keys k)
    {
        return k.inInventory;
    }
}
