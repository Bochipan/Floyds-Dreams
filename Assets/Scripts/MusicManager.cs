using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;
    void Start()
    {
        if (GameManager.Instance.sound) music.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
