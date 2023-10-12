using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    public static int Score
    {
        get => PlayerPrefs.GetInt("Score", 0);
        set => PlayerPrefs.SetInt("Score", value);
    }
    
}