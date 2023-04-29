using General;
using System.Collections.Generic;
using UnityEngine;

namespace StorageGeneration
{
    public class StorageGenerator : SceneSingletone<StorageGenerator>
    {
        private Stack[] _stacks;

        protected override void Init()
        {
            _stacks = FindObjectsByType<Stack>(FindObjectsSortMode.InstanceID);
        }

        public void Generate(IReadOnlyCollection<BoxInfo> orderedBoxes)
        {

        }
    }
}
