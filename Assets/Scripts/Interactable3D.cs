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
    public GameObject? food;
    public ParticleSystem? foodParticles;
    public bool isFood;



    void Update()
    {
        if (contact && Input.GetButtonDown("Interact") && !dialogue.inDialogue && !GameManager.Instance.paused)
        {
            dialoguebox.SetActive(true);
            qmark.SetActive(false);
            if (food !=null )dialogue.food = food;
            if (foodParticles != null) dialogue.foodParticles = foodParticles;
            dialogue.lines = lines;
            dialogue.StartDialogue();
        }
        else if (contact && !dialogue.inDialogue) qmark.SetActive(true);
    }
    private void OnTriggerEnter(Collider collision)
    {
        qmark.SetActive(true);
        contact = true;

    }
    private void OnTriggerExit(Collider collision)
    {
        if (qmark != null) qmark.SetActive(false);

        contact = false;
        dialogue.i = 0;
        dialogue.inDialogue = false;
    }

}
