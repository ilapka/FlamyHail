using FlamyHail.Client.Tables;
using UnityEngine;

namespace FlamyHail.Data
{
    [CreateAssetMenu(fileName = "SpawnTablesData", menuName = "FlamyHail/Data/SpawnTablesData", order = 1)]
    public class SpawnTablesData : ScriptableObject
    {
        [SerializeField]
        private int _initialCount;
        [SerializeField]
        private PrefabContainer<Table> leftTableContainer;
        [SerializeField]
        private PrefabContainer<Table> rightTableContainer;
        
        public float InitialCount => _initialCount;
        public PrefabContainer<Table> LeftTableContainer => leftTableContainer;
        public PrefabContainer<Table> RightTableContainer => rightTableContainer;
    }
}