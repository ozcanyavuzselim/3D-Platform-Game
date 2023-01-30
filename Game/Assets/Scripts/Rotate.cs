using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rotasyonu yapmak için kullanılan script.
public class Rotate : MonoBehaviour
{
    // Rotasyonu yapmak için kullanılacak eksen.
    public Vector3 rotateAxis;
    public float speed = 1;

    private void Update()
    {
        // Transform objesi rotasyonu yapar.
        transform.Rotate(rotateAxis * speed * Time.deltaTime);
    }
}
