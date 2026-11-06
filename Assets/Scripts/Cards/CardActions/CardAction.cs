using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public abstract class CardAction
{
    public abstract void DoAction(Card card);
    public abstract string GetContent();
}