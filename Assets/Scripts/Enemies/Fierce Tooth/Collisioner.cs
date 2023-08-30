using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisioner : MonoBehaviour
{
    public bool collisioner = true;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            collisioner = !collisioner;
            print("Ha chocado con muro");
        }
    }
}
