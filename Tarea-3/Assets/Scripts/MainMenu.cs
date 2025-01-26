using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void CargarMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void JugarNivel1()
    {
        SceneManager.LoadScene(2);
    }

    public void JugarNivel2()
    {
        SceneManager.LoadScene(3);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
