using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollected : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Debug.Log("Fruta recolectada");
    //    if (collision.CompareTag("Player"))
    //    {
    //        GetComponent<SpriteRenderer>().enabled = false;
    //        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"Entró en OnTriggerEnter2D con: {collision.name}");

        if (collision.CompareTag("Player"))
        {
            //Debug.Log("El objeto es el jugador");
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
                //Debug.Log("SpriteRenderer desactivado");
            }
            //else
            //{
            //    Debug.LogError("SpriteRenderer no encontrado");
            //}

            if (transform.childCount > 0)
            {
                //Debug.Log("Activando hijo");
                transform.GetChild(0).gameObject.SetActive(true);
            }
            //else
            //{
            //    Debug.LogError("No hay hijos en el objeto fruta");
            //}

            Destroy(gameObject, 0.5f);
            //Debug.Log("Fruta destruida después de 0.5 segundos");
        }
    }
}
