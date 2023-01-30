using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Mermi hızı
    public float speed = 100f;
    //Düşman mermisi mi?
    public bool enemy_bullet = false;
    public float bullet_radius = 0.5f;
    public LayerMask player_layer;
    //Ses efekti
    public AudioClip hir_sound;
    //Vuruş efekti
    public GameObject hit_effect;
    //Can
    public float lifetime = 5f;

    //Her frame güncellenir
    void Update()
    {
        transform.Translate(Vector3.forward * 1 * Time.deltaTime * speed);
        lifetime -= Time.deltaTime;

        //Ömür süresi bittiyse mermiyi yok et
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }

        //Düşman mermisi
        if (enemy_bullet)

        {   //Oyunculara çarptı mı kontrol et
            if (Physics.CheckSphere(transform.position, bullet_radius, player_layer))
            {
                //Oyuncuları öldür
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            }
        }
    }

    //Trigger alanına girdiğinde tetiklenir
    private void OnTriggerEnter(Collider other)
    {
        //Eğer hedef düşman ise
        if (other.CompareTag("Enemy"))
        {
            GameObject drone = other.transform.parent.gameObject;
            drone.GetComponent<Drone>().health -= 25;
            drone.GetComponent<AudioSource>().PlayOneShot(hir_sound);
        }

        //Vuruş efekti oluştur
        Instantiate(hit_effect, transform.position, Quaternion.Euler(new Vector3(0, -180, 0)));
        //Mermiyi yok et
        Destroy(this.gameObject);
    
    }

}
