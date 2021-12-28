using System;
using UnityEngine;

namespace FlamyHail.Data
{
    [Serializable]
    public class PrefabContainer<T>
    {
        [SerializeField]
        private Vector3 _spawnPosition;
        [SerializeField]
        private T _prefab;
        
        public T Prefab => _prefab;
        public Vector3 SpawnPosition => _spawnPosition;
    }
}