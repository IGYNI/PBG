using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ordering
{
    [Serializable]
    public class Order
    {
        [SerializeField] private BoxInfo[] _boxes;

        public IReadOnlyCollection<BoxInfo> Boxes => _boxes;

        public Order(BoxInfo[] boxes)
        {
            _boxes = boxes;
        }
    }
}
