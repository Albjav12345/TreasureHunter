using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public GroundCheck groundCheck;
    Rigidbody2D rigidbodyrb;
    public Animator animator;

    private void Start()
    {
        rigidbodyrb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        // Física del movimiento horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        rigidbodyrb.velocity = new Vector2(horizontalInput * speed, rigidbodyrb.velocity.y);

        // Si va hacia la DERECHA...
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // No se produce ninguna inversión en la escala
            animator.SetBool("isWalking", true);
        }
        // Si va haciala IZQUIERDA...
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Se invierte horizontalmente la escala
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }


    void Jump()
    {
        // Físicas del salto
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.puedeSaltar == true)
        {
            rigidbodyrb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        //Animaciones del salto en funcion de si sube o cae
        if (rigidbodyrb.velocity.y > 0 && groundCheck.puedeSaltar == false)
        {
            animator.SetBool("isJumping", true);
        }
        else if (rigidbodyrb.velocity.y < 0 && groundCheck.puedeSaltar == false)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
