using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialoguebox;
    public GameObject qmark;
    private bool contact = false;
    public string[] lines;


    void Start()
    {
   
    }

    void Update()
    {
        if (contact && Input.GetButtonDown("Interact") && !dialogue.inDialogue)
        {
            dialoguebox.SetActive(true);
            qmark.SetActive(false);
            
            dialogue.lines = lines;
            dialogue.StartDialogue();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        qmark.SetActive(true);
        qmark.transform.position = transform.position + GetComponent<SpriteRenderer>().bounds.size /2 + new Vector3 (-0.1f, 1.5f, -0.1f);
        contact = true;
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (qmark!=null) qmark.SetActive(false);
        if (dialoguebox!=null) dialoguebox.SetActive(false);    

        contact = false;
        dialogue.i = 0;
        dialogue.inDialogue = false; 
    }
}
