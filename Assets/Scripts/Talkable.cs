using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Talkable : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialoguebox;
    public GameObject dbox;
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
            dbox.SetActive(false);
            
            dialogue.lines = lines;
            dialogue.StartDialogue();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dbox.SetActive(true);
        dbox.transform.position = transform.position + GetComponent<SpriteRenderer>().bounds.size /2 + new Vector3 (-0.1f, 1f, -0.1f);
        contact = true;
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (dbox != null) dbox.SetActive(false);
        if (dialoguebox!=null) dialoguebox.SetActive(false);    

        contact = false;
        dialogue.i = 0;
        dialogue.inDialogue = false; 
    }
}
