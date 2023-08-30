using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool puedeSaltar;

    public GameObject landingParticles;
    public GameObject jumpingParticles;
    public Animator playerAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("JumpableObject"))
        {
            puedeSaltar = true;
            playerAnimator.SetBool("isFalling", false);
        }
        // Instanciar particulas de caida
        Instantiate(landingParticles, transform.position, Quaternion.identity);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("JumpableObject"))
        {
            puedeSaltar = false;
        }
        // Instanciar particulas de salto
        if (Input.GetKey(KeyCode.Space) && !collision.CompareTag("Spike"))
        {
            Instantiate(jumpingParticles, transform.position, Quaternion.identity);
        }
    }
}
