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

    public static event Action OnLoadCard;

    public static void LoadCard()
    {
        OnLoadCard?.Invoke();
    }

    public static event Action OnGameStart;

    public static void GameStart()
    {
        OnGameStart?.Invoke();
    }

    public static event Action<Layout> OnSetLayout;

    public static void SetLayout(Layout lo)
    {
        OnSetLayout?.Invoke(lo);
    }

    public static event Action OnEnableMainMenu;

    public static void EnableMainMenu()
    {
        OnEnableMainMenu?.Invoke();
    }

    public static event Action OnDisableMainMenu;

    public static void DisableMainMenu()
    {
        OnDisableMainMenu?.Invoke();
    }

    public static event Action OnEnableLayout;
    public static void EnableLayout()
    {
        OnEnableLayout?.Invoke();
    }

    public static event Action OnDisableLayout;

    public static void DisableLayout()
    {
        OnDisableLayout?.Invoke();
    }

    public static event Action OnEnableGameplay;

    public static void EnableGameplay()
    {
        OnEnableGameplay?.Invoke();
    }

    public static event Action OnDisableGameplay;

    public static void DisableGameplay()
    {
        OnDisableGameplay?.Invoke();
    }

    public static event Action OnEnableGameComplete;

    public static void EnableGameComplete()
    {
        OnEnableGameComplete?.Invoke();
    }

    public static event Action OnDisableGameComplete;

    public static void DisableGameComplete()
    {
        OnDisableGameComplete?.Invoke();
    }

    public static event Action OnEnableSoundOnImage;

    public static void EnableSoundOnImage()
    {
        OnEnableSoundOnImage?.Invoke();
    }

    public static event Action OnDisableSoundOnImage;

    public static void DisableSoundOnImage()
    {
        OnDisableSoundOnImage?.Invoke();
    }
    
    public static event Action OnEnableSoundOffImage;

    public static void EnableSoundOffImage()
    {
        OnEnableSoundOffImage?.Invoke();
    }

    public static event Action OnDisableSoundOffImage;

    public static void DisableSoundOffImage()
    {
        OnDisableSoundOffImage?.Invoke();
    }

    public static event Action OnEnableRestartBtnInteractable;

    public static void EnableRestartBtnInteractable()
    {
        OnEnableRestartBtnInteractable?.Invoke();
    }
    
    public static event Action OnDisableRestartBtnInteractable;

    public static void DisableRestartBtnInteractable()
    {
        OnDisableRestartBtnInteractable?.Invoke();
    }

    public static event Action OnEnableComboText;

    public static void EnableComboText()
    {
        OnEnableComboText?.Invoke();
    }

    public static event Action OnDisableComboText;

    public static void DisableComboText()
    {
        OnDisableComboText?.Invoke();
    }

    public static event Action OnDisableAll;

    public static void DisableAll()
    {
        OnDisableAll?.Invoke();
    }

    public static event Action<int> OnUpdateScoreText;

    public static void UpdateScoreText(int score)
    {
        OnUpdateScoreText?.Invoke(score);
    }

    public static event Action OnResetCardState;

    public static void ResetCardState()
    {
        OnResetCardState?.Invoke();
    }
    
    

    
}
