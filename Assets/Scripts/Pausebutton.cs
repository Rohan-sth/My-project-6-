using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausebutton : MonoBehaviour
{
    [SerializeField] GameObject thePauseMenu;

    public void Paused()
    {
        thePauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        thePauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
