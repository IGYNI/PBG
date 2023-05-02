using General;
using Ordering;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StorageGeneration
{
    public class StorageGenerator : SceneSingletone<StorageGenerator>
    {
        [SerializeField] private Box _boxPrefab;
        private Stack[] _stacks;
        private List<Transform> _allPoints = new();
        private List<Box> _allBoxes = new();
        private Pool<Box> _boxPool;


        protected override void Init()
        {
            _boxPool = new(CreateBox, transform, 10);
            _stacks = FindObjectsByType<Stack>(FindObjectsSortMode.InstanceID);
            _stacks.ToList().ForEach(stack => _allPoints.AddRange(stack.BoxPoints));
        }

        private void OnEnable()
        {
            GameEvents.Instance.Subscribe(GameEventType.OrderCreated, Generate);
        }

        public void Generate() => Generate(Terminal.Instance.CurrentOrder.Boxes);

        public void Generate(IReadOnlyCollection<BoxInfo> orderedBoxes)
        {
            StopAllCoroutines();
            _boxPool.ReleaseAll();
            _allBoxes.Clear();

            StartCoroutine(GenerationRoutine(orderedBoxes));
        }

        private IEnumerator GenerationRoutine(IReadOnlyCollection<BoxInfo> orderedBoxes)
        {
            foreach (Transform point in _allPoints)
            {
                Box box = _boxPool.Get(point.transform.position);
                box.transform.rotation = Random.rotation;
                box.ResetByDefault();
                _allBoxes.Add(box);
                yield return null;
            }

            foreach (BoxInfo info in orderedBoxes)
            {
                IEnumerable<Box> defaultBoxes = _allBoxes.Where(box => box.IsDefault);
                defaultBoxes.ElementAt(Random.Range(0, defaultBoxes.Count())).SetInfo(info);
            }
        }

        private Box CreateBox() => Instantiate(_boxPrefab);

        private void OnDisable()
        {
            GameEvents.Instance.UnSubscribe(GameEventType.OrderCreated, Generate);
        }
    }
}
