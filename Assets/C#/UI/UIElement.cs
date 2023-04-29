using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class UIElement : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;

        protected virtual void OnEnable()
        {
            if (_closeButton)
                _closeButton.onClick.AddListener(Close);
        }

        public abstract void Open();

        public abstract void Close();

        protected virtual void OnDisable()
        {
            if (_closeButton)
                _closeButton.onClick.RemoveListener(Close);
        }
    }
}