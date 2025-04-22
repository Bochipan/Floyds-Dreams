using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject qmark;
    public GameObject buttonYES;
    public GameObject buttonNO;
    public GameManager GM;
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
  
        if (Input.GetButtonDown("Interact")&&inDialogue&&!buttonYES.activeSelf) {

            if (lines[i][lines[i].Length - 1] == '&')
            {
                buttonYES.SetActive(true);
                buttonNO.SetActive(true);

            }
            
            if (TMPro.text == lines[i])
            {
                 NextLine();
            }
            else { 
                StopAllCoroutines();
                 
                TMPro.text = lines[i].Trim('&');
                
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
            

            if (c == '&') {
                buttonYES.SetActive(true);
                buttonNO.SetActive(true);
 
            }
            else { 

                TMPro.text += c;
                yield return new WaitForSeconds(speed);
            }
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

    public void AnswerYes()
    {
        GM.choice1 = true;
        buttonYES.SetActive(false);
        buttonNO.SetActive(false);
        NextLine();
    }
    public void AnswerNo()
    {
        GM.choice1 = false;
        buttonYES.SetActive(false);
        buttonNO.SetActive(false);
        NextLine();
    }
}
