using General;
using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ordering
{
    public class Terminal : SceneSingletone<Terminal>, IBrokable
    {
        [SerializeField] private Database _database;
        [SerializeField] private Vector3 _triggerOffset, _triggerSize;
        [SerializeField] private LayerMask _playerLayerMask;
        [SerializeField] private UITerminalPanel _uiPanel;
        public bool _isInteract;
        public Inventory Player;
        public  Tool Sample_of_wrench;

        public bool IsBroken { get; private set; }

        [field: SerializeField, Range(1, 10)] public int OrderBoxesCount { get; set; } = 1;
        public Order CurrentOrder { get; private set; }

        public void CreateOrder()
        {
            CurrentOrder = new(_database, OrderBoxesCount, 3);
            GameEvents.Instance.Dispatch(GameEventType.OrderCreated);
        }

        [Button("Complete")]
        public void Complete()
        {
            if (Application.isPlaying == false)
                return;

            if (CurrentOrder != null)
            {
                List<BoxInfo> boxes = new(CurrentOrder.Boxes);
                Complete(boxes);
            }
        }

        public void Complete(IReadOnlyCollection<BoxInfo> boxes)
        {
            CurrentOrder.Remove(boxes);

            if (CurrentOrder.IsCompleted)
            {
                if (OrderBoxesCount >= 8)
                {
                    OrderBoxesCount = 8;
                }
                else
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
                _uiPanel.UpdateData();
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
            {
                _uiPanel.UpdateData();
            }
            
        }

        private void FixedUpdate()
        {
            if (Physics.CheckBox(transform.position + _triggerOffset, _triggerSize, transform.rotation, _playerLayerMask))
            {
                if (_isInteract == false && PlayerState.Instance.CurrentState == PlayerStates.Default)
                {
                    PlayerState.Instance.CurrentState = PlayerStates.InTerminal;
                    _isInteract = true;
                    _uiPanel.Open();
                }
            }
            else if (_isInteract && PlayerState.Instance.CurrentState == PlayerStates.InTerminal)
            {
                PlayerState.Instance.CurrentState = PlayerStates.Default;
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
