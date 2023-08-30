using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingParticles : MonoBehaviour
{
    public float lifetime = 1f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
