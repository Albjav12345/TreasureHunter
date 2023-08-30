using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FierceTooth : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float preAttackTime;
    
    private Animator animator;
    private Rigidbody2D rb;
    private Transform enemyTransform;

    public GameObject interrogation;
    public Collisioner collisioner;
    public DetectionRange detector;
    public Transform playerTransform;

    private void Start()
    {
        interrogation.SetActive(false);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemyTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (detector.detectionRange == true)
        {
            animator.SetBool("FiercePreAttack", true);
            interrogation.SetActive(true);
            Invoke("TrackPlayer", preAttackTime);
            animator.SetBool("FiercePreAttack", false);
        }
        else
        {
            Move();
        }
    }
    private void Move()
    {
        if (collisioner.collisioner == false)
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            enemyTransform.localScale = new Vector3(-1f, enemyTransform.localScale.y, enemyTransform.localScale.z);
        }
        else
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            enemyTransform.localScale = new Vector3(1f, enemyTransform.localScale.y, enemyTransform.localScale.z);
        }
    }

    private void TrackPlayer()
    {
        interrogation.SetActive(false);
        if (playerTransform == null)
        {
            Debug.LogWarning("Player transform reference is missing!");
            return;
        }

        // Obtener la posición del jugador
        Vector3 playerPosition = playerTransform.position;

        // Calcular la nueva posición hacia la cual moverse
        Vector3 targetPosition = new Vector3(playerPosition.x, enemyTransform.position.y, enemyTransform.position.z);

        // Mover gradualmente hacia la posición del jugador
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, targetPosition, movementSpeed * Time.deltaTime);

        // Invertir la escala en función de la dirección del movimiento
        if (playerPosition.x > enemyTransform.position.x)
        {
            enemyTransform.localScale = new Vector3(-1f, enemyTransform.localScale.y, enemyTransform.localScale.z);
        }
        else if (playerPosition.x < enemyTransform.position.x)
        {
            enemyTransform.localScale = new Vector3(1f, enemyTransform.localScale.y, enemyTransform.localScale.z);
        }
    }
}