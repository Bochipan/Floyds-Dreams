using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float turnSpeed = 20f;

    public Animator animator;
    public Rigidbody rb;

    public Vector3 offset;
    Quaternion rotation = Quaternion.identity;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 forwardRelativeVerticalInput = vertical * forward;
        Vector3 rightRelativeHorizontalInput = horizontal * right;
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;


        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        animator.SetBool("Walk", isWalking);


        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, 
                cameraRelativeMovement, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);
        if (isWalking == false)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else {
            rb.MovePosition(cameraRelativeMovement);
            transform.Translate(cameraRelativeMovement * moveSpeed, Space.World);
            rb.MoveRotation(rotation);
        }
    }
}
