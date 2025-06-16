using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Dialogue3D : MonoBehaviour
{  
    public GameObject qmark;
    public GameObject arrow;
    public GameObject floyd;
    public GameObject door;
    public PauseMenu pause;
#nullable enable
    public GameObject? food;
    public ParticleSystem? foodParticles;
#nullable disable
    public bool inDialogue;

    public TextMeshProUGUI TMPro;
    public Image black;
    public SpriteFade3D fade;

    public string[] lines;
    public float speed;
    public int i;
    private int counter;
    public TextMeshProUGUI counterUI;
    public AudioSource source;

    public AudioClip[] blips;
    public AudioSource sourceBlips;

    private void Start()
    {
        
    }
    void Update()
    {

        if (Input.GetButtonDown("Interact") && inDialogue && !GameManager.Instance.paused) {
            arrow.SetActive(false);
            if (TMPro.text == lines[i]) NextLine();
            else {
                StopAllCoroutines();
                TMPro.text = lines[i];
                arrow.SetActive(true);
            }
        }
    }       
    

    public void StartDialogue() {

        TMPro.text = string.Empty;

        gameObject.SetActive(true);
        qmark.SetActive(false);
        inDialogue = true;
        i = 0;
        
        StartCoroutine(TypeLine());
        
    }

    IEnumerator TypeLine() {
        
        foreach (char c in lines[i].ToCharArray()) {
             
            TMPro.text += c;
            if (GameManager.Instance.sound)
            {
                int n = Random.Range(0, 3);
                AudioClip blip = blips[n];
                sourceBlips.clip = blip;
                sourceBlips.Play();
            }
            yield return new WaitForSeconds(speed);
           
        }
        arrow.SetActive(true);
    }

    void NextLine()
    {

        if (i < lines.Length - 1)
        {
            i++;
            TMPro.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (food != null)

            {   foodParticles.Play();
                if (GameManager.Instance.sound) source.Play();
                food.SetActive(false);
                counter++;
                counterUI.text = counter + "/6";
                food = null;
                if (counter == 6) door.SetActive(true);
                
            }
            gameObject.SetActive(false);
            inDialogue = false;
        }

    }

}
