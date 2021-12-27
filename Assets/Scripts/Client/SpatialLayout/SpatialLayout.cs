using System;
using System.Collections.Generic;
using System.Linq;
using FlamyHail.Data;
using UnityEngine;

namespace FlamyHail.Client.SpatialLayout
{
    public class SpatialLayout
    {
        private readonly SpatialLayoutData _spatialLayoutData;

        private List<SpatialElement> _verticalLayout;

        private SpatialElement _topElement;
        
        public SpatialLayout(IStaticData staticData)
        {
            _spatialLayoutData = staticData.SpatialLayoutData;
        }

        public void CreateVerticalLayout()
        {
            _verticalLayout = new List<SpatialElement>(_spatialLayoutData.ElementCount);

            float currentY = _spatialLayoutData.StartYPosition;

            for (var index = 0; index < _spatialLayoutData.ElementCount; index++)
            {
                SpatialElement element = new SpatialElement(index,new Vector3(0, currentY, 0));
                _verticalLayout.Add(element);
                
                currentY += _spatialLayoutData.DistanceBetweenElements;
            }

            _topElement = _verticalLayout[_verticalLayout.Count - 1];
        }

        public SpatialElement TakeTopElement()
        {
            if (!_topElement.IsEmpty)
                return SpatialElement.MOCK;
            
            _topElement.Take();
            return _topElement;
        }

        public bool TryTakeNextElement(SpatialElement currentElement, out SpatialElement nextSpatialElement)
        {
            nextSpatialElement = null;
            
            //if it is an element in the queue to hit the layout
            if (currentElement.Index == SpatialElement.MOCK.Index)
            {
                if (_topElement.IsEmpty)
                {
                    nextSpatialElement = _topElement;
                    nextSpatialElement.Take();
                    currentElement.Realise();
                    return true;
                }
                
                return false;
            }

            int nextIndex = currentElement.Index - 1;
            if (nextIndex < 0)
                return false;

            if (_verticalLayout[nextIndex].IsEmpty)
            {
                nextSpatialElement = _verticalLayout[nextIndex];
                nextSpatialElement.Take();
                currentElement.Realise();
                return true;
            }

            return false;
        }
    }
}
