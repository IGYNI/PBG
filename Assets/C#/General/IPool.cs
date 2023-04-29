using UnityEngine;

namespace General
{
    public interface IPool<T> 
    {
        int GetActiveCount();
        T Get(Vector3 spawnPosition);
        void ReleaseAll();
    }
}
