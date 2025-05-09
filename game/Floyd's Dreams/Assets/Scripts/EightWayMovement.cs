using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightWayMovement : MonoBehaviour
{

    public float speed = 5f; // Movement speed
    public float diagonalAngle = -30f; // Angle for diagonal movement (in degrees)
    public Rigidbody2D rb;
    public GameObject[] tp;
    public Collider2D col;
    public Collider2D[] puertas;
    private Animator animator;
    public Dialogue dialogueBox;
    public SpriteFade fade;


    private Vector2 movementInput;
    private Vector2 diagonal = - new Vector2(Mathf.Cos(30*Mathf.Rad2Deg), Mathf.Sin(30 * Mathf.Rad2Deg)).normalized;
    public bool inTransition = false;


    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        if (dialogueBox.inDialogue == false && !inTransition)
        {

            // Get input
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("x", movementInput.x);
            animator.SetFloat("y", movementInput.y);

            // Calculate movement direction based on input
            Vector2 direction = new Vector2(movementInput.x, movementInput.y);

            // Adjust diagonal direction
            if (direction.x != 0 && direction.y != 0)
            {
                direction = diagonal * direction;
            }

            // Move the character
            rb.velocity = new Vector2(direction.x, direction.y) * speed;
        }
        else {
            rb.velocity = new Vector2(0, 0);
            animator.SetFloat("x", 0);
            animator.SetFloat("y", 0);
        }

 

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Puerta7" || collision.name == "Final" || collision.name == "Puerta9")
        {

            fade.Fade();
            inTransition = true;
        }
        for (int i = 0; i < tp.Length; i++)
        {
            if (collision == puertas[i]) {
                transform.position = tp[i].transform.position;     
            }
        }
    }


}
