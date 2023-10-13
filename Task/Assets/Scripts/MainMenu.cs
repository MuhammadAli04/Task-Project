using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Layout _layout;
    // Start is called before the first frame update
    void Start()
    {
       GameplayEventSystem.DisableAll();
       GameplayEventSystem.EnableMainMenu();
    }

    public void LayoutBtn(int id)
    {
        switch (id)
        {
            case 1:
                _layout = Layout.Layout2X2;
                break;
            case 2:
                _layout = Layout.Layout2X3;
                break;
            case 3:
                _layout = Layout.Layout5X6;
                break;
        }
        GameplayEventSystem.DisableAll();
        GameplayEventSystem.EnableGameplay();
        GameplayEventSystem.SetLayout(_layout);
        GameplayEventSystem.GameStart();
    }

    public void PlayBtn()
    {
        GameplayEventSystem.DisableAll();
        GameplayEventSystem.EnableLayout();
    }

    public void RestartBtn()
    {
        //Prefs.Score = 0;
        //GameplayEventSystem.ResetCardState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void MainMenuBtn()
    {
        Prefs.Score = 0;
        GameplayEventSystem.ResetCardState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

  
}
