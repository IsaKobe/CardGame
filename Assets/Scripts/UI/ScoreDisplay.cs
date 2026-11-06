using Assets.Scripts.Rounds;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        private void Awake()
        {
            PanelRenderer renderer = GetComponent<PanelRenderer>();
            renderer.RegisterUIReloadCallback(OnReload);
        }

        Label luckyLabel;
        Label currentLabel;

        void OnReload(PanelRenderer renderer, VisualElement element, int version)
        {
            luckyLabel = element.Q<Label>("Lucky");
            currentLabel = element.Q<Label>("Current");
            SetBindings();
        }

        Round round;
        
        public void AttachData(Round round)
        {
            this.round = round;
            SetBindings();
        }

        void SetBindings()
        {
            if (luckyLabel != null)
            {
                DataBinding dataBinding = new()
                {
                    dataSource = round,
                    dataSourcePath = new(nameof(Round.luckyNumber))
                };
                dataBinding.sourceToUiConverters.AddConverter((ref float lucky) => { return $"Lucky: {lucky}"; });
                luckyLabel.SetBinding(new("text"), dataBinding);
            }
            if (currentLabel != null)
            {
                DataBinding dataBinding = new()
                {
                    dataSource = round,
                    dataSourcePath = new(nameof(Round.currentNumber))
                };
                dataBinding.sourceToUiConverters.AddConverter((ref float current) => { return $"Current: {current}"; });
                currentLabel.SetBinding(new("text"), dataBinding);
            }
        }
    }
}
