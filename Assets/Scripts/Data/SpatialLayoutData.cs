using UnityEngine;

namespace FlamyHail.Data
{
    [CreateAssetMenu(fileName = "SpatialLayoutData", menuName = "FlamyHail/Data/SpatialLayoutData", order = 1)]
    public class SpatialLayoutData : ScriptableObject
    {
        [SerializeField]
        private float _startYPosition;
        [SerializeField]
        private float _distanceBetweenElements;
        [SerializeField]
        private int _elementCount;
        [SerializeField]
        private float _elementSpeed;

        public float StartYPosition => _startYPosition;
        public float DistanceBetweenElements => _distanceBetweenElements;
        public int ElementCount => _elementCount;
        public float ElementSpeed => _elementSpeed;
    }
}
