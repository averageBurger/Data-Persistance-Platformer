using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class MainManager
{
    public static int coins = 0;

    public static List<Color> colourArray;
    public static Color currentColour;

    public static bool hasLoaded = false;

    static void Awake()
    {
        colourArray.Add(Color.white);
    }
}
