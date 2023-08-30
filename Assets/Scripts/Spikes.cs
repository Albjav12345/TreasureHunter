using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float impulse = 10f;

    public Animator playerAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, impulse);

            Player player = collision.GetComponent<Player>();
            player.health --;
            print("Tu vida es: " + player.health);
            playerAnimator.SetBool("isHitted", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAnimator.SetBool("isHitted", false);
        }
    }
}
