using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue3D : MonoBehaviour
{  
    public GameObject qmark;
    public GameObject floyd;
    public PauseMenu pause;

    public bool inDialogue;

    public TextMeshProUGUI TMPro;
    public Image black;
    public SpriteFade fade;

    public string[] lines;
    public float speed;
    public int i;

    private void Start()
    {
        
    }
    void Update()
    {

        if (Input.GetButtonDown("Interact")&& inDialogue && !GameManager.Instance.paused) {

            if (TMPro.text == lines[i]) NextLine();
            else { 
                StopAllCoroutines(); 
                TMPro.text = lines[i];
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
                yield return new WaitForSeconds(speed);
        }
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
            gameObject.SetActive(false);
            inDialogue = false;
        }

    }

}
