using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    { 
        SceneManager.LoadScene("2DScene");
    }

    public void QuitGame()
    {
        
        Application.Quit();


    }
}