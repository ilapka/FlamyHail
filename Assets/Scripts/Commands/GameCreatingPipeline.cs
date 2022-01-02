using System;
using BehaviourInject;
using FlamyHail.Client.SpatialLayout;
using FlamyHail.Data;
using FlamyHail.Events;
using FlamyHail.Pooler;
using UnityEngine;

namespace FlamyHail.Commands
{
    public class GameCreatingPipeline
    {
        private readonly IStaticData _staticData;
        private readonly SpatialLayout _spatialLayout;
        private readonly WidePooler _widePooler;
        private readonly LayoutEventService _layoutEventService;

        public event Action OnPipelineComplete;
        
        public GameCreatingPipeline(IStaticData staticData, SpatialLayout spatialLayout, WidePooler widePooler,
            LayoutEventService layoutEventService)
        {
            _staticData = staticData;
            _spatialLayout = spatialLayout;
            _widePooler = widePooler;
            _layoutEventService = layoutEventService;
        }
        
        [InjectEvent]
        public void Execute(GameContextCreatedEvent gameContextCreatedEvent)
        {
            _widePooler.Init(_staticData);
            _spatialLayout.CreateVerticalLayout();
            _layoutEventService.Init();
            
            OnPipelineComplete?.Invoke();
        }
    }
}
