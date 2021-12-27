using FlamyHail.Data;
using UnityEngine;

namespace FlamyHail
{
    [CreateAssetMenu(fileName = "StaticData", menuName = "FlamyHail/Data/StaticData", order = 1)]
    public class StaticData : ScriptableObject, IStaticData
    {
        [SerializeField]
        private SpatialLayoutData spatialLayoutData;

        public SpatialLayoutData SpatialLayoutData => spatialLayoutData;
    }
}
