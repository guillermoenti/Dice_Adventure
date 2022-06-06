using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject tutorial;

    AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        audio.Play();
        SceneManager.LoadScene(1);
    }

    public void OpenCredits()
    {
        audio.Play();
        credits.gameObject.SetActive(true);
    }

    public void OpenTutorial()
    {
        audio.Play();
        tutorial.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        audio.Play();
        Application.Quit();
    }

    public void CloseActualWindow()
    {
        audio.Play();
        if (credits.gameObject.activeSelf)
        {
            credits.SetActive(false);
        }
        if (tutorial.gameObject.activeSelf)
        {
            tutorial.SetActive(false);
        }
    }

}
