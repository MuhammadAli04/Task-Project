using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboText : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(DisableText),1);
    }

    private void DisableText()
    {
        gameObject.SetActive(false);
    }
}
