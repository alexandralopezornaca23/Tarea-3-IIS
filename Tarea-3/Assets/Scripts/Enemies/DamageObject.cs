using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Debug.Log("El player a sido matado");
            //Destroy(collision.gameObject);

            collision.transform.GetComponent<PlayerRespawn>().PlayerDamage();
        }
    }
}
