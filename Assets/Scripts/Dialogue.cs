using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Dialogue : MonoBehaviour
{  
    public GameObject qmark;
    public GameObject buttonYES;
    public GameObject buttonNO;
    public GameObject floydPort;
    public GameObject kalenPort;
    public GameObject floyd;
    public GameObject stranger;
    public GameObject kalen;
    public PauseMenu pause;
    public GameObject arrow;

    public bool inDialogue;
    public bool inCutscene;
    private bool isKalen, isStranger;
    public bool KalenDone, eventDone;

    public TextMeshProUGUI TMPro;
    public Image black;
    public SpriteFade fade;
    public SpriteFade fade2;
    public GameObject final;

    public AudioClip[] blips;
    public AudioSource source;

    public string[] lines;
    public float speed;
    public int i;

    private void Start()
    {
        floyd.SetActive(false); 
    }
    void Update()
    {


        if (isKalen) {
            kalenPort.SetActive(true);
            floydPort.SetActive(false);

        }
        else if(isStranger)
        {
            floydPort.SetActive(false);
        }
        else { 
            floydPort.SetActive(true);
            kalenPort.SetActive(false);
        }


        if (Input.GetButtonDown("Interact")&&inDialogue&&!buttonYES.activeSelf && !GameManager.Instance.paused && !inCutscene) {
            arrow.SetActive(false);
            if (lines[i][lines[i].Length - 1] == '&')
            {
                buttonYES.SetActive(true);
                buttonNO.SetActive(true);

            }
          
            if (TMPro.text == lines[i].Trim('*','+'))

            {
                 NextLine();
            }

            else{
                
                StopAllCoroutines(); 
                TMPro.text = lines[i].Trim('&', '*','+');
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
            
            if (c == '*') { 
                isKalen = true;
                GameManager.Instance.currentChoice = 1;
            }
            else if (c == '+')
            {
                isStranger = true;
                GameManager.Instance.currentChoice = 3;
            }

            else if (c == '&') {
                buttonYES.SetActive(true);
                buttonNO.SetActive(true);
 
            }
            else { 

                TMPro.text += c;

                if (GameManager.Instance.sound) {
                    int n = Random.Range(0, 3);
                    AudioClip blip = blips[n];
                    source.clip = blip;
                    source.Play();
                }
                

                yield return new WaitForSeconds(speed);
            }
        }
        arrow.SetActive(true);
    }

    void NextLine()
    {


        if (i < lines.Length - 1)
        {
            if (isKalen) KalenDone = true;
            if (isStranger) eventDone = true;
            i++;
            TMPro.text = string.Empty;
            isKalen = false;
            isStranger = false;
            StartCoroutine(TypeLine());
        }
        else
        {


            isKalen = false;
            isStranger = false;
            if (KalenDone) kalen.GetComponent<PolygonCollider2D>().enabled = false;
            if (eventDone) stranger.GetComponent<PolygonCollider2D>().enabled = false;

            if (black.color.a == 1f)
            {
                fade2.StartCoroutine(fade2.FadeTo(0f, 0.5f));
                final.SetActive(false);
            }
            if (!floyd.activeSelf) {
                fade.StopAllCoroutines();
                fade.StartCoroutine(fade.FadeInOutLong());
                
            }
            gameObject.SetActive(false);
            inDialogue = false;
        }

    }
    public IEnumerator startDream() {

        fade.StartCoroutine(fade.FadeTo(1f, 0.5f));
        yield return new WaitForSeconds(1.5f);
        pause.StartDream();
    }
    public IEnumerator strangerOut()
    {
        inCutscene = true;
        fade.Fade();
        yield return new WaitForSeconds(0.5f);
        stranger.SetActive(false);
        inCutscene = false;


    }
    public void AnswerYes()
    {   
        if (GameManager.Instance.currentChoice == -1) 
        {

            StartCoroutine(startDream());
        }
        else 
        {
            
            
            GameManager.Instance.choices[GameManager.Instance.currentChoice] = true;
            buttonYES.SetActive(false);
            buttonNO.SetActive(false);
            if (GameManager.Instance.currentChoice == 4) kalen.SetActive(false);
            if (GameManager.Instance.currentChoice == 3) {
                StartCoroutine(strangerOut()); 
            }
            else NextLine();
        }
    }
    public void AnswerNo()
    {
        if (!(GameManager.Instance.currentChoice == -1)) GameManager.Instance.choices[GameManager.Instance.currentChoice] = false;
        if (GameManager.Instance.currentChoice == 4) kalen.GetComponent<PolygonCollider2D>().enabled = false;
        buttonYES.SetActive(false);
        buttonNO.SetActive(false);
        NextLine();
    }
}
