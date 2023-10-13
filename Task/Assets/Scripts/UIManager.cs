using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject layout;
    [SerializeField] private GameObject gameplay;
    [SerializeField] private GameObject gameComplete;

    [SerializeField] private GameObject soundOnImage;
    [SerializeField] private GameObject soundOffImage;

    [SerializeField] private Button restartBtn;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI comboText;
    // Start is called before the first frame update


    private void OnEnable()
    {
        GameplayEventSystem.OnEnableMainMenu += EnableMainMenu;
        GameplayEventSystem.OnDisableMainMenu += DisableMainMenu;
        GameplayEventSystem.OnEnableGameplay += EnableGameplay;
        GameplayEventSystem.OnDisableGameplay += DisableGameplay;
        GameplayEventSystem.OnEnableGameComplete += EnableGameComplete;
        GameplayEventSystem.OnDisableGameComplete += DisableGameComplete;
        GameplayEventSystem.OnEnableLayout += EnableLayout;
        GameplayEventSystem.OnDisableLayout += DisableLayout;
        GameplayEventSystem.OnEnableSoundOnImage += EnableSoundOnImage;
        GameplayEventSystem.OnDisableSoundOnImage += DisableSoundOnImage;
        GameplayEventSystem.OnEnableSoundOffImage += EnableSoundOffImage;
        GameplayEventSystem.OnDisableSoundOffImage += DisableSoundOffImage;
        GameplayEventSystem.OnEnableRestartBtnInteractable += EnableRestartInteractable;
        GameplayEventSystem.OnDisableRestartBtnInteractable += DisableRestartInteractable;
        GameplayEventSystem.OnEnableComboText += EnableComboText;
        GameplayEventSystem.OnDisableComboText += DisableComboText;
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
        GameplayEventSystem.OnEnableLayout -= EnableLayout;
        GameplayEventSystem.OnDisableLayout -= DisableLayout;
        GameplayEventSystem.OnEnableSoundOnImage -= EnableSoundOnImage;
        GameplayEventSystem.OnDisableSoundOnImage -= DisableSoundOnImage;
        GameplayEventSystem.OnEnableSoundOffImage -= EnableSoundOffImage;
        GameplayEventSystem.OnDisableSoundOffImage -= DisableSoundOffImage;
        GameplayEventSystem.OnEnableRestartBtnInteractable -= EnableRestartInteractable;
        GameplayEventSystem.OnDisableRestartBtnInteractable -= DisableRestartInteractable;
        GameplayEventSystem.OnEnableComboText -= EnableComboText;
        GameplayEventSystem.OnDisableComboText -= DisableComboText;
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
    
    private void EnableLayout()
    {
        layout.SetActive(true);
    }

    private void DisableLayout()
    {
        layout.SetActive(false);
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
    
    private void EnableRestartInteractable()
    {
        restartBtn.interactable = true;
    }

    private void DisableRestartInteractable()
    {
        restartBtn.interactable = false;
    }

    private void EnableComboText()
    {
        comboText.gameObject.SetActive(true);
    }

    private void DisableComboText()
    {
        comboText.gameObject.SetActive(false);
    }
    
    

    private void DisableAll()
    {
        DisableMainMenu();
        DisableGameplay();
        DisableGameComplete();
        DisableLayout();
    }

    private void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
