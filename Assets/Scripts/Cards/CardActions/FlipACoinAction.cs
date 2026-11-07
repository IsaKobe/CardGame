using System;
using System.Collections.Generic;
using Assets.Scripts.Rounds;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class FlipACoinAction : CardAction
{
    
    private void Do(int i)
    {
        Round.instance.SetNumber(Round.instance.currentNumber + (i * (1 - new Random().Next()%2 * 2)));
    }
    public override void DoAction(Card card)
    {
        List<ChoiceMenu.Choice> choices = new();
        for (int i = 1; i < 6; i++)
        {
            ChoiceMenu.Choice choice = new();
            choice.label = i.ToString();
            var i1 = i;
            choice.function = () => { Do(i1);};
            choices.Add(choice);
        }
        
        GameObject.FindAnyObjectByType<ChoiceDisplay>().AddMenu("flipacoin", choices);
    }

    public override string GetContent()
    {
        return $"Flip A Coin - Your call";
    }
}