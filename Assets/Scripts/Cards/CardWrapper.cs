using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Cards
{
    [Serializable]
    public struct CardWrapper
    {
        public Card card;
        public bool isStartCard;
    }
}
