using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightWayMovement : MonoBehaviour
{

    public float speed = 5f; // Movement speed
    public float diagonalAngle = -30f; // Angle for diagonal movement (in degrees)
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
     
         transform.position += (Vector3)direction * speed * Time.deltaTime;
 

    }
    //private void OnCollisionEnter(Collision collision){
    //}
}
