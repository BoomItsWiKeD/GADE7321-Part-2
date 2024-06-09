using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject difficultyOptions;
    public GameObject mainScreen;
    public void onMultiplayerClick()
    {
        SceneManager.LoadScene("HotSeat");
    }

    public void onSingleplayerClick()
    {
        difficultyOptions.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void onBackClick()
    {
        difficultyOptions.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void onEasyClick()
    {
        SceneManager.LoadScene("Easy");
    }
    
    public void onMediumClick()
    {
        SceneManager.LoadScene("Medium");
    }
    
    public void onHardClick()
    {
        SceneManager.LoadScene("Hard");
    }
    

    public void onExitClick()
    {
        Application.Quit();
    }
    
}
