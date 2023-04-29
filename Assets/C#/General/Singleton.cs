using UnityEngine;

namespace General
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; protected set; }
        protected virtual void Awake() => Init();
        protected virtual void Init() { }
    }
}