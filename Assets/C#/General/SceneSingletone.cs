using UnityEngine;

namespace General
{
    public class SceneSingletone<T> : Singleton<T> where T : Component
    {
        protected override void Awake()
        {
            Instance = this as T;
            base.Awake();
        }
    }
}