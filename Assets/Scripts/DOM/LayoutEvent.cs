using FlamyHail.DOM.Types;

namespace FlamyHail.DOM
{
    public struct LayoutEvent
    {
        private int _pointIndex;
        private LayoutEventType _type;

        public LayoutEvent(int pointIndex, LayoutEventType type)
        {
            _pointIndex = pointIndex;
            _type = type;
        }
        
        public int PointIndex => _pointIndex;
        public LayoutEventType Type => _type;
    }
}