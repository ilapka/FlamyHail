using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlamyHail.Pooler
{
    [CreateAssetMenu(fileName = "PoolerData", menuName = "FlamyHail/Data/PoolerData", order = 1)]
    public class PoolerData : ScriptableObject
    {
        [SerializeField]
        private List<PoolData> _pools;
        public List<PoolData> Pools => _pools;
    }
    
    [Serializable]
    public class PoolData
    {
        [SerializeField]
        private PoolObject _prefab;
        [SerializeField] [Range(0, 100)]
        private int _startCapacity;

        public PoolObject Prefab => _prefab;
        public int StartCapacity => _startCapacity;
    }
}
