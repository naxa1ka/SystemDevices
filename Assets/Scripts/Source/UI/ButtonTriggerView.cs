using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class ButtonTriggerView : MonoBehaviour, ITriggerView
    {
        [SerializeField] private Button _button;

        public event Action Clicked;

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Clicked?.Invoke();
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }
    }
}