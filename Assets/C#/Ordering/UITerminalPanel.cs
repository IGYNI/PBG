using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Ordering
{
    public class UITerminalPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _orderPanel;
        [SerializeField] private Button _closeButton, _interactButton, _getOrderButton;
        [SerializeField] private Image[] _icons;
        private Terminal _terminal;

        private void Awake()
        {
            _terminal = FindObjectOfType<Terminal>();
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
            _interactButton.onClick.AddListener(Interact);
            _getOrderButton.onClick.AddListener(_terminal.CreateOrder);
            UpdateData();
        }

        private void Interact()
        {
            _interactButton.gameObject.SetActive(false);
            _orderPanel.SetActive(true);
        }

        public void UpdateData()
        {
            _getOrderButton.gameObject.SetActive(_terminal.CurrentOrder == null);

            if (_terminal.CurrentOrder != null)
            {
                for (int i = 0; i < _terminal.CurrentOrder.Boxes.Count; i++)
                {
                    _icons[i].color = _terminal.CurrentOrder.Boxes.ElementAt(i).Color;
                }
            }
        }

        private void Close()
        {
            _orderPanel.SetActive(false);
            _interactButton.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
            _interactButton.onClick.RemoveListener(Interact);
            _getOrderButton.onClick.RemoveListener(_terminal.CreateOrder);
            _orderPanel.SetActive(false);
            _interactButton.gameObject.SetActive(true);
        }
    }
}
