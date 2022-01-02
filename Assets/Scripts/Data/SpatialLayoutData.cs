using System;
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
        private List<LayoutPointTrigger> _triggers;
        
        private List<LayoutPointTrigger>[] _triggerGroupsByIndex;
        
        public float StartYPosition => _startYPosition;
        public float DistanceBetweenPoints => _distanceBetweenPoints;
        public int PointsCount => _pointsCount;
        public float PointAgentSpeed => _pointAgentSpeed;
        public List<LayoutPointTrigger>[] TriggerGroupsByIndex => _triggerGroupsByIndex;

        private void OnValidate()
        {
            _triggerGroupsByIndex = new List<LayoutPointTrigger>[PointsCount];

            foreach (LayoutPointTrigger trigger in _triggers)
            {
                List<LayoutPointTrigger> triggerGroup = _triggerGroupsByIndex[trigger.PointIndex];
                
                if(triggerGroup == null)
                    triggerGroup = new List<LayoutPointTrigger>();
                
                triggerGroup.Add(trigger);

                _triggerGroupsByIndex[trigger.PointIndex] = triggerGroup;
            }
        }
    }
}
