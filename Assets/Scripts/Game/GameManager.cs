using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerManager[] playersInGame;
    public PlayerSpot[] playerSpots;
    public Camera tableCam;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        tableCam = GetComponentInChildren<Camera>();
    }

    public PlayerSpot AddPlayer(PlayerManager addedPlayer)
    {
        for (int i = 0; i < 5; i++)
        {
            if (playerSpots[i].playerName != null)
            {
                playersInGame[i] = addedPlayer;
                playerSpots[i].playerName = addedPlayer.playerName;
                addedPlayer.inGameGUI.UpdatePlayerSlots();
                return playerSpots[i];
            }
            else
            {
                continue;
            }
        } 
        return null;
    }

    public string GetCardName(Card card)
    {
        string outputRank = "";

        if(card.rank == 1)
        {
            outputRank = "Ace";
        }
        if(card.rank == 11)
        {
            outputRank = "Jack";
        }
        if (card.rank == 12)
        {
            outputRank = "Queen";
        }
        if (card.rank == 13)
        {
            outputRank = "King";
        }

        return new string(outputRank + " of " + card.suit + "s");
    }
}
