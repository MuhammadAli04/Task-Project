using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameplay;
    [SerializeField] private GameObject gameComplete;

    [SerializeField] private GameObject soundOnImage;
    [SerializeField] private GameObject soundOffImage;

    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update


    private void OnEnable()
    {
        GameplayEventSystem.OnEnableMainMenu += EnableMainMenu;
        GameplayEventSystem.OnDisableMainMenu += DisableMainMenu;
        GameplayEventSystem.OnEnableGameplay += EnableGameplay;
        GameplayEventSystem.OnDisableGameplay += DisableGameplay;
        GameplayEventSystem.OnEnableGameComplete += EnableGameComplete;
        GameplayEventSystem.OnDisableGameComplete += DisableGameComplete;
        GameplayEventSystem.OnEnableSoundOnImage += EnableSoundOnImage;
        GameplayEventSystem.OnDisableSoundOnImage += DisableSoundOnImage;
        GameplayEventSystem.OnEnableSoundOffImage += EnableSoundOffImage;
        GameplayEventSystem.OnDisableSoundOffImage += DisableSoundOffImage;
        GameplayEventSystem.OnDisableAll += DisableAll;
        GameplayEventSystem.OnUpdateScoreText += UpdateScore;
    }
    
    private void OnDisable()
    {
        GameplayEventSystem.OnEnableMainMenu -= EnableMainMenu;
        GameplayEventSystem.OnDisableMainMenu -= DisableMainMenu;
        GameplayEventSystem.OnEnableGameplay -= EnableGameplay;
        GameplayEventSystem.OnDisableGameplay -= DisableGameplay;
        GameplayEventSystem.OnEnableGameComplete -= EnableGameComplete;
        GameplayEventSystem.OnDisableGameComplete -= DisableGameComplete;
        GameplayEventSystem.OnEnableSoundOnImage -= EnableSoundOnImage;
        GameplayEventSystem.OnDisableSoundOnImage -= DisableSoundOnImage;
        GameplayEventSystem.OnEnableSoundOffImage -= EnableSoundOffImage;
        GameplayEventSystem.OnDisableSoundOffImage -= DisableSoundOffImage;
        GameplayEventSystem.OnDisableAll -= DisableAll;
        GameplayEventSystem.OnUpdateScoreText -= UpdateScore;
    }

    private void EnableMainMenu()
    {
        mainMenu.SetActive(true);
    }

    private void DisableMainMenu()
    {
        mainMenu.SetActive(false);
    }

    private void EnableGameplay()
    {
        gameplay.SetActive(true);
    }

    private void DisableGameplay()
    {
        gameplay.SetActive(false);
    }

    private void EnableGameComplete()
    {
        gameComplete.SetActive(true);
    }

    private void DisableGameComplete()
    {
        gameComplete.SetActive(false);
    }

    private void EnableSoundOnImage()
    {
        soundOnImage.SetActive(true);
    }

    private void DisableSoundOnImage()
    {
        soundOnImage.SetActive(false);
    }

    private void EnableSoundOffImage()
    {
        soundOffImage.SetActive(true);
    }

    private void DisableSoundOffImage()
    {
        soundOffImage.SetActive(false);
    }
    
    

    private void DisableAll()
    {
        DisableMainMenu();
        DisableGameplay();
        DisableGameComplete();
    }

    private void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
