using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit; // nesnelere çarptığında veri tutmak için kullanılan değişken
    public LayerMask obstacle , player_layer;// çarpma kontrolü için kullanılan katmanlar

    private void Update()
    { // Nesne önünde bir engele çarptıysa
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, obstacle))
        {
            // LineRenderer aktif olacak
            GetComponent<LineRenderer>().enabled = true;

            // LineRenderer'ın pozisyonları belirleniyor
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            // LineRenderer'ın genişliği animasyonlu olarak belirleniyor
            GetComponent<LineRenderer>().startWidth = 0.05f + Mathf.Sin(Time.time * 3) / 80;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;// LineRenderer pasif olacak
        }

        // Oyuncuya çarptıysa oyuncunun ölmesi sağlanıyor
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, player_layer))
        {
            hit.transform.gameObject.GetComponent<PlayerManager>().Death();
        }
    }
}
