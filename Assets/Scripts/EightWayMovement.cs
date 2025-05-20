
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EightWayMovement : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D rb;
    public Collider2D col;
    public Dialogue dialogue;
    public Floyd floyd;
    private Animator animator;

    private Vector2 movementInput;
    private Vector2 diagonal = - new Vector2(Mathf.Cos(30*Mathf.Rad2Deg), Mathf.Sin(30 * Mathf.Rad2Deg)).normalized;


    void Start()
    {
        animator = GetComponent<Animator>();


    }

    void Update()
    {
        if (!dialogue.inDialogue  && !floyd.inTransition)
        {

            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("x", movementInput.x);
            animator.SetFloat("y", movementInput.y);

            
            Vector2 direction = new Vector2(movementInput.x, movementInput.y);

            
            if (direction.x != 0 && direction.y != 0)
            {
                direction = diagonal * direction;
            }

           
            rb.velocity = new Vector2(direction.x, direction.y) * speed;
        }
        else {
            rb.velocity = new Vector2(0, 0);
            animator.SetFloat("x", 0);
            animator.SetFloat("y", 0);
        }

    }

}
