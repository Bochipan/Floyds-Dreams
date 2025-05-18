using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Dialogue3D dialogue;
    public GameObject dialoguebox;
    public GameObject qmark;
    private bool contact = false;
    public string[] lines;


    void Update()
    {
        if (contact && Input.GetButtonDown("Interact") && !dialogue.inDialogue && !GameManager.Instance.paused)
        {
            dialoguebox.SetActive(true);
            qmark.SetActive(false);
            
            dialogue.lines = lines;
            dialogue.StartDialogue();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("pum");
        qmark.SetActive(true);
        qmark.transform.position = transform.position + GetComponent<SpriteRenderer>().bounds.size /2 + new Vector3 (-0.1f, 1.5f, -0.3f);
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
    private void OnCollisionEnter(Collision collision)
    {
        qmark.SetActive(true);
        qmark.transform.position = transform.position + GetComponent<MeshRenderer>().bounds.size / 2 + new Vector3(-0.1f, 1.5f, -0.3f);
        contact = true;

    }
    private void OnCollisionExit(Collision collision)
    {
        if (qmark != null) qmark.SetActive(false);
        if (dialoguebox != null) dialoguebox.SetActive(false);

        contact = false;
        dialogue.i = 0;
        dialogue.inDialogue = false;
    }
}
