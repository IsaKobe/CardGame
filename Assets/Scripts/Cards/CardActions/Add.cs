using Assets.Scripts.Rounds;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Cards.CardActions
{
    //   [CreateAssetMenu(fileName="Add", menuName = "CardActions/Add",order = 1)]

    [Serializable]
    public class Add : CardAction
    {
        [SerializeField] int number;
        public override void DoAction(Card card)
        {
            Round.instance.SetNumber(Round.instance.currentNumber + card.value);
        }

        public override string GetContent()
        {
            return $"Adds the cards value to the current score.";
        }
    }
}
