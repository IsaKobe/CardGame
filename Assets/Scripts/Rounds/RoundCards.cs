using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public class RoundCards
{
    [SerializeField] int handSize;
    [SerializeField] List<Card> drawPile;
    public List<Card> hand;
    [SerializeField] List<Card> discardPile;
    [SerializeField] List<Card> exhaustPile;

    public RoundCards(List<Card> cards, int handSize)
    {
        drawPile = cards.ToList();
        hand = cards.GetRange(0, math.min(handSize, drawPile.Count));
        drawPile.RemoveRange(0, math.min(handSize, drawPile.Count));
    }

    public Card PopCard(int index)
    {
        var card = hand[index];
        hand.RemoveAt(index);
        return card;
    }

}