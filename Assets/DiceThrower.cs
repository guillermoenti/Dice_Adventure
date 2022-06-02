using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrower : Interactable
{
    [SerializeField] private Animator animator;

    private bool isPlayerInside;

    private bool playerCamera = true;

    [SerializeField] private GameObject canvas;

    public override void OnInteract()
    {
        SwitchState();
        Debug.Log("Interact");
    }

    private void SwitchState()
    {
        if (playerCamera)
        {
            animator.Play("DiceCamera");
            canvas.SetActive(true);
        }
        else
        {
            animator.Play("PlayerCamera");
            canvas.SetActive(false);
        }
        playerCamera = !playerCamera;
    }
}
