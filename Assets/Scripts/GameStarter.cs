using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : Interactable
{

    public override void OnInteract()
    {
        SceneManager.LoadScene(2);
    }
}
