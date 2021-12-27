using System;
using BehaviourInject;
using FlamyHail.Data;
using UnityEngine;

namespace FlamyHail.Client.SpatialLayout
{
    public class LayoutMovement : MonoBehaviour, IDisposable
    {
        private SpatialLayout _spatialLayout;
        private SpatialLayoutData _spatialLayoutData;

        private SpatialElement _currentElement;

        private float _lerpTime;

        [Inject]
        public void Init(SpatialLayout spatialLayout, IStaticData staticData)
        {
            _spatialLayout = spatialLayout;
            _spatialLayoutData = staticData.SpatialLayoutData;

            ResetLayout();
        }

        private void ResetLayout()
        {
            _lerpTime = 1f / _spatialLayoutData.ElementSpeed;
            _currentElement = _spatialLayout.TakeTopElement();
        }

        private void Update()
        {
            if(!gameObject.activeInHierarchy || _currentElement == null)
                return;
            
            if (_spatialLayout.TryTakeNextElement(_currentElement, out SpatialElement nextSpatialElement))
            {
                _currentElement = nextSpatialElement;
            }
            
            if(_currentElement.Index == -1)
                return;

            if (Math.Abs(transform.position.y - _currentElement.Position.y) > 0.01f)
            {
                Vector3 targetPosition = new Vector3(transform.position.x, _currentElement.Position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, _lerpTime);
            }
        }

        public void Dispose()
        {
            _currentElement?.Realise();
            _currentElement = null;
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}
