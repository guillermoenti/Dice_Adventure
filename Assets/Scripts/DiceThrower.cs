using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceThrower : Interactable
{
    [SerializeField] private Animator animator;

    private bool playerCamera = true;

    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject playerHUD;


    public override void OnInteract()
    {
        if(canBeInteracted)
        GoToDiceThrower();
    }

    private void GoToDiceThrower()
    {
        animator.Play("DiceCamera");
        playerHUD.SetActive(false);
        canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void TurnBack()
    {
        animator.Play("PlayerCamera");
        playerHUD.SetActive(true);
        canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
