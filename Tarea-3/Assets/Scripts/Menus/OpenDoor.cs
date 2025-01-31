using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public GameObject panelPulsaE;
    //public TextMeshProUGUI textPulsaE;
    public string levelName;
    private bool inDoor = false;

    public AudioSource clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    //textPulsaE.gameObject.SetActive(true);
        //    panelPulsaE.gameObject.SetActive(true);
        //    inDoor = true;
        //}

        if (collision.gameObject.CompareTag("Player"))
        {
            if (panelPulsaE != null) // Verifica si el objeto aún existe
            {
                panelPulsaE.SetActive(true);
            }
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //textPulsaE.gameObject.SetActive(false);

        //panelPulsaE.gameObject.SetActive(false);
        //inDoor = false;

        if (panelPulsaE != null) // Verifica si el objeto aún existe antes de modificarlo
        {
            panelPulsaE.SetActive(false);
        }
        inDoor = false;

    }

    private void Update()
    {
        //if (inDoor && Input.GetKey("e"))
        //{
        //    SceneManager.LoadScene(levelName);
        //}

        if (inDoor && Input.GetKeyDown(KeyCode.E)) // Usa GetKeyDown en lugar de GetKey
        {
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        clip.Play();

        yield return new WaitForSeconds(0.25f);

        if (!string.IsNullOrEmpty(levelName))
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.LogError("El nombre de la escena no está configurado en OpenDoor.");
        }

        yield return null;
    }
}
