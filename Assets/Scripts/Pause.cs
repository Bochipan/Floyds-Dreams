using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button pauseButton;

    void Start()
    {
        Resume();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TaskOnClick();
        }
    }
    void TaskOnClick()
    {

        if (pauseMenu != null)
        {
            
            if (!GameManager.Instance.paused) Pause();
            else Resume();
        }
    }
    public void Pause()
    {
        if (GameManager.Instance.paused) Resume();
        else { 
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameManager.Instance.paused = true;
        Cursor.lockState = CursorLockMode.None;
        }

    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.paused = false;
        if(SceneManager.GetActiveScene().name == ("3DScene")) Cursor.lockState = CursorLockMode.Locked;
    }

    public void Exit() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void StartDream() {
        SceneManager.LoadScene("3DScene");
    }
}
