using FlamyHail.Data;
using UnityEngine;

namespace FlamyHail
{
    [CreateAssetMenu(fileName = "StaticData", menuName = "FlamyHail/Data/StaticData", order = 1)]
    public class StaticData : ScriptableObject, IStaticData
    {
        [SerializeField]
        private SpatialLayoutData _spatialLayoutData;
        [SerializeField]
        private SpawnTablesData _spawnTablesData;

        public SpatialLayoutData SpatialLayoutData => _spatialLayoutData;
        public SpawnTablesData SpawnTablesData => _spawnTablesData;
    }
}
