using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable3D : MonoBehaviour
{
    public Dialogue3D dialogue;
    public GameObject dialoguebox;
    public GameObject qmark;
    private bool contact = false;
    public string[] lines;
    public GameObject food;
    public bool isFood;


    void Update()
    {
        if (contact && Input.GetButtonDown("Interact") && !dialogue.inDialogue && !GameManager.Instance.paused)
        {
            dialoguebox.SetActive(true);
            qmark.SetActive(false);
            dialogue.food = food;
            dialogue.lines = lines;
            dialogue.StartDialogue();
        }
        if (contact && !dialogue.inDialogue) qmark.SetActive(true);
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("in");
        qmark.SetActive(true);
        contact = true;

    }
    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("out");
        if (qmark != null) qmark.SetActive(false);
        if (dialoguebox != null) dialoguebox.SetActive(false);

        contact = false;
        dialogue.i = 0;
        dialogue.inDialogue = false;
    }
}
