using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Restart_btn()
    {
        SceneManager.LoadScene("yeni oyun");
    }

    public void MainMenu_btn()
    {
        SceneManager.LoadScene("mein_menu");
    }
    
    public void Exit_btn()
    {
        Application.Quit();
    }
}
