using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MeinMenuscrpit : MonoBehaviour
{
   public void Play_btn()
    {
        SceneManager.LoadScene("yeni oyun");
    }


    public void Exit_btn()
    {
        Application.Quit();
    }
   
}
