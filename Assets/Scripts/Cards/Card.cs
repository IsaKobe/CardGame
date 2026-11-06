using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Card
{
    public int value;

    [Header("Visual Data")]
    public string name;
    public Texture2D sprite;
    public string description;

    [Header("Events")]
    [SerializeReference] List<CardAction> onDraw;
    [SerializeReference] List<CardAction> onPlay;
    [SerializeReference] List<CardAction> onDiscard;
    [SerializeReference] List<CardAction> onExhaust;

    public string GetContentText()
    {
        string s = description;
        s += "<br>" + string.Join("<br>", onPlay.Select(q => q.GetContent()));
        return s;
    }

    public void Draw()
    {
        foreach (var item in onDraw)
        {
            item.DoAction(this);
        }
    }

    public void Play()
    {
        foreach (var item in onPlay)
        {
            item.DoAction(this);
        }
    }

    public void Discard()
    {
        foreach (var item in onDiscard)
        {
            item.DoAction(this);
        }
    }

    public void Exhaust()
    {
        foreach (var item in onExhaust)
        {
            item.DoAction(this);
        }
    }
}
