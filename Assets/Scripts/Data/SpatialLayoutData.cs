using System.Collections.Generic;
using UnityEngine;

namespace FlamyHail.Data
{
    [CreateAssetMenu(fileName = "SpatialLayoutData", menuName = "FlamyHail/Data/SpatialLayoutData", order = 1)]
    public class SpatialLayoutData : ScriptableObject
    {
        [SerializeField]
        private float _startYPosition;
        [SerializeField]
        private float _distanceBetweenPoints;
        [SerializeField]
        private int _pointsCount;
        [SerializeField]
        private float _pointAgentSpeed;
        [SerializeField]
        private float _agentArrivedTolerance;
        [SerializeField]
        private List<LayoutPointTrigger> _triggers;
        
        public float StartYPosition => _startYPosition;
        public float DistanceBetweenPoints => _distanceBetweenPoints;
        public int PointsCount => _pointsCount;
        public float PointAgentSpeed => _pointAgentSpeed;
        public float AgentArrivedTolerance => _agentArrivedTolerance;
        public List<LayoutPointTrigger> Triggers => _triggers;
    }
}
