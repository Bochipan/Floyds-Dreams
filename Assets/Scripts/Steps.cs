using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    public AudioClip[] steps;
    public AudioSource source;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Step()
    {
        int n = Random.Range(0, 2);
        AudioClip step = steps[n];
        source.clip = step;
        source.Play();
    }
}
