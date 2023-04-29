using General;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace Ordering
{
    public class Terminal : SceneSingletone<Terminal>
    {
        [SerializeField] private BoxInfo[] _allBoxes;
        [SerializeField] private Vector3 _triggerOffset, _triggerSize;
        [SerializeField] private LayerMask _playerLayerMask;
        [SerializeField] private UITerminalPanel _uiPanel;
        public bool _isInteract;

        public bool IsBroken { get; private set; }

        [field: SerializeField, Range(1, 10)] public int OrderBoxesCount { get; set; } = 3;
        public Order CurrentOrder { get; private set; }

        public void CreateOrder()
        {
            BoxInfo[] randomBoxes = new BoxInfo[OrderBoxesCount];

            for (int i = 0; i < OrderBoxesCount; i++)
            {
                randomBoxes[i] = _allBoxes[Random.Range(0, _allBoxes.Length)];
            }

            CurrentOrder = new(randomBoxes);
            GameEvents.Instance.Dispatch(GameEventType.OrderCreated);
        }

        [Button("Complete")]
        public void Complete()
        {
            if (Application.isPlaying == false)
                return;

            Complete(CurrentOrder.Boxes);
        }

        public void Complete(IReadOnlyCollection<BoxInfo> boxes)
        {
            if (boxes.Equals(CurrentOrder.Boxes))
            {
                Debug.Log("Complete");
                OrderBoxesCount++;
                CurrentOrder = null;
                _uiPanel.UpdateData();
                GameEvents.Instance.Dispatch(GameEventType.OrderCompleted);
            }
        }

        [Button("Broke")]
        public void Broke()
        {
            if (Application.isPlaying == false)
                return;

            if (IsBroken)
                return;

            IsBroken = true;

            if (_isInteract)
                _uiPanel.Close();
        }

        [Button("Fix")]
        public void Fix()
        {
            if (Application.isPlaying == false)
                return;

            if (IsBroken == false)
                return;

            IsBroken = false;

            if (_isInteract)
                _uiPanel.Open();
        }

        private void FixedUpdate()
        {
            if (Physics.CheckBox(transform.position + _triggerOffset, _triggerSize, transform.rotation, _playerLayerMask))
            {
                if (_isInteract == false)
                {
                    _isInteract = true;

                    if (IsBroken == false)
                        _uiPanel.Open();
                }
            }
            else if (_isInteract)
            {
                _isInteract = false;
                _uiPanel.Close();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + _triggerOffset, _triggerSize);
        }
    }
}
