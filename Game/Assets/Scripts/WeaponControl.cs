using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    //Engel
    public GameObject hand;
    public LayerMask obstacleLayer;
    public Vector3 offset;

    RaycastHit hit;

    //mermi
    public GameObject buller;
    public Transform firePoint;

    public AudioClip gunshot;
    private float cooldawn;
    void Update()
    {
        // Bakma
     // Main kameradan engellere doğru bir raycast atıyor ve engele çarpıp çarpmadığını kontrol ediyor
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obstacleLayer)) 
        {
            hand.transform.LookAt(hit.point);
            hand.transform.rotation *= Quaternion.Euler(offset);
        }

        //Cooldawn
        // Eğer soğutma süresi sıfırdan büyükse, zaman geçtikçe azaltıyor
        if (cooldawn > 0)
        {
            cooldawn -= Time.deltaTime;
        }
        // Atış
        if (Input.GetMouseButtonDown(0) && cooldawn <= 0)
        {
            // Mermi oluşturma
            Instantiate(buller, firePoint.position, transform.rotation * Quaternion.Euler(0, -90, 0));
            //cooldawn süresini sıfırla
            cooldawn = 0.25f;

            // Ses efekti
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunshot);
        }
        // Animasyon
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetTrigger("shot");
        }
 
    }
}
