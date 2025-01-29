using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectPlayer;

    public enum Player { Frog, VirtualGuy, PinkMan, MaskDude };
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playersRenderer;

    // Start is called before the first frame update
    void Start()
    {
        ChangePlayerInMenu();
        //if (!enableSelectPlayer)
        //{
        //    ChangePlayerInMenu();
        //}
        //else
        //{
        //    switch (playerSelected)
        //    {
        //        case Player.Frog:
        //            spriteRenderer.sprite = playersRenderer[0];
        //            animator.runtimeAnimatorController = playersController[0];
        //            break;
        //        case Player.VirtualGuy:
        //            spriteRenderer.sprite = playersRenderer[1];
        //            animator.runtimeAnimatorController = playersController[1];
        //            break;
        //        case Player.PinkMan:
        //            spriteRenderer.sprite = playersRenderer[2];
        //            animator.runtimeAnimatorController = playersController[2];
        //            break;
        //        case Player.MaskDude:
        //            spriteRenderer.sprite = playersRenderer[3];
        //            animator.runtimeAnimatorController = playersController[3];
        //            break;
        //        default:
        //            break;
        //    }
        //}
        
        //if (animator == null || spriteRenderer == null)
        //{
        //    Debug.LogError("Animator or SpriteRenderer is not assigned!");
        //    return;
        //}

        //if (playersController == null || playersController.Length == 0 ||
        //    playersRenderer == null || playersRenderer.Length == 0)
        //{
        //    Debug.LogError("PlayersController or PlayersRenderer arrays are empty!");
        //    return;
        //}

        //UpdateCharacter();
    }

    void UpdateCharacter()
    {
        int index = (int)playerSelected;

        if (index < 0 || index >= playersRenderer.Length || index >= playersController.Length)
        {
            Debug.LogError("Index out of range in PlayersRenderer or PlayersController arrays.");
            return;
        }

        // Update Sprite and Animator
        spriteRenderer.sprite = playersRenderer[index];
        animator.runtimeAnimatorController = playersController[index];

        if (animator.runtimeAnimatorController != null)
        {
            animator.Rebind(); // Rebind to ensure correct animation playback
            animator.Update(0f); // Update Animator immediately
        }
        else
        {
            Debug.LogError("Animator Controller is null for the selected player.");
        }
    }

    public void ChangePlayerInMenu()
    {
        string selectedPlayer = PlayerPrefs.GetString("PlayerSelected", "Frog"); // Valor por defecto

        switch (selectedPlayer)
        {
            case "Frog":
                spriteRenderer.sprite = playersRenderer[0];
                animator.runtimeAnimatorController = playersController[0];
                break;
            case "VirtualGuy":
                spriteRenderer.sprite = playersRenderer[1];
                animator.runtimeAnimatorController = playersController[1];
                break;
            case "PinkMan":
                spriteRenderer.sprite = playersRenderer[2];
                animator.runtimeAnimatorController = playersController[2];
                break;
            case "MaskDude":
                spriteRenderer.sprite = playersRenderer[3];
                animator.runtimeAnimatorController = playersController[3];
                break;
            default:
                break;
        }
    }
}