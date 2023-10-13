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

    public static float SoundVolume
    {
        get => PlayerPrefs.GetFloat("SoundVolumes", 0);
        set => PlayerPrefs.SetFloat("SoundVolumes", value);
    }

    public static int FirstTimeSound
    {
        get => PlayerPrefs.GetInt("FirstTimeSound", 0);
        set => PlayerPrefs.SetInt("FirstTimeSound", value);
    }
}