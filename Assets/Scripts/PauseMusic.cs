using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseMusic : MonoBehaviour
{
    public Sprite SoundButtonOn;
    public Sprite SoundButtonOff;
    public Image SoundBtn;
    public AudioSource music;

    void Start()
    {
        if (!GameManager.Instance.sound)
        {
            GameManager.Instance.sound = false;
            SoundBtn.sprite = SoundButtonOff;
        }
        else
        {
            GameManager.Instance.sound = true;
            SoundBtn.sprite = SoundButtonOn;
        }
    }

    // Update is called once per frame
    public void ButtonClick()
    {
        if (GameManager.Instance.sound)
        {
            GameManager.Instance.sound = false;
            SoundBtn.sprite = SoundButtonOff;
            music.Pause();
        }
        else
        {
            GameManager.Instance.sound = true;
            SoundBtn.sprite = SoundButtonOn;
            music.Play();
        }
    }
}
