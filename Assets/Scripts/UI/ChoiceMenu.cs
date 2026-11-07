using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
[UxmlElement]
public partial class ChoiceMenu : VisualElement
{
    public ChoiceMenu() {}
    public struct Choice
    {
        public string label;
        public Action function;
    }
    private readonly Button button;
    public bool chosen = false;
    public ChoiceMenu(string id, List<Choice> choices, ChoiceDisplay choiceDisplay)
    {
        foreach (var choice in choices) {
            Add(button = new Button());
            button.text = choice.label;
            var c = choice;
            button.clicked += () => { c.function();
                choiceDisplay.choicemenus.Remove(id);
                choiceDisplay.root.Remove(choiceDisplay.menus[id]);
                choiceDisplay.menus.Remove(id);
                if (choiceDisplay.menus.Count == 0)
                {
                    choiceDisplay.root.style.display = DisplayStyle.None;
                }
            };
        }
    }
}