using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Return(); // Desactiva el menú de pausa
            }
            else
            {
                PausePanel(); // Activa el menú de pausa
            }
        }
    }

    public void PausePanel()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void Return()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void GoInitialScreen()
    {
        //para ir al Main Menu más organizado.
        SceneManager.LoadScene("Initial-Screen");
    }

    public void GoLevelSelect()
    {
        //SceneManager.LoadScene("Select-Level");

        Time.timeScale = 1f;
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void GoOptionsMenu()
    {
        
    }

    public void ResetLevel()
    {
        //Time.timeScale = 1f; // Asegurarse de que el tiempo se reanude
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar la escena actual

        Time.timeScale = 1f;
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
