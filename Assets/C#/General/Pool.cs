using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace General
{
    public class Pool<T> : IPool<T> where T : MonoBehaviour
    {
        private Func<T> _creator;
        private List<T> _elements;
        private Transform _container;

        public Pool(Func<T> creator, Transform container, int amount)
        {
            _creator = creator;
            _container = container;
            _elements = new List<T>();

            for (int i = 0; i < amount; i++)
                Create(false);
        }

        public int GetActiveCount() => _elements.Where(element => element.gameObject.activeSelf).Count();

        public T Get(Vector3 spawnPosition)
        {
            if (HasAvailable(out T availableElement))
            {
                availableElement.transform.position = spawnPosition;
                return availableElement;
            }

            T createdElement = Create(true);
            createdElement.transform.position = spawnPosition;
            return createdElement;
        }

        public void ReleaseAll()
        {
            _elements
                .Where(element => element.gameObject.activeSelf == true).ToList()
                .ForEach(element => 
                {
                    element.gameObject.SetActive(false);
                    element.transform.SetParent(_container);
                });
        }

        private bool HasAvailable(out T availableElement)
        {
            for (int i = 0; i < _elements.Count; i++)
            {
                T element = _elements[UnityEngine.Random.Range(0, _elements.Count)];

                if (element.gameObject.activeSelf == false)
                {
                    element.gameObject.SetActive(true);
                    availableElement = element;
                    return true;
                }
            }

            availableElement = null;
            return false;
        }

        protected T Create(bool isActive)
        {
            T element = _creator.Invoke();
            _elements.Add(element);
            element.transform.SetParent(_container.transform);
            element.gameObject.SetActive(isActive);
            return element;
        }
    }
}
