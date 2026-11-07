using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MenuAction : CardAction
{
    public override void DoAction(Card card)
    {
        ChoiceMenu.Choice choice = new ChoiceMenu.Choice();
        choice.label = "Test";
        choice.function = () => { Debug.Log(choice.label); };
        
        ChoiceMenu.Choice choice2 = new ChoiceMenu.Choice();
        choice2.label = "Test2";
        choice2.function = () => { Debug.Log(choice2.label); };
        GameObject.FindAnyObjectByType<ChoiceDisplay>().AddMenu("actionTest", new List<ChoiceMenu.Choice>{choice, choice2});
    }

    public override string GetContent()
    {
        return $"Sample menu action";
    }
}