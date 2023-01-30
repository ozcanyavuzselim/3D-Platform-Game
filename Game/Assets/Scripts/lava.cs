using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu sınıf, lava nesnesinin oyuncu ile etkileşimini kontrol eder
public class lava : MonoBehaviour
{
    // Oyuncu nesne ile temas ettiğinde çalışan fonksiyon
    private void OnTriggerEnter(Collider other)
    {
        // Eğer oyuncu nesnesiyle temas etti ise
        if (other.CompareTag("Player"))
        {
            // Oyuncunun ölmesini sağlayan fonksiyon çağrılır
            other.GetComponent<PlayerManager>().Death();
        }
    }
}
