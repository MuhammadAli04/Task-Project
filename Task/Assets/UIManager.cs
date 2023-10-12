using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameplay;

    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update


    private void OnEnable()
    {
        GameplayEventSystem.OnEnableMainMenu += EnableMainMenu;
        GameplayEventSystem.OnDisableMainMenu += DisableMainMenu;
        GameplayEventSystem.OnEnableGameplay += EnableGameplay;
        GameplayEventSystem.OnDisableGameplay += DisableGameplay;
        GameplayEventSystem.OnDisableAll += DisableAll;
        GameplayEventSystem.OnUpdateScoreText += UpdateScore;
    }
    
    private void OnDisable()
    {
        GameplayEventSystem.OnEnableMainMenu -= EnableMainMenu;
        GameplayEventSystem.OnDisableMainMenu -= DisableMainMenu;
        GameplayEventSystem.OnEnableGameplay -= EnableGameplay;
        GameplayEventSystem.OnDisableGameplay -= DisableGameplay;
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

    private void DisableAll()
    {
        DisableMainMenu();
        DisableGameplay();
    }

    private void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
