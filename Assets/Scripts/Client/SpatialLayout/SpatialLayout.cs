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
        }

        public SpatialElement TakeNearestEmptyElement()
        {
            for (var index = _verticalLayout.Count - 1; index >= 0; index--)
            {
                SpatialElement element = _verticalLayout[index];

                if (!element.IsEmpty)
                {
                    if(index >= _verticalLayout.Count - 1)
                        break;

                    _verticalLayout[index - 1].Take();
                    return _verticalLayout[index - 1];
                }
            }
            
            return null;
        }

        public bool NextIsEmpty(int currentIndex)
        {
            if(currentIndex < 0)
                throw new Exception($"Current index has a negative value");

            if (currentIndex + 1 >= _verticalLayout.Count)
                return false;
            
            return _verticalLayout[currentIndex + 1].IsEmpty;
        }

        public SpatialElement TakeNextElement(int currentIndex)
        {
            if(currentIndex < 0)
                throw new Exception($"Current index has a negative value");

            if (currentIndex + 1 >= _verticalLayout.Count)
                return null;

            return _verticalLayout[currentIndex + 1];
        }
    }
}
