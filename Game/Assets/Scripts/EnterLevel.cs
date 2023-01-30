using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public LevelManager lm;
    public bool enter;

    // Collider'a giriş yapıldığında tetiklenir
    private void OnTriggerEnter(Collider other)
    {
        // Eğer giriş yapılması isteniyorsa
        if (enter)
        {
            lm.player_enter = true;
            lm.player_exit = true;
        }
        // Eğer giriş yapılmaması isteniyorsa
        else
        {
            lm.player_enter = false;
            lm.player_exit = false;
        }
    }
}
