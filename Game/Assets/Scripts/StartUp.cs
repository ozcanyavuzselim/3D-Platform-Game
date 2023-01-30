using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Bu s�n�f oyun ba�lamadan �nce ayarlar� y�kler.
public class StartUp : MonoBehaviour
{
    //Fare hassasiyetini ayarlamak i�in kullan�lan slider.
    public Slider mouse_slider;

    //Oyun ba�lamadan �nce �al��acak fonksiyon.
    private void Awake()
    {
        //Fare hassasiyetini ayarla
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mauseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 10);

        //Slider de�erini kaydedilmi� de�ere g�re ayarla
        mouse_slider.value = PlayerPrefs.GetFloat("MouseSensitivity", 10);

    }
}
