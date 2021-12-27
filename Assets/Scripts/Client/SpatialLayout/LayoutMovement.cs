using System;
using FlamyHail.Data;
using UnityEngine;

namespace FlamyHail.Client.SpatialLayout
{
    public class LayoutMovement : MonoBehaviour, IDisposable
    {
        private readonly SpatialLayout _spatialLayout;
        private readonly SpatialLayoutData _spatialLayoutData;

        private SpatialElement _currentElement;

        private float _lerpTime;

        public LayoutMovement(SpatialLayout spatialLayout, IStaticData staticData)
        {
            _spatialLayout = spatialLayout;
            _spatialLayoutData = staticData.SpatialLayoutData;
            
            Init();
        }

        private void Start()
        {
            //Init();
        }

        public void Init()
        {
            _lerpTime = 1f / _spatialLayoutData.ElementSpeed;
            _currentElement = _spatialLayout.TakeNearestEmptyElement();
        }

        private void Update()
        {
            if(!gameObject.activeInHierarchy || _currentElement == null)
                return;
            
            if (_spatialLayout.NextIsEmpty(_currentElement.Index))
            {
                _currentElement = _spatialLayout.TakeNextElement(_currentElement.Index);
            }

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
