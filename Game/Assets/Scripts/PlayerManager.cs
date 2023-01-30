using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool player_alive = true;// Oyuncunun hayatta olup olmadığını kontrol eden değişken
    public GameObject death_effect;// Oyuncunun ölüm animasyonu

    public GameObject hand; // Oyuncunun el objesi
    public GameObject crosshiat; // Oyuncunun nişan alıcısı
    public GameObject gameover; // Oyun bitti ekranı
    public PauseMenu pauseMenu; // Oyun duraklatma menüsü

    public void Death()
    {
        if (player_alive)
        {
            // boolean değişkenini set et
            player_alive = false;

            player_alive = false;

            // Duraklatma menüsünü devre dışı bırak
            pauseMenu.isGameOver = true;

            // Parçacık efekti oluştur
            Instantiate(death_effect, transform.position, Quaternion.identity);

            // Oyuncuyu devre dışı bırak
            GetComponent<PlayerMovement>().enabled = false;
            hand.SetActive(false);
            crosshiat.SetActive(false);

            // Fare görünür ve kilitleme yapılmaz
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Oyun bitti ekranını aktifleştir
            gameover.SetActive(true);
        }
    }
}
