using UnityEngine;

namespace Ordering
{
    [RequireComponent(typeof(BoxCollider))]
    public class Terminal : MonoBehaviour
    {
        [SerializeField] private BoxInfo[] _allBoxes;
        [SerializeField] private Vector3 _triggerOffset, _triggerSize;
        [SerializeField] private LayerMask _playerLayerMask;
        [SerializeField] private UITerminalPanel _uiPanel;
        private BoxCollider _collider;
        public bool _isInteract;

        [field: SerializeField] public int OrderBoxesCount { get; set; } = 3;
        public Order CurrentOrder { get; private set; }

        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
        }

        public void CreateOrder()
        {
            BoxInfo[] randomBoxes = new BoxInfo[OrderBoxesCount];

            for (int i = 0; i < OrderBoxesCount; i++)
            {
                randomBoxes[i] = _allBoxes[Random.Range(0, _allBoxes.Length)];
            }

            CurrentOrder = new(randomBoxes);
        }

        private void FixedUpdate()
        {
            if (Physics.CheckBox(transform.position + _triggerOffset, _triggerSize, transform.rotation, _playerLayerMask))
            {
                if (_isInteract == false)
                {
                    _isInteract = true;
                    _uiPanel.gameObject.SetActive(true);
                    
                }
            }
            else if (_isInteract)
            {
                _isInteract = false;
                _uiPanel.gameObject.SetActive(false);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + _triggerOffset, _triggerSize);
        }
    }
}
