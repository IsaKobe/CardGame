using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    public class CardUI : VisualElement
    {
        public int index;


        readonly Label title;
        readonly Image image;
        readonly Label content;
        readonly Label value;
        public CardUI(int i, Card item, EventCallback<PointerDownEvent> playCard)
        {
            Add(title = new Label("Title") {name = "Title" });
            Add(image = new Image());
            Add(content = new Label("Lorem ipsuma apsum dolur test 1223") { name = "Content", enableRichText = true });
            Add(value = new Label("#") { name = "Value"});

            SetCard(i, item, playCard);
        }


        public void SetCard(int i, Card card, EventCallback<PointerDownEvent> onClick)
        {
            index = i;
            UnregisterAllRemovableCallbacks();
            RegisterCallback(onClick, CallbackOptions.Removable);

            title.text = card.name;
            image.image = card.sprite;
            content.text = card.GetContentText();
            value.text = card.value.ToString();
        }
    }
}
