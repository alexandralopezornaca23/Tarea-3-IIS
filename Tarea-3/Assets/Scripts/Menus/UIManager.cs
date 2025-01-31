using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    public AudioSource clip;

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
        Time.timeScale = 1f;
        isPaused = false;
        pausePanel.SetActive(false);
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
        
        StartCoroutine(ResetLevelEnum());
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayButtonSound()
    {
        clip.Play();
    }

    private IEnumerator ResetLevelEnum()
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo se reanude
        clip.Play();

        yield return new WaitForSeconds(0.25f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar la escena actual

        yield return null;
    }
}
