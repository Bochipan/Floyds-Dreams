using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float turnSpeed = 20f;

    public Animator animator;
    public Rigidbody Rrigidbody;

    Vector3 movement;
    public Vector3 offset;
    Quaternion rotation = Quaternion.identity;

    void Start()
    {
        animator = GetComponent<Animator>();
        Rrigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");



        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        animator.SetBool("Walk", isWalking);


        Vector3 desiredForward = Vector3.RotateTowards(transform.forward,movement, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);
        if (isWalking == false)
        {
            //Rrigidbody.velocity = Vector3.zero;
            //Rrigidbody.angularVelocity = Vector3.zero;
        }



    }
    void OnAnimatorMove()
    {
        Rrigidbody.MovePosition(Rrigidbody.position +movement * moveSpeed);
        Rrigidbody.MoveRotation(rotation);
    }

}
