using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Bu sýnýf oyun baþlamadan önce ayarlarý yükler.
public class StartUp : MonoBehaviour
{
    //Fare hassasiyetini ayarlamak için kullanýlan slider.
    public Slider mouse_slider;

    //Oyun baþlamadan önce çalýþacak fonksiyon.
    private void Awake()
    {
        //Fare hassasiyetini ayarla
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mauseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 10);

        //Slider deðerini kaydedilmiþ deðere göre ayarla
        mouse_slider.value = PlayerPrefs.GetFloat("MouseSensitivity", 10);

    }
}
