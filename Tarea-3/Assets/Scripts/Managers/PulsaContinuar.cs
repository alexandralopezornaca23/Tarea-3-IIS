using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PulsaContinuar : MonoBehaviour
{
    [SerializeField] private string goSceneName;

    void Update()
    {
        // Detectar si cualquier tecla ha sido presionada
        if (Input.anyKeyDown)
        {
            // Cargar la escena del menú principal
            SceneManager.LoadScene(goSceneName);
        }
    }
}
