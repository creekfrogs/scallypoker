using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameGUI : MonoBehaviour
{
    GameObject playersInGame;
    public GameObject[] playerSlotsGUI;

    private void Awake()
    {
        playersInGame = transform.GetChild(0).gameObject;
    }

    private Color GetPlayerColor(int i)
    {
        if (i == 0)
            return Color.red;
        else if (i == 1)
            return Color.blue;
        else if (i == 2)
            return Color.green;
        else if (i == 3)
            return Color.yellow;
        else if (i == 4)
            return Color.magenta;
        else
            return Color.white;
    }

    public void UpdatePlayerSlots()
    {
        var players = GameManager.instance.playersInGame;
        for (int k = 0; k < players.Length; k++)
        {
            if (players[k] != null)
            {
                Color playerColor = GetPlayerColor(k);
                playerSlotsGUI[k].GetComponent<Image>().color = playerColor;
                playerSlotsGUI[k].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = playerColor;
                playerSlotsGUI[k].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = players[k].playerName;
            }
            else
            {
                playerSlotsGUI[k].GetComponent<Image>().color = Color.grey;
                playerSlotsGUI[k].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.grey;
                playerSlotsGUI[k].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Empty";
            }
        }
    }
}
