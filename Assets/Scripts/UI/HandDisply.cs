using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class HandDisply : MonoBehaviour
{
    RoundCards roundCards;
    List<CardUI> cards;

    VisualElement root;
    void Reload(PanelRenderer renderer, VisualElement element, int version)
    {
        root = element.Q("Root");
        SpawnElements();
    }


    void SpawnElements()
    {
        root.Clear();
        cards = new();
        var hand = roundCards.hand;
        for (int i = 0; i < hand.Count; i++)
        {
            Card item = hand[i];
            CardUI ui = new CardUI(i, item, PlayCard);

            cards.Add(ui);
            root.Add(ui);
        }
    }

    public void AttachData(RoundCards roundCards)
    {
        this.roundCards = roundCards;

        PanelRenderer renderer = GetComponent<PanelRenderer>();
        renderer.UnregisterUIReloadCallback(Reload);
        renderer.RegisterUIReloadCallback(Reload);
    }

    public void PlayCard(PointerDownEvent onClick)
    {
        int index = (onClick.currentTarget as CardUI).index;

        // UI
        cards.RemoveAt(index);
        root.RemoveAt(index);

        for (int i = index; i < cards.Count; i++)
        {
            cards[i].index--;
        }


        roundCards.PopCard(index).Play();
    }
}
