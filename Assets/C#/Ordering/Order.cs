using System;
using System.Collections.Generic;

namespace Ordering
{
    [Serializable]
    public class Order
    {
        private List<BoxInfo> _boxes = new();

        public IReadOnlyCollection<BoxInfo> Boxes => _boxes;
        public bool IsCompleted => _boxes.Count == 0;

        public Order(Database database, int boxesCount)
        {
            int carsCount = 4;

            for (int i = 0; i < boxesCount; i++)
            {
                _boxes.Add(new BoxInfo(database.GetRandomColor(), /*database.GetRandomSticker(),*/ UnityEngine.Random.Range(1, carsCount)));
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
    }
}
