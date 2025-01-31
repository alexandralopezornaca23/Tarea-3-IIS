using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingScreen;    // La pantalla de carga
    public Slider loadingBar;           // La barra de carga
    public TMP_Text percentageText;     // El texto del porcentaje (TMP_Text)

    private string sceneToLoad;         // El nombre de la escena que se cargará

    private void Start()
    {
        loadingScreen.SetActive(false);  // La pantalla de carga está desactivada al inicio
    }

    // Este método se llamará al presionar el botón, con el nombre de la escena como parámetro
    public void StartLoadingScreen(string sceneName)
    {
        sceneToLoad = sceneName;  // Asignamos el nombre de la escena a cargar
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        // Activar la pantalla de carga y la barra
        loadingScreen.SetActive(true);
        loadingBar.value = 0f;
        percentageText.text = "0%";

        // Empezamos el proceso de carga de la escena
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);

        // Deshabilitar la activación automática de la escena
        operation.allowSceneActivation = false;
        
        // Simular una barra de carga mientras la escena se carga
        float loadProgress = 0f;
        while (!operation.isDone)
        {
            loadProgress = Mathf.Clamp01(operation.progress / 0.9f); // Ajustamos el progreso (llega hasta 0.9)
            loadingBar.value = loadProgress;
            percentageText.text = Mathf.FloorToInt(loadProgress * 100) + "%";

            // Si el progreso llega al 90%, se puede activar la escena
            if (operation.progress >= 0.9f)
            {
                // Esperar un poco más para permitir que se vea la transición
                yield return new WaitForSeconds(2.5f); // Espera de 1 segundo para ver la transición

                // Finalmente, activamos la escena
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        // Una vez que la escena se haya cargado, ocultar la pantalla de carga y finalizar la transición
        loadingScreen.SetActive(false);
    }
}