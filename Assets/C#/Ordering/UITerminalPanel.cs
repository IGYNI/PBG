using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Ordering
{
    public class UITerminalPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _orderPanel;
        [SerializeField] private Button _closeButton, _interactButton, _getOrderButton, _fixButton;
        [SerializeField] private BoxIcon[] _icons;
        private Terminal _terminal;

        private void Awake()
        {
            _terminal = FindObjectOfType<Terminal>();
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _closeButton.onClick.AddListener(HandleCloseClick);
            _interactButton.onClick.AddListener(Interact);
            _fixButton.onClick.AddListener(_terminal.Fix);
            _getOrderButton.onClick.AddListener(GetOrder);
            UpdateData();
        }

        private void GetOrder()
        {
            gameObject.SetActive(true);
            _terminal.CreateOrder();
            UpdateData();
        }

        private void HandleCloseClick()
        {
            _orderPanel.SetActive(false);
            _interactButton.gameObject.SetActive(true);
        }

        private void Interact()
        {
            _interactButton.gameObject.SetActive(false);
            _orderPanel.SetActive(true);

        }


        public void UpdateData()
        {
            _interactButton.gameObject.SetActive(_terminal.IsBroken == false && _orderPanel.activeSelf == false);
            _fixButton.gameObject.SetActive(_terminal.IsBroken);
            _fixButton.interactable = (_terminal.Player.InHands == _terminal.Sample_of_wrench);
            

            if(_orderPanel.activeSelf && _terminal.IsBroken)
            {
                _orderPanel.SetActive(false);
            }

            int i = 0;
            _getOrderButton.gameObject.SetActive(_terminal.CurrentOrder == null);

            foreach (var icon in _icons)
            {
                if (_terminal.CurrentOrder != null && i < _terminal.CurrentOrder.Boxes.Count)
                {
                    icon.Image.color = _terminal.CurrentOrder.Boxes.ElementAt(i).Color;
                    icon.CarIndex.text = _terminal.CurrentOrder.Boxes.ElementAt(i).CarIndex.ToString();
                    icon.gameObject.SetActive(true);
                    i++;
                    continue;
                }

                icon.gameObject.SetActive(false);
            }
        }

        public void Close()
        {
            _orderPanel.SetActive(false);
            _interactButton.gameObject.SetActive(true);
            _closeButton.onClick.RemoveListener(HandleCloseClick);
            _interactButton.onClick.RemoveListener(Interact);
            _fixButton.onClick.RemoveListener(_terminal.Fix);
            _getOrderButton.onClick.RemoveListener(GetOrder);
            _orderPanel.SetActive(false);
            _interactButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
            
            //_fixButton.gameObject.SetActive(false);
        }



    }
}
