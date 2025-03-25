using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mueble1 : MonoBehaviour
{

    private string Texto;
    public GameObject dialoguebox;
    public GameObject qmark;
    private bool contact = false;

    void Start()
    {
   
    }

    void Update()
    {
        if (contact && Input.GetButtonDown("Interact"))
        {
            dialoguebox.SetActive(true);
            qmark.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        qmark.SetActive(true);
        qmark.transform.position = transform.position + GetComponent<SpriteRenderer>().bounds.size /2 + new Vector3 (-0.1f, 1.8f, 0);
        contact = true;
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        dialoguebox.SetActive(false);    
        contact = false;
    }
}
