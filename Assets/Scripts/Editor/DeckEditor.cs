using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.UIElements;


public partial class DeckEditor : EditorWindow
{
    void CreateGUI()
    {
        MultiColumnListView view = new();
        rootVisualElement.Add(view);
    }
    
    [MenuItem("Decks/Deck Editor _1")]
    public static void ShowWindow()
    {
        var v = GetWindow<DeckEditor>();
        v.maxSize = new(900, 900);
        v.minSize = new(600, 600);
        v.titleContent = new("Deck Editor");
    }


}
