using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    PlayerControls playerControls;
    Animator animator;
    InteractiveObject interactive;
    public List<Card> deck = new List<Card>();
    bool isDrawing;

    private void Awake()
    {
        playerControls = new PlayerControls();
        interactive = GetComponent<InteractiveObject>();
        animator = GetComponent<Animator>();

        playerControls.Deck.Draw.performed += ctx => Draw();
        playerControls.Deck.Shuffle.performed += ctx => Shuffle();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void Draw()
    {
        Card drawnCard = deck[0];
        deck.RemoveAt(0);
        Debug.Log("You drew the " + GameManager.instance.GetCardName(drawnCard));
        Instantiate(drawnCard.prefab);
    }

    public void Shuffle()
    {
        Debug.Log("Shuffling Deck...");
        for (int t = 0; t < deck.Count; t++)
        {
            Card tmp = deck[t];
            int r = Random.Range(t, deck.Count);
            deck[t] = deck[r];
            deck[r] = tmp;
        }
    }
}
