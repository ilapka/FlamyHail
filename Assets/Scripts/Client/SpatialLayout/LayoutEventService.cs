using System;
using FlamyHail.DOM;

namespace FlamyHail.Client.SpatialLayout
{
    public class LayoutEventService : IDisposable
    {
        private readonly SpatialLayout _spatialLayout;
        
        public event Action<LayoutEvent> OnLayoutEventReceived;

        public LayoutEventService(SpatialLayout spatialLayout)
        {
            _spatialLayout = spatialLayout;
        }

        public void Init()
        {
            foreach (LayoutPoint point in _spatialLayout.VerticalLayout)
            {
                point.OnPointTriggered += OnPointTriggeredHandler;
            }
        }

        private void OnPointTriggeredHandler(LayoutEvent layoutEvent)
        {
            OnLayoutEventReceived?.Invoke(layoutEvent);
        }

        public void Dispose()
        {
            if (_spatialLayout.VerticalLayout != null)
            {
                foreach (LayoutPoint point in _spatialLayout.VerticalLayout)
                {
                    point.OnPointTriggered -= OnPointTriggeredHandler;
                }
            }
        }
    }
}
