using System.Collections.Generic;
using FlamyHail.Data;
using FlamyHail.DOM;
using UnityEngine;

namespace FlamyHail.Client.SpatialLayout
{
    public class SpatialLayout
    {
        private readonly SpatialLayoutData _spatialLayoutData;

        private List<LayoutPoint> _verticalLayout;

        private LayoutPoint _topPoint;
        
        public SpatialLayout(IStaticData staticData)
        {
            _spatialLayoutData = staticData.SpatialLayoutData;
        }

        public void CreateVerticalLayout()
        {
            _verticalLayout = new List<LayoutPoint>(_spatialLayoutData.PointsCount);

            float currentY = _spatialLayoutData.StartYPosition;

            for (var index = 0; index < _spatialLayoutData.PointsCount; index++)
            {
                LayoutPoint point = new LayoutPoint(index,new Vector3(0, currentY, 0), _spatialLayoutData.TriggerGroupsByIndex[index]);
                _verticalLayout.Add(point);
                
                currentY += _spatialLayoutData.DistanceBetweenPoints;
            }

            _topPoint = _verticalLayout[_verticalLayout.Count - 1];
        }

        public LayoutPoint TakeTopPoint()
        {
            if (!_topPoint.IsEmpty)
                return LayoutPoint.MOCK;
            
            _topPoint.Take();
            return _topPoint;
        }

        public bool TryTakeNextPoint(LayoutPoint currentPoint, out LayoutPoint nextLayoutPoint)
        {
            nextLayoutPoint = null;
            
            //if it is an element in the queue to hit the layout
            if (currentPoint.Index == LayoutPoint.MOCK.Index)
            {
                if (_topPoint.IsEmpty)
                {
                    nextLayoutPoint = _topPoint;
                    nextLayoutPoint.Take();
                    currentPoint.Realise();
                    return true;
                }
                
                return false;
            }

            int nextIndex = currentPoint.Index - 1;
            if (nextIndex < 0)
                return false;

            if (_verticalLayout[nextIndex].IsEmpty)
            {
                nextLayoutPoint = _verticalLayout[nextIndex];
                nextLayoutPoint.Take();
                currentPoint.Realise();
                return true;
            }

            return false;
        }

        public List<LayoutPoint> VerticalLayout => _verticalLayout;
    }
}
