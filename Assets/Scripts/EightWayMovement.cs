using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EightWayMovement : MonoBehaviour
{

    public float speed = 5f; // Movement speed
    public Rigidbody2D rb;
    public GameObject[] tp;
    public Collider2D col;
    public Collider2D[] puertas;
    private Animator animator;
    public SpriteFade fade;
    public Light light1;
    public Light light2;

    public string[] atworkLines;
    public GameObject dialoguebox;
    public Dialogue dialogue;

    private Vector2 movementInput;
    private Vector2 diagonal = - new Vector2(Mathf.Cos(30*Mathf.Rad2Deg), Mathf.Sin(30 * Mathf.Rad2Deg)).normalized;
    public bool inTransition = false;
    private string[] longPortals = new string[6] { "Puerta7", "Puerta9", "Puerta6", "Puerta8", "Puerta10", "Puerta11" };


    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        if (!dialogue.inDialogue  && !inTransition)
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
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {

        if (longPortals.Any(collision.name.Contains))
        {

            fade.Fade();
            inTransition = true;
            yield return new WaitForSeconds(0.5f);

            
        }
        if (collision.name == "Final")
        {

            fade.StartCoroutine(fade.FadeTo(1f, 0.5f));

            yield return new WaitForSeconds(0.5f);

            light1.color = new Color(0.14f, 0.08f, 0.94f);
            light2.color = new Color(0.14f, 0.08f, 0.94f);
            
            dialoguebox.SetActive(true);
            
            dialogue.lines = atworkLines;
            dialogue.StartDialogue();
            
        }

        /*
        for (int i = 0; i < tp.Length; i++)
        {
                if (collision == puertas[i]) // tp.Any(collision.name[-1].Contains)
                {
                    transform.position = tp[i].transform.position;
                }
        }
        */

        if (tp.Any(collision.name.Substring(6).Contains)) 
        {
           transform.position = tp[collision.name.Substring(6)-1].transform.position;
        }

        yield return null;
    }


}
