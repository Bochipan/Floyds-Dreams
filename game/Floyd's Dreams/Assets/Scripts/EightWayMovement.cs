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


    private Vector2 movementInput;
    private Vector2 diagonal = - new Vector2(Mathf.Cos(30*Mathf.Rad2Deg), Mathf.Sin(30 * Mathf.Rad2Deg)).normalized;


    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
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
     
         //transform.position += (Vector3)direction * speed * Time.deltaTime;
         rb.velocity = new Vector2 (direction.x, direction.y) * speed;
         
 

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == puertas[0]) { 
            transform.position = tp[0].transform.position;
        }
        else if (collision == puertas[1])
        {
            transform.position = tp[1].transform.position;
        }
        else if (collision == puertas[2])
        {
            transform.position = tp[2].transform.position;
        }
    }
}
