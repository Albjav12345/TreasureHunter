using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRange : MonoBehaviour
{
    public bool detectionRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectionRange = true;
            print("Zona de enemigo");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectionRange = false;
            print("Fuera de rango");
        }
    }
}
