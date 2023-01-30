using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    // Oyuncunun pozisyonunu tutacak değişken
    private Transform player;

    //Dron ile ilgili değişken ve atamalar
    public float speed = 1f;
    public float follow_distance = 10f;

    public GameObject death_effect;

    public AudioClip death_saund;

    public float cooldown = 2f;

    public float health = 100f;

    public GameObject mesh;
    public GameObject bullet;

    // Awake metodu çalıştırılırken oyuncunun pozisyonunu buluyor
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Followplayer();// Oyuncuya takip etme fonksiyonunu çalıştırır
        shot(); // Drone'un ateş etme fonksiyonunu çalıştırır
        Death();// Drone'un ölüm kontrolünü yapar
    }

    // Oyuncuya takip etme fonksiyonu
    private void Followplayer()
    {
        // Drone'un oyuncuya bakmasını sağlar
        transform.LookAt(player.position);
        // Drone'un rotasyonunu ayarlar
        transform.rotation *= Quaternion.Euler(new Vector3(-90, 0, 90));

        // Drone'un oyuncuya olan mesafesi belirlenen takip mesafesinden büyükse Drone oyuncuya doğru hareket eder
        if (Vector3.Distance(transform.position, player.position) >= follow_distance) 
            transform.Translate(Vector3.right * Time.deltaTime * speed *-1);
        // Drone'un oyuncuya olan mesafesi belirlenen takip mesafesinden küçükse Drone oyuncu etrafında döner
        else
            transform.RotateAround(player.position, transform.forward, Time.deltaTime * speed * Random.Range(0.2f, 3f));       
    }
    //ateş etme sistemini ayarlayan fonksiyon
    private void shot()
    {
        // Eğer cooldown süresi sıfırdan büyükse cooldown süresini azalt
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
        else
        {
            // cooldown süresini sıfırla
            cooldown = 2f;
            // Atış yap
            mesh.GetComponent<Animator>().SetTrigger("shot");
            GameObject gameObject1 = Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0)) );
        }
    }

    //oldürme fonksiyonu
    private void Death()
    {
       
        if(health <= 0)
        {

            // Partikül üret
            Instantiate(death_effect, transform.position, Quaternion.identity);

            // Ses efekti oynat
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(death_saund);

            // GameObject'i yok et
            Destroy(this.gameObject);
        }
    }


}