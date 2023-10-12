using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameplayEventSystem : MonoBehaviour
{
    public static GameplayEventSystem Instance;

    public event Action OnSetRowsValue;

    public void SetRowsValue()
    {
        OnSetRowsValue?.Invoke();
    }

    public event Action OnSetColumnsValue;

    public void SetColumnsValue()
    {
        OnSetColumnsValue?.Invoke();
    }
}
