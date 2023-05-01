using System;
using General;
using Ordering;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

namespace StorageGeneration
{
    public class StorageGenerator : SceneSingletone<StorageGenerator>
    {
        [SerializeField] private Box _boxPrefab;
        [SerializeField] private string[] TypesOfStickers;
        private Stack[] _stacks;
        private List<Transform> _allPoints = new();
        private List<Box> _allBoxes = new();
        private Pool<Box> _boxPool;


        protected override void Init()
        {
            _boxPool = new(CreateBox, transform, 500);
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
            _boxPool.ReleaseAll();
            _allPoints.ForEach(point => _allBoxes.Add(_boxPool.Get(point.transform.position)));
            _allBoxes.ForEach(box => box.ResetByDefault());

            foreach (BoxInfo boxInfo in orderedBoxes)
            {
                int CuntOfStickers;
                string[] StickersInBox = new string[4];
                CuntOfStickers = UnityEngine.Random.Range(1, 4);
                for (int i = 0; i < CuntOfStickers; i++)
                {
                    int[] numbers = new int[3];
                    int namenumber = UnityEngine.Random.Range(0, TypesOfStickers.Length);
                    
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if(namenumber == numbers[k])
                        {
                            namenumber += 1;
                        }
                    }
                    StickersInBox[i] = TypesOfStickers[namenumber];
                }
                boxInfo.Stickers = StickersInBox;
                boxInfo.CatOfBox = GetComponent<ListOfItemsNames>().Categorys[UnityEngine.Random.Range(0, GetComponent<ListOfItemsNames>().Categorys.Length)];
                IEnumerable<Box> defaultBoxes = _allBoxes.Where(box => box.IsDefault);
                defaultBoxes.ElementAt(UnityEngine.Random.Range(0, defaultBoxes.Count())).SetInfo(boxInfo);
            }
        }

        private Box CreateBox() => Instantiate(_boxPrefab);

        private void OnDisable()
        {
            GameEvents.Instance.UnSubscribe(GameEventType.OrderCreated, Generate);
        }
        
    }
}
