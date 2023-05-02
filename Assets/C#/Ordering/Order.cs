using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ordering
{
    [Serializable]
    public class Order
    {
        private List<BoxInfo> _boxes = new();

        public IReadOnlyCollection<BoxInfo> Boxes => _boxes;
        public bool IsCompleted => _boxes.Count == 0;

        public Order(Database database, int boxesCount, int carsCount)
        {
            for (int i = 0; i < boxesCount; i++)
            {
                Color color = database.GetRandomColor();
                Document document = database.GetRandomDocument();
                int carIndex = Random.Range(1, carsCount + 1);
                _boxes.Add(new BoxInfo(color, document, carIndex));
            }
        }

        public void Remove(BoxInfo box) => _boxes.Remove(box);

        public void Remove(IReadOnlyCollection<BoxInfo> boxes)
        {
            foreach (BoxInfo box in boxes)
            {
                _boxes.Remove(box);
            }
        }

        public void Complete() => _boxes.Clear();
    }
}
