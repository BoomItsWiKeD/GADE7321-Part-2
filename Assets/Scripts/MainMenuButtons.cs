using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void onMultiplayerClick()
    {
        SceneManager.LoadScene("HotSeat");
    }

    public void onSingleplayerClick()
    {
        SceneManager.LoadScene("Singleplayer");
    }

    public void onExitClick()
    {
        Application.Quit();
    }
    
}
