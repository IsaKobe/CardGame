using System.Collections.Generic;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class ChoiceDisplay : MonoBehaviour
{
    
    
    [SerializeField] public Dictionary<string, List<ChoiceMenu.Choice>> choicemenus = new();
    public Dictionary<string, ChoiceMenu> menus = new();

    public VisualElement root;
    void Reload(PanelRenderer renderer, VisualElement element, int version)
    {
        root = element.Q("Root");
        if (choicemenus.Count > 0)
        {
            root.style.display = DisplayStyle.Flex;
        }
        else
        {
            root.style.display = DisplayStyle.None;
        }
        SpawnElements();
    }


    void SpawnElements()
    {
        root.Clear();
        menus = new();
        foreach (var lchoices in choicemenus)
        {
            ChoiceMenu menu = new(lchoices.Key,lchoices.Value, this);
            menus.Add(lchoices.Key, menu);
            root.Add(menu);
        }
    }

    public void AddMenu(string id, List<ChoiceMenu.Choice> choices)
    {
        choicemenus.Add(id, choices);
        
        
        PanelRenderer renderer = GetComponent<PanelRenderer>();
        renderer.UnregisterUIReloadCallback(Reload);
        renderer.RegisterUIReloadCallback(Reload);
    }
}