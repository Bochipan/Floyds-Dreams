
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EightWayMovement : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D rb;
    public GameObject[] tp;
    public Collider2D col;
    public Collider2D[] puertas;
    private Animator animator;
    public SpriteFade fade;
    public Light light1;
    public Light light2;

    public string[] wakeUpLines;
    public string[] toBedLines;
    public string[] atworkLines;
    public GameObject dialoguebox;
    public GameObject principio;
    public Dialogue dialogue;
    public GameObject[] rooms;
    public GameObject kalen;

    private Vector2 movementInput;
    private Vector2 diagonal = - new Vector2(Mathf.Cos(30*Mathf.Rad2Deg), Mathf.Sin(30 * Mathf.Rad2Deg)).normalized;

    public bool inTransition = false;
    private string[] longPortals = new string[6] { "Puerta7", "Puerta9", "Puerta6", "Puerta8", "Puerta10", "Puerta11" };
    private Vector2Int[] culling = new Vector2Int[12] { new Vector2Int(0, 1), new Vector2Int(1, 0), new Vector2Int(1, 2), new Vector2Int(2, 1),
    new Vector2Int(2, 3), new Vector2Int(3, 2), new Vector2Int(3, 4), new Vector2Int(3, 4), new Vector2Int(4, 3), new Vector2Int(4, 3), new Vector2Int(4, 5),new Vector2Int(5, 4)};


    void Start()
    {
        animator = GetComponent<Animator>();

        dialoguebox.SetActive(true);

        dialogue.lines = wakeUpLines;
        dialogue.StartDialogue();
    }

    void Update()
    {
        if (!dialogue.inDialogue  && !inTransition)
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
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {

        if (longPortals.Any(collision.name.Contains))
        {

            fade.Fade();
            inTransition = true;
            yield return new WaitForSeconds(0.5f);

            if (collision.name == "puerta7") GameManager.Instance.choices[2] = true;
            
            
        }

        if (collision.name == "Final")
        {

            fade.StartCoroutine(fade.FadeTo(1f, 0.5f));

            yield return new WaitForSeconds(0.5f);

            light1.color = new Color(0.14f, 0.08f, 0.94f);
            light2.color = new Color(0.14f, 0.08f, 0.94f);
            kalen.SetActive(false);
            principio.SetActive(true);

            GameManager.Instance.currentChoice = 4;
            
            dialoguebox.SetActive(true);
            dialogue.lines = atworkLines;
            dialogue.StartDialogue();

        }
        if (collision.name == "Principio") {

            dialoguebox.SetActive(true);
            dialogue.lines = toBedLines;
            GameManager.Instance.currentChoice = -1;
            dialogue.StartDialogue();

        }

        for (int i = 0; i < tp.Length; i++)
        {
                if (collision == puertas[i])
                {
                    transform.position = tp[i].transform.position;
                    rooms[culling[i].x].SetActive(false);
                    rooms[culling[i].y].SetActive(true);

                }
        }


    }


}
