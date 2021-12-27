using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlamyHail.Data
{
    [CreateAssetMenu(fileName = "SpawnTablesData", menuName = "FlamyHail/Data/SpawnTablesData", order = 1)]
    public class SpawnTablesData : ScriptableObject
    {
        [SerializeField]
        private int _initialCount;
        [SerializeField]
        private TableData _leftTable;
        [SerializeField]
        private TableData _rightTable;
        
        public float InitialCount => _initialCount;
        public TableData LeftTable => _leftTable;
        public TableData RightTable => _rightTable;
    }

    [Serializable]
    public class TableData
    {
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private Vector3 _spawnPosition;
        
        public GameObject Prefab => _prefab;
        public Vector3 SpawnPosition => _spawnPosition;
    }
}