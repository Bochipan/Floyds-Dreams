using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialoguebox;
    public GameObject bubble;
    private bool contact = false;
    public string[] lines;
    public bool isKalen;



    void Update()
    {
        if (contact && Input.GetButtonDown("Interact") && !dialogue.inDialogue && !(isKalen && dialogue.KalenDone) && !dialogue.eventDone && !GameManager.Instance.paused)
        {
            dialoguebox.SetActive(true);
            bubble.SetActive(false);
            
            dialogue.lines = lines;
            dialogue.StartDialogue();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(isKalen && dialogue.KalenDone) && !(dialogue.eventDone)) bubble.SetActive(true);
        bubble.transform.position = transform.position + GetComponent<SpriteRenderer>().bounds.size /2 + new Vector3 (-0.1f, 1f, -0.3f);
        contact = true;
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (bubble != null) bubble.SetActive(false);
        if (dialoguebox!=null) dialoguebox.SetActive(false);    

        contact = false;
        dialogue.i = 0;
        dialogue.inDialogue = false; 
    }
}
