using System.Collections.Generic;
using UnityEngine;

namespace FlamyHail.Client.SpatialLayout
{
    public class LayoutMovement : MonoBehaviour
    {
        private HashSet<Transform> _layoutMembers;
        
        void Start()
        {
        
        }

        void Update()
        {
            foreach (var moving in _layoutMembers)
            {
                if(!moving.gameObject.activeInHierarchy)
                    continue;
                
                
            }
        }

        public void RegisterLayoutMoving(Transform transform)
        {
            _layoutMembers.Add(transform);
        }
        
        public void UnregisterLayoutMoving(Transform transform)
        {
            _layoutMembers.Remove(transform);
        }
    }
}
