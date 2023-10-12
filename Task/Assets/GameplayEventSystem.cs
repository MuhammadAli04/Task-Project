using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public static class GameplayEventSystem
{


    public static event Action<Card> OnCardFlipped;

    public static void CardFlipped(Card c)
    {
        OnCardFlipped?.Invoke(c);
    }

    public static event Action<int> OnSetCardId;

    public static void SetCardId(int id)
    {
        OnSetCardId?.Invoke(id);
    }
}
