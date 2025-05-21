using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Floyd : MonoBehaviour
{

    public GameObject dialoguebox;
    public GameObject principio;
    public Dialogue dialogue;
    public SpriteFade fade;

    public Collider2D[] puertas;
    public GameObject[] tp;
    public GameObject[] rooms;

   
    

    public Light light1;
    public Light light2;

    public string[] wakeUpLines;
    public string[] toBedLines;
    public string[] atworkLines;

    public bool inTransition;

    private string[] longPortals = new string[6] { "Puerta7", "Puerta9", "Puerta6", "Puerta8", "Puerta10", "Puerta11" };
    private Vector2Int[] culling = new Vector2Int[12] { new Vector2Int(0, 1), new Vector2Int(1, 0), new Vector2Int(1, 2), new Vector2Int(2, 1),
    new Vector2Int(2, 3), new Vector2Int(3, 2), new Vector2Int(3, 4), new Vector2Int(3, 4), new Vector2Int(4, 3), new Vector2Int(4, 3), new Vector2Int(4, 5),new Vector2Int(5, 4)};


    void Start()
    {
        dialoguebox.SetActive(true);

        dialogue.lines = wakeUpLines;
        dialogue.StartDialogue();
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {


        if (longPortals.Any(collision.name.Contains))
        {

            fade.Fade();
            inTransition = true;
            yield return new WaitForSeconds(0.5f);

            if (collision.gameObject.name == "Puerta7")
            {
                GameManager.Instance.choices[2] = true;
            }
        }

        if (collision.name == "Final")
        {

            fade.StartCoroutine(fade.FadeTo(1f, 0.5f));

            yield return new WaitForSeconds(0.5f);

            light1.color = new Color(0.14f, 0.08f, 0.94f);
            light2.color = new Color(0.14f, 0.08f, 0.94f);
            
            principio.SetActive(true);

            GameManager.Instance.currentChoice = 4;

            dialoguebox.SetActive(true);
            dialogue.lines = atworkLines;
            dialogue.StartDialogue();

        }
        if (collision.name == "Principio")
        {

            dialoguebox.SetActive(true);
            dialogue.lines = toBedLines;
            GameManager.Instance.currentChoice = -1;
            dialogue.StartDialogue();

        }

        for (int i = 0; i < tp.Length; i++)
        {
            if (collision == puertas[i])
            {
                transform.position = tp[i].transform.position;
                rooms[culling[i].x].SetActive(false);
                rooms[culling[i].y].SetActive(true);

            }
        }

    }
}
