using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //player enter-exit
    public bool player_enter, player_exit;

    //drone spawn
    private bool spawned = false;

    public Transform[] drone_spawners;
    public GameObject drone;

    //spawn level
    public GameObject level;
    public GameObject destroy_level;

    // Oyun başlamadan önce
    private void Awake()
    {
        player_enter = false;
        spawned = false;
        player_exit = false;
    }

    private void Update()
    {

        // Eğer drone henüz yapılmamışsa 
        if (!spawned)
        {
            if (player_enter)
            {
                // drone spawn
                for (int i = 0; i < drone_spawners.Length; i++)
                {
                    Instantiate(drone, drone_spawners[i].position, Quaternion.identity);
                    
                }

                //level spawn
                spawnLevel();

                //set bool
                spawned = true;
            }
        }
        // Eğer oyuncu düzeyden çıktıysa
        if (player_exit)
        {
            if (destroy_level != null) 
            {
                Destroy(destroy_level);
            }
        }
    }

    // Düzey yapma metodu
    private void spawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x + 200, transform.position.y +1, transform.position.z);
        GameObject obj= Instantiate(level, pos, Quaternion.identity);
        obj.GetComponent<LevelManager>().destroy_level = this.gameObject;
    }


}
