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
        Button btn = pauseButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
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
            if (GameManager.Instance.paused) { Pause(); }
            else { Resume();}
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameManager.Instance.paused = true;

    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.paused = false;
    }

    public void Exit() {
        SceneManager.LoadScene("Main Menu");
    }
    public void StartDream() {
        SceneManager.LoadScene("3DScene");
    }
}
