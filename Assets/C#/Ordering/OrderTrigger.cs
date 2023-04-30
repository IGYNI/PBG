using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ordering
{
    public class OrderTrigger : MonoBehaviour
    {
        private List<BoxInfo> _orderedBoxes = new();

        [field: SerializeField] public int Index { get; }

        public void SetOrderedBoxes(IReadOnlyCollection<BoxInfo> boxes)
        {
            _orderedBoxes.AddRange(boxes);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PickUpItem bag))
            {
                bag.GetOrderedBoxes(_orderedBoxes, out IReadOnlyCollection<BoxInfo> findedBoxes);

                for (int i = 0; i < findedBoxes.Count; i++)
                {
                    _orderedBoxes.Remove(findedBoxes.ElementAt(i));
                }
            }
        }
    }
}