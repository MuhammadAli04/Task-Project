using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletePanel : MonoBehaviour
{
    private void OnEnable()
    {
        SoundPlayer.Instance.PlayLevelCompleteSound();
    }
}
