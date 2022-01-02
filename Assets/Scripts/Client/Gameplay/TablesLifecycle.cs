using System;
using System.Collections.Generic;
using FlamyHail.Client.Inputs;
using FlamyHail.Client.SpatialLayout;
using FlamyHail.Client.Views;
using FlamyHail.Commands;
using FlamyHail.Data;
using FlamyHail.DOM;
using FlamyHail.DOM.Types;
using FlamyHail.Pooler;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FlamyHail.Client.Gameplay
{
    public class TablesLifecycle : IDisposable
    {
        private readonly GameCreatingPipeline _gameCreatingPipeline;
        private readonly IStaticData _staticData;
        private readonly SpawnTablesData _spawnTablesData;
        private readonly TableTemplateList _tableTemplateList;
        private readonly WidePooler _widePooler;
        private readonly RaycastService _raycastService;
        private readonly LayoutEventService _layoutEventService;

        private readonly Table[] _tablesOnPositions;

        private event Action<int> OnFinishTrigger;

        public TablesLifecycle(GameCreatingPipeline gameCreatingPipeline, IStaticData staticData, WidePooler widePooler,
            RaycastService raycastService, LayoutEventService layoutEventService)
        {
            _gameCreatingPipeline = gameCreatingPipeline;
            _staticData = staticData;
            _spawnTablesData = staticData.SpawnTablesData;
            _tableTemplateList = staticData.TableTemplateList;
            _widePooler = widePooler;
            _raycastService = raycastService;
            _layoutEventService = layoutEventService;

            _gameCreatingPipeline.OnPipelineComplete += GenerateTables;
            _raycastService.RaycastOnMouseDown += Shoot;
            _layoutEventService.OnLayoutEventReceived += OnLayoutEventReceivedHandler;
            
            _tablesOnPositions = new Table[_staticData.SpatialLayoutData.PointsCount];
        }
        private void GenerateTables()
        {
            for (int i = 0; i < _spawnTablesData.InitialCount; i++)
            {
                SpawnTable();
            }
        }

        private void SpawnTable()
        {
            PrefabContainer prefabContainer = Random.Range(0f, 1f) > 0.5f ?
                _spawnTablesData.LeftTableContainer : _spawnTablesData.RightTableContainer;

            Table table = _widePooler.Create<Table>(prefabContainer.SpawnPosition, null, prefabContainer.Scale);

            List<TableTemplate> templatesList = Random.Range(0f, 1f) < _tableTemplateList.BadSpawnChance
                ? _tableTemplateList.BadTemplates
                : _tableTemplateList.GoodTemplates;

            TableTemplate template = templatesList[Random.Range(0, templatesList.Count)];
            
            table.OnPositionChanged += OnTablePositionChangedHandler;
            table.Init(template);
        }
        
        private void OnTablePositionChangedHandler(int position, Table table)
        {
            if(position < 0 || position > _tablesOnPositions.Length - 1)
                return;
            
            _tablesOnPositions[position] = table;
        }
        
        private void Shoot(bool isHit, RaycastHit raycastHit)
        {
            if(!isHit) return;
            
            if (raycastHit.transform.TryGetComponent(out Table table))
            {
                table.OnPositionChanged -= OnTablePositionChangedHandler;
                table.TakeHit(raycastHit.point);
                _widePooler.Destroy(table, 1.5f);
                SpawnTable();
            }
        }
        
        private void OnLayoutEventReceivedHandler(LayoutEvent layoutEvent)
        {
            if(layoutEvent.PointIndex < 0 || layoutEvent.PointIndex > _tablesOnPositions.Length - 1)
                return;
            
            Table table = _tablesOnPositions[layoutEvent.PointIndex];
            
            if(!table) return;

            switch (layoutEvent.Type)
            {
                case LayoutEventType.Finish:
                {
                    if(table.Type != TableType.Good)
                        return;
                    
                    table.OnPositionChanged -= OnTablePositionChangedHandler;
                    table.TakeHit(Vector3.back);
                    _widePooler.Destroy(table, 1.5f);
                    SpawnTable();
                    break;
                }
            }
        }

        public void Dispose()
        {
            _gameCreatingPipeline.OnPipelineComplete -= GenerateTables;
            _raycastService.RaycastOnMouseDown -= Shoot;
            _layoutEventService.OnLayoutEventReceived -= OnLayoutEventReceivedHandler;
        }
    }
}
