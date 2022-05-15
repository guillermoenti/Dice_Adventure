using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrower : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool isPlayerInside;

    private bool playerCamera = true;

    [SerializeField] private GameObject canvas;

    private void Update()
    {
        if (isPlayerInside)
        {
            if (InputManager.Instance.HasPlayerInteractedThisFrame())
            {
                Debug.Log("Press");
                SwitchState();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
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
