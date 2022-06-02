using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCanvasManager : MonoBehaviour
{

    [SerializeField] GameObject button;

    [SerializeField] GameObject destinyCanvas;

    public void StartTheRoll()
    {
        button.SetActive(false);
        StartCoroutine(ActivateDestinyCanvas());
    }

    IEnumerator ActivateDestinyCanvas()
    {
        yield return new WaitForSeconds(3);

        destinyCanvas.SetActive(true);
    }
}
