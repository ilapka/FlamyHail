using FlamyHail.Client.Views;
using UnityEngine;

namespace FlamyHail.Data
{
    [CreateAssetMenu(fileName = "SpawnTablesData", menuName = "FlamyHail/Data/SpawnTablesData", order = 1)]
    public class SpawnTablesData : ScriptableObject
    {
        [SerializeField]
        private int _initialCount;
        [SerializeField]
        private PrefabContainer leftTableContainer;
        [SerializeField]
        private PrefabContainer rightTableContainer;
        
        public float InitialCount => _initialCount;
        public PrefabContainer LeftTableContainer => leftTableContainer;
        public PrefabContainer RightTableContainer => rightTableContainer;
    }
}