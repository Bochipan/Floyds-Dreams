using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DreamMaker : MonoBehaviour
{
    public SpriteFade fade;
    public Material mat1;
    public Material mat2;
    public Light light1;
    public Light light2;
    public GameObject dream1;
    public GameObject dream2;
    public GameObject floyd;

    void Start()
    {
        fade.StartCoroutine(fade.FadeTo(0f, 5f));

        if (!GameManager.Instance.choices[0]) { 

            RenderSettings.skybox = mat1; 
            light1.color = new Color(1f, 0.964f, 0.693f);
            light2.color = new Color(1f, 0.662f, 0.486f);
        }
        else {
            RenderSettings.skybox = mat2;
            light1.color = new Color(0.41f, 0.355f, 0.717f);
            light2.color = new Color(0.434f, 0.227f, 0.428f);
        }
        if (GameManager.Instance.choices[2])
        {
            floyd.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        if (GameManager.Instance.choices[3])
        {
            dream1.SetActive(true);
        }
        else {
            dream2.SetActive(true);
        }
        
        
    }
}
