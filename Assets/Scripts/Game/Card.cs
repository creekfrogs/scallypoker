using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SuitEnum
{
    Heart,
    Club,
    Diamond,
    Spade
}
[CreateAssetMenu(menuName = "Omega Studios/Card")]
public class Card : ScriptableObject
{
    public int rank;
    public SuitEnum suit;
    public GameObject prefab;
}
