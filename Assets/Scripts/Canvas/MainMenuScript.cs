using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject tutorial;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenCredits()
    {
        credits.gameObject.SetActive(true);
    }

    public void OpenTutorial()
    {
        tutorial.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CloseActualWindow()
    {
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
