using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkground : MonoBehaviour
{
    public static bool isGrounded; //cuando se pone static es que esa variable se puede usar en otro script.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
