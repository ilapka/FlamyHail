using FlamyHail.Pooler;
using UnityEngine;

namespace FlamyHail.Data
{
    [CreateAssetMenu(fileName = "StaticData", menuName = "FlamyHail/Data/StaticData", order = 1)]
    public class StaticData : ScriptableObject, IStaticData
    {
        [SerializeField]
        private SpatialLayoutData _spatialLayoutData;
        [SerializeField]
        private SpawnTablesData _spawnTablesData;
        [SerializeField]
        private PoolerData _poolerData;

        public SpatialLayoutData SpatialLayoutData => _spatialLayoutData;
        public SpawnTablesData SpawnTablesData => _spawnTablesData;
        public PoolerData PoolerData => _poolerData;
    }
}
