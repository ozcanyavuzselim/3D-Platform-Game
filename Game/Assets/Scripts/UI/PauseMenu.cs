using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Oyun duraklatma, devam ettirme, çýkýþ ve ana menü iþlemlerini yöneten script.
public class PauseMenu : MonoBehaviour
{
    private bool isGamePause = false;
    public GameObject pausmenu;

    public bool isGameOver = false;

    public GameObject player, pistol;
    public AudioSource music;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !isGameOver)
        {
            if (!isGamePause)
            {
                Pause();
            }
            else 
            {
                Resume();
            }
        }
    }

    // Oyunu duraklatan fonksiyonu
    private void Pause()
    {
        //Set Time Scale
        Time.timeScale = 0;

        music.Pause();

        //Disable PlayerMovement
        player.GetComponent<PlayerMovement>().enabled = false;
        pistol.GetComponent<WeaponControl>().enabled = false;

        //Set Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //Pause Menu
        pausmenu.SetActive(true);

        //Set Boolean
        isGamePause = true;
    }
    private void Resume()
    {
        //Set Time Scale
        Time.timeScale = 1;

        music.UnPause();

        //Enable PlayerMovement
        player.GetComponent<PlayerMovement>().enabled = true;
        pistol.GetComponent<WeaponControl>().enabled = true;

        //Set Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //Pause Menu
        pausmenu.SetActive(false);
        
        //Set boolean
        isGamePause = false;

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("mein_menu");
    }
}
