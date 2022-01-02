using System;
using UnityEngine;

namespace FlamyHail.Data
{
    [Serializable]
    public class PrefabContainer
    {
        [SerializeField]
        private Vector3 _spawnPosition;
        [SerializeField]
        private Vector3 _scale;
        
        public Vector3 SpawnPosition => _spawnPosition;
        public Vector3 Scale => _scale;
    }
}