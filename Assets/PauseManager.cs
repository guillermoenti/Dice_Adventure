using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas gameCanvas;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (inputManager.HasPlayerPausedThisFrame())
        {
            gameCanvas.gameObject.SetActive(false);
            pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
