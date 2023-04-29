using System.Collections.Generic;
using UnityEngine;

namespace StorageGeneration
{
    public class Stack : MonoBehaviour
    {
        [SerializeField] private Box _boxPrefab;
        [SerializeField] private Transform[] _boxPoints;

        public IReadOnlyCollection<Transform> BoxPoints => _boxPoints;
    }
}
