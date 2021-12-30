using FlamyHail.Data;
using FlamyHail.Pooler;
using UnityEngine;

namespace FlamyHail.Client.Tables
{
    public class TableSpawner
    {
        private readonly SpawnTablesData _spawnTablesData;
        private readonly WidePooler _widePooler;
        
        public TableSpawner(IStaticData staticData, WidePooler widePooler)
        {
            _spawnTablesData = staticData.SpawnTablesData;
            _widePooler = widePooler;
        }

        public void GenerateTables()
        {
            for (int i = 0; i < _spawnTablesData.InitialCount; i++)
            {
                SpawnTable();
            }
        }

        private void SpawnTable()
        {
            PrefabContainer<Table> prefabContainer = Random.Range(0f, 1f) > 0.5 ?
                _spawnTablesData.LeftTableContainer : _spawnTablesData.RightTableContainer;

            Table table = _widePooler.Create<Table>(prefabContainer.SpawnPosition, null, prefabContainer.Scale);
            
            table.OnHit += OnHitTableHandler;
        }

        private void OnHitTableHandler(Table table)
        {
            table.OnHit -= OnHitTableHandler;
            SpawnTable();
        }
    }
}
