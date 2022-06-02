using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishDestiny : MonoBehaviour
{
    [SerializeField] DiceStats[] dice = new DiceStats[5];
    [SerializeField] TextMeshProUGUI[] diceText = new TextMeshProUGUI[5];

    [SerializeField] GameObject[] dicePlaced = new GameObject[5];

    [SerializeField] DiceThrower diceThrower;

    public void CheckDice()
    {
        bool areDicePlaced = true;

        foreach (GameObject go in dicePlaced)
        {
            if (go.transform.GetChild(1).childCount < 1)
            {
                areDicePlaced = false;
            }
        }

        if (areDicePlaced)
        {
            int.TryParse(dicePlaced[0].transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text.ToString(), out int stat1);
            int.TryParse(dicePlaced[1].transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text.ToString(), out int stat2);
            int.TryParse(dicePlaced[2].transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text.ToString(), out int stat3);
            int.TryParse(dicePlaced[3].transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text.ToString(), out int stat4);
            int.TryParse(dicePlaced[4].transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text.ToString(), out int stat5);

            GameManager.instance.SetStats(stat1, stat2, stat3, stat4, stat5);

            diceThrower.TurnBack();
            diceThrower.canBeInteracted = false;
            gameObject.SetActive(false);
        }
    }

}
