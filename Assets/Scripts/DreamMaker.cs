using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class DreamMaker : MonoBehaviour
{
    public Material mat1;
    public Material mat2;   
    public Material halftone;
    public Material halftone1;
    public Material halftone2;
    public Material restaurant;
    
    public Light light1;
    public Light light2;

    public GameObject dream1;
    public GameObject dream2;
    public GameObject floyd;
    public GameObject kalen;
    public GameObject counter;
    public GameObject dialoguebox;
    public Dialogue3D dialogue;
    public SpriteFade3D fade;

    public string[] lines;

    void Start()
    {
        fade.StartCoroutine(fade.FadeTo(0f, 5f));
        


        if (GameManager.Instance.choices[0]) { //Si es true, es de día. Si es false, es de noche.

            RenderSettings.skybox = mat1; 
            light1.color = new Color(1f, 0.964f, 0.693f);
            light2.color = new Color(1f, 0.662f, 0.486f);
            halftone.SetColor("_BaseColor", new Color(1f, 1f, 1f));
            halftone1.SetColor("_BaseColor", new Color(1f, 1f, 1f));
            halftone2.SetColor("_BaseColor", new Color(1f, 1f, 1f));
            restaurant.SetColor("_BaseColor", new Color(1f, 1f, 1f));

        }
        else {
            RenderSettings.skybox = mat2;
            light1.color = new Color(0.41f, 0.355f, 0.717f);
            light2.color = new Color(0.434f, 0.227f, 0.428f);
            halftone.SetColor("_BaseColor", new Color(0.59f, 0.60f, 1f));
            halftone1.SetColor("_BaseColor", new Color(0.59f, 0.60f, 1f));
            halftone2.SetColor("_BaseColor", new Color(0.59f, 0.60f, 1f));
            restaurant.SetColor("_BaseColor", new Color(0.59f, 0.60f, 1f));
        }
        if (!GameManager.Instance.choices[1]) //Si true, aparece Kalen. Si false, no aparece.
        {
           kalen.SetActive(true);
        }
        if (GameManager.Instance.choices[2]) //Si true, Floyd es pequeñita. Si false, Floyd es tamaño normal.
        {
            floyd.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            floyd.GetComponent<Animator>().speed = 1.43f;
            lines = new string[] { "Wow, I'm so small!" };
        }
        if (GameManager.Instance.choices[3]) //Si true, se activa el sueño de buses. Si false, se activa el sueño del restaurante.
        {
            dream1.SetActive(true);
            counter.SetActive(true);
            lines = lines.Concat(new string[3]{ "Huh, I'm at a bus station.", "I can see a bunch of groceries laying around...", "Maybe I have to pick them all up to be able to leave!" }).ToArray();
 
        }
        else {
            dream2.SetActive(true);
            lines = lines.Concat(new string[3]{ "Oh, this is the place I work at!", "But the workers are... a bunch of farm animals?","Let's walk around and see if I can find an open door." }).ToArray();

        }

        dialoguebox.SetActive(true);
        dialogue.lines = lines;
        dialogue.StartDialogue();
    }
}
