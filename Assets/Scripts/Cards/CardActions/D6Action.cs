using System;
using System.Collections.Generic;
using Assets.Scripts.Rounds;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class D6Action : CardAction
{
    
    private void Do(int i)
    {
        Round.instance.SetNumber(Round.instance.currentNumber + (i * (new Random().Next()%6+1)));
    }
    public override void DoAction(Card card)
    {
            ChoiceMenu.Choice choice = new();
            choice.label = "Add";
            choice.function = () => { Do(1);};
            
            ChoiceMenu.Choice choice2 = new();
            choice2.label = "Subtract";
            choice2.function = () => { Do(-1);};
            GameObject.FindAnyObjectByType<ChoiceDisplay>().AddMenu("d6", new List<ChoiceMenu.Choice>() {choice, choice2 });
        
    }

    public override string GetContent()
    {
        return $"Flip A Coin - Your call";
    }
}