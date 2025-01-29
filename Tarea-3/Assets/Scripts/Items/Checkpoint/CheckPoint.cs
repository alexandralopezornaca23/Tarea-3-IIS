using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);
            GetComponent<Animator>().enabled = true;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        PlayerRespawn playerRespawn = collision.GetComponent<PlayerRespawn>();
    //        if (playerRespawn != null)
    //        {
    //            playerRespawn.ReachedCheckPoint(transform.position.x, transform.position.y);
    //        }
    //        else
    //        {
    //            Debug.LogError("El objeto con la etiqueta 'Player' no tiene un componente PlayerRespawn.");
    //        }
    //    }
    //}
}
