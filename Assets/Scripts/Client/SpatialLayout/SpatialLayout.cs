using System.Collections.Generic;
using FlamyHail.Data;
using UnityEngine;

namespace FlamyHail.Client.SpatialLayout
{
    public class SpatialLayout
    {
        private readonly SpatialLayoutData _data;

        private List<SpatialElement> _verticalLayout;
        
        public SpatialLayout(IStaticData staticData)
        {
            _data = staticData.SpatialLayoutData;
        }

        public void CreateVerticalLayout()
        {
            _verticalLayout = new List<SpatialElement>(_data.ElementCount);

            float currentY = _data.StartYPosition;

            for (var index = 0; index < _data.ElementCount; index++)
            {
                SpatialElement element = new SpatialElement(new Vector3(0, currentY, 0));
                _verticalLayout.Add(element);
                
                currentY += _data.DistanceBetweenElements;
            }
        }
    }
}
