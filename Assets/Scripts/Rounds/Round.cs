using Assets.Scripts.UI;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Rounds
{
    public class Round : MonoBehaviour, INotifyPropertyChanged
    {
        [SerializeField, Required] CardDeck startingDeck;
        [SerializeField] RoundCards roundCards;

        List<Card> deck;

        [CreateProperty] public float luckyNumber;
        [CreateProperty] public float currentNumber;

        [SerializeField] int handSize;

        [SerializeField, Required] ScoreDisplay display;
        [SerializeField, Required] HandDisply handDisply;

        public event PropertyChangedEventHandler PropertyChanged;

        public static Round instance;

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;

            deck = startingDeck.cards.Where(q => q.isStartCard).Select(q=> q.card).ToList();
            luckyNumber = startingDeck.luckyNumber;

            PropertyChanged?.Invoke(this, new(nameof(luckyNumber)));
            StartRound();
        }

        [ContextMenu("New round")]
        void StartRound()
        {
            currentNumber = UnityEngine.Random.Range(0, 100);
            PropertyChanged?.Invoke(this, new(nameof(currentNumber)));
            roundCards = new(deck, handSize);

            display.AttachData(this);
            handDisply.AttachData(roundCards);
        }

        public void SetNumber(float newValue)
        {
            currentNumber = newValue;
            CheckWin();
        }

        [ContextMenu("Check Win")]
        void CheckWin()
        {
            PropertyChanged?.Invoke(this, new(nameof(currentNumber)));

            if (currentNumber == luckyNumber)
                Debug.Log("Won");
        }
    }
}
