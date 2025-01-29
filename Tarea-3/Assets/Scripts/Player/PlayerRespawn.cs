using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPosX, checkPointPosY;

    public Animator animator;

    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPosX") != 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPosX"), PlayerPrefs.GetFloat("checkPointPosY"));
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPosX", x);
        PlayerPrefs.SetFloat("checkPointPosY", y);
    }

    public void PlayerDamage()
    {
        animator.Play("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
