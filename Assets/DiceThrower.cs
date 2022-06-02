using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrower : Interactable
{
    [SerializeField] private Animator animator;

    private bool isPlayerInside;

    private bool playerCamera = true;

    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject playerHUD;

    public override void OnInteract()
    {
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
}
