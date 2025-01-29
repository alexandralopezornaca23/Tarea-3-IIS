using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorChangeSkins : MonoBehaviour
{
    public GameObject panelPulsaE;
    
    public GameObject skinsPanel;
    private bool inDoor = false;
    public GameObject player;
    private bool isPaused = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            panelPulsaE.gameObject.SetActive(true);
            inDoor = true;
        }

        //if (collision.CompareTag("Player"))
        //{
        //    skinsPanel.gameObject.SetActive(true);
        //    inDoor = true;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panelPulsaE.gameObject.SetActive(false);
        inDoor = false;
        //skinsPanel?.gameObject.SetActive(false);
        //inDoor = false;
    }

    private void Update()
    {
        if (inDoor && Input.GetKey("e"))
        {
            Pause();
        }


        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Return();
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        panelPulsaE.gameObject.SetActive(false);
        skinsPanel.gameObject.SetActive(true);
    }

    public void Return()
    {
        skinsPanel.gameObject.SetActive(false);
        panelPulsaE.gameObject.SetActive(true);        
        Time.timeScale = 1f;        
        isPaused = false;
    }

    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("PlayerSelected", "Frog");
        PlayerPrefs.Save();
        ResetPlayerSkin();
    }

    public void SetPlayerVirtualGuy()
    {
        PlayerPrefs.SetString("PlayerSelected", "VirtualGuy");
        PlayerPrefs.Save();
        ResetPlayerSkin();
    }

    public void SetPlayerPinkMan()
    {
        PlayerPrefs.SetString("PlayerSelected", "PinkMan");
        PlayerPrefs.Save();
        ResetPlayerSkin();
    }

    public void SetPlayerMaskDude()
    {
        PlayerPrefs.SetString("PlayerSelected", "MaskDude");
        PlayerPrefs.Save();
        ResetPlayerSkin();
    }

    void ResetPlayerSkin()
    {
        skinsPanel.gameObject.SetActive(false);
        panelPulsaE.gameObject.SetActive(true);
        player.GetComponent<PlayerSelect>().ChangePlayerInMenu(); 
        Time.timeScale = 1f; // Reanudar el tiempo
    }
}
