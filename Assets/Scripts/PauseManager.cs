using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas gameCanvas;

    private bool isPaused;

    AudioSource audio;

    private void Awake()
    {
        inputManager = InputManager.Instance;
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (inputManager.HasPlayerPausedThisFrame())
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameCanvas.gameObject.SetActive(false);
            pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ClosePause()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        audio.Play();
    }

    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        audio.Play();
        SceneManager.LoadScene(0);
    }
}
