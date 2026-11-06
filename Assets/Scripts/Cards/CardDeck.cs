using Assets.Scripts.Cards;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDeck", menuName = "Scriptable Objects/CardDeck")]
public class CardDeck : ScriptableObject
{
    public List<CardWrapper> cards;
    public int luckyNumber;
}
