using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightWayMovement : MonoBehaviour
{

    public float speed = 5f; // Movement speed
    public float diagonalAngle = -30f; // Angle for diagonal movement (in degrees)
    public Animator animator;

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

        // Calculate movement direction based on input
        Vector2 direction = new Vector2(movementInput.x, movementInput.y);

        // Adjust diagonal direction
        if (direction.x != 0 && direction.y != 0)
        {
   
            direction = diagonal * direction;
            
        }

        //Do we flip the character animation?

        //this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        // Move the character
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
}
