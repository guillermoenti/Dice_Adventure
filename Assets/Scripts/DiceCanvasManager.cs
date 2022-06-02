using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceCanvasManager : MonoBehaviour
{

    [SerializeField] GameObject button;

    [SerializeField] GameObject destinyCanvas;

    [SerializeField] DiceStats[] dice = new DiceStats[5];
    [SerializeField] TextMeshProUGUI[] diceText = new TextMeshProUGUI[5];

    [SerializeField] GameObject[] dicePlaced = new GameObject[5];

    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void StartTheRoll()
    {
        button.SetActive(false);
        audio.Play();
        StartCoroutine(ActivateDestinyCanvas());
    }

    IEnumerator ActivateDestinyCanvas()
    {
        yield return new WaitForSeconds(3);

        for(int i = 0; i < 5; i++)
        {
            diceText[i].text = dice[i].side.ToString();
        }

        destinyCanvas.SetActive(true);
    }

     
}
