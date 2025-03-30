using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject qmark;
    public bool inDialogue = false;

    public TextMeshProUGUI TMPro;

    public string[] lines;
    public float speed;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        if (Input.GetButtonDown("Interact")&&inDialogue) {
            
            if (TMPro.text == lines[i])
            {
                NextLine();
            }
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

    void NextLine() {
       
        if (i < lines.Length-1)
        {
            i++;
            TMPro.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else {
            gameObject.SetActive(false);
            inDialogue = false;
        }
    }

}
