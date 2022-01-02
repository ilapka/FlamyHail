using System;
using BehaviourInject;
using FlamyHail.Data;
using FlamyHail.DOM;
using UnityEngine;

namespace FlamyHail.Client.Views
{
    public class LayoutMovement : MonoBehaviour
    {
        private Client.SpatialLayout.SpatialLayout _spatialLayout;
        private SpatialLayoutData _spatialLayoutData;

        private LayoutPoint _currentPoint;
        
        public event Action<LayoutPoint> OnLayoutPointChanged;
        
        [Inject]
        public void Init(Client.SpatialLayout.SpatialLayout spatialLayout, IStaticData staticData)
        {
            _spatialLayout = spatialLayout;
            _spatialLayoutData = staticData.SpatialLayoutData;
        }

        public void Activate()
        {
            CurrentPoint = _spatialLayout.TakeTopPoint();
        }

        private void Update()
        {
            if(!gameObject.activeInHierarchy || CurrentPoint == null)
                return;
            
            if (_spatialLayout.TryTakeNextPoint(CurrentPoint, out LayoutPoint nextLayoutPoint))
            {
                CurrentPoint = nextLayoutPoint;
            }
            
            if(CurrentPoint.Index == -1)
                return;

            if (Math.Abs(transform.position.y - CurrentPoint.Position.y) > 0.01f)
            {
                Vector3 targetPosition = new Vector3(transform.position.x, CurrentPoint.Position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, _spatialLayoutData.PointAgentSpeed);
            }
            else
            {
                if(CurrentPoint.AgentIsMoving)
                    CurrentPoint.Arrive();
            }
        }

        public void Deactivate()
        {
            CurrentPoint?.Realise();
            CurrentPoint = null;
        }

        private LayoutPoint CurrentPoint
        {
            get
            {
                return _currentPoint;
            }
            set
            {
                _currentPoint = value;
                OnLayoutPointChanged?.Invoke(_currentPoint);
            }
        }
    }
}
