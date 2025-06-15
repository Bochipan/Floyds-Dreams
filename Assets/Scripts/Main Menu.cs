using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Sprite SoundButtonOn;
    public Sprite SoundButtonOff;
    public Image SoundBtn;
    public AudioSource music;
    public void PlayGame()
    { 
        SceneManager.LoadScene("2DScene");
    }

    public void QuitGame()
    {
        
        Application.Quit();


    }
    public void SoundButton()
    {
        if (GameManager.Instance.sound) { 
            GameManager.Instance.sound = false;
            SoundBtn.sprite = SoundButtonOff;
            music.Pause();
        }
        else {
            GameManager.Instance.sound = true;
            SoundBtn.sprite = SoundButtonOn;
            music.Play();
        }
    }
}