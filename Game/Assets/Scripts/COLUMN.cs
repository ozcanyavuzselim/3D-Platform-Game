using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Uçan platformların kontrol scripti
public class COLUMN : MonoBehaviour
{
    // oyuncunun durumunu kontrol etmek için bir transform
    public Transform chacker;
    public LayerMask player_layer;

    public float radius;

    public Vector3 velocity;
    // kolonun kırılıp kırılmadığını kontrol etmek için bool
    private bool broke = false;
    private void Update()
    {
        // eğer oyuncu tracker'ın yerine ulaşırsa
        if (Physics.CheckBox(chacker.position, new Vector3(radius, 2, radius), Quaternion.identity, player_layer)) 
        {
            broke = true;
        }
        // kolon düşüşmesi için
        if (broke)
        {
            velocity.z -= Time.deltaTime / 200;
            transform.Translate(velocity);
        }
    }
}
