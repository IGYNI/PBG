using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ordering
{
    public class OrderTrigger : MonoBehaviour
    {
        [field: SerializeField] public int Index { get; private set; }
        public bool IsCompleted { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (Terminal.Instance.CurrentOrder == null)
                return;

            if (other.TryGetComponent(out PickUpItem bag))
            {
                if (bag.IsEmpty)
                    return;

                bag.GetOrderedBoxes(Terminal.Instance.CurrentOrder.Boxes
                    .Where(orderedBox => orderedBox.CarIndex == Index), out IReadOnlyCollection<BoxInfo> findedBoxes);

                Terminal.Instance.Complete(findedBoxes);
            }
        }
    }
}