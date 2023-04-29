using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public abstract class UIElement : UIBehaviour
    {
        [SerializeField] protected Button _closeButton;

        protected UIMediator _mediator;

        protected override void Awake()
        {
            base.Awake();
            _mediator = GetComponentInParent<UIMediator>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (_closeButton)
                _closeButton.onClick.AddListener(HandleClose);
        }

        public abstract void Hide();

        private void HandleClose() => _mediator.HidePopup();

        public abstract void Show();

        protected override void OnDisable()
        {
            base.OnDisable();

            if (_closeButton)
                _closeButton.onClick.RemoveListener(HandleClose);
        }
    }
}