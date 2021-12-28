using FlamyHail.Client.SpatialLayout;
using FlamyHail.Contexts;
using FlamyHail.Data;
using UnityEngine;

namespace FlamyHail.Client.Tables
{
    public class TableSpawner
    {
        private readonly SpawnTablesData _spawnTablesData;

        public TableSpawner(IStaticData staticData)
        {
            _spawnTablesData = staticData.SpawnTablesData;
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
                
            Table table = Object.Instantiate(prefabContainer.Prefab, prefabContainer.SpawnPosition, prefabContainer.Prefab.transform.rotation);

            table.OnHit += OnHitTableHandler;
        }

        private void OnHitTableHandler(Table table)
        {
            table.OnHit -= OnHitTableHandler;
            SpawnTable();
        }
    }
}
