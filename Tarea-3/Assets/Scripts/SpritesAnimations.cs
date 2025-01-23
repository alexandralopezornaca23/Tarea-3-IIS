using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesAnimations : MonoBehaviour
{
    public Sprite[] sprites;
    public float frameTimer = 0.1f;

    //float timer = 0f;
    int animationFrame = 0;

    public bool stop;

    public bool loop = true;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Animation();
        StartCoroutine(Animation());
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.time;
        //if (timer > frameTimer) 
        //{
        //    //Cambiamos de sprite
        //    //Sumamos 1 a nuestro indice
        //    animationFrame++;
        //    //Tenemos que controlar que el indice no es mayor que el numeor de registros del array
        //    //si es asi, significa que ya hemos pasado el ultimo y volvemos a empezar
        //    if (animationFrame >= sprites.Length) 
        //    {
        //        animationFrame = 0;
        //    }

        //    spriteRenderer.sprite = sprites[animationFrame];
        //    timer = 0f;
        //}
    }

    IEnumerator Animation()
    {
        if (loop)
        {
            while (!stop)
            {
                //Debug.Log("Animation Frame: " + animationFrame);
                spriteRenderer.sprite = sprites[animationFrame];
                //yield return null;
                animationFrame++;

                if (animationFrame >= sprites.Length)
                {
                    animationFrame = 0;
                }

                yield return new WaitForSeconds(frameTimer);
            }
        }
        else
        {
            while (animationFrame < sprites.Length)
            {
                spriteRenderer.sprite = sprites[animationFrame];
                animationFrame++;
                yield return new WaitForSeconds(frameTimer);
            }
            Destroy(gameObject);
        }
    }
}
