using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpot : MonoBehaviour
{
    public string playerName;
    public bool isFull;

    private void Update()
    {
        if (playerName != "")
            isFull = true;
        else
            isFull = false;
    }
}
