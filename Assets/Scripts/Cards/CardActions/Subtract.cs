using Assets.Scripts.Rounds;
using System;
using System.Collections.Generic;
using System.Text;

[Serializable]
public class Subtract : CardAction
{
    public override void DoAction(Card card)
    {
        Round.instance.SetNumber(Round.instance.currentNumber - card.value);
    }

    public override string GetContent()
    {
        return $"Subtracts the cards value to the current score.";
    }
}
