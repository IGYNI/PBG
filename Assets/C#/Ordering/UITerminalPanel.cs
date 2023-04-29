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

        public void Open()
        {
            gameObject.SetActive(true);
            _closeButton.onClick.AddListener(Close);
            _interactButton.onClick.AddListener(Interact);
            _getOrderButton.onClick.AddListener(GetOrder);
            UpdateData();
        }

        private void GetOrder()
        {
            _terminal.CreateOrder();
            UpdateData();
        }

        private void Interact()
        {
            _interactButton.gameObject.SetActive(false);
            _orderPanel.SetActive(true);
        }

        public void UpdateData()
        {
            int i = 0;
            _getOrderButton.gameObject.SetActive(_terminal.CurrentOrder == null);

            if (_terminal.CurrentOrder != null)
            {
                foreach (var icon in _icons)
                {
                    if (i < _terminal.CurrentOrder.Boxes.Count)
                    {
                        icon.color = _terminal.CurrentOrder.Boxes.ElementAt(i).Color;
                        icon.gameObject.SetActive(true);
                        i++;
                        continue;
                    }

                    icon.gameObject.SetActive(false);
                }
            }
        }

        public void Close()
        {
            _orderPanel.SetActive(false);
            _interactButton.gameObject.SetActive(true);
            _closeButton.onClick.RemoveListener(Close);
            _interactButton.onClick.RemoveListener(Interact);
            _getOrderButton.onClick.RemoveListener(GetOrder);
            _orderPanel.SetActive(false);
            _interactButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
