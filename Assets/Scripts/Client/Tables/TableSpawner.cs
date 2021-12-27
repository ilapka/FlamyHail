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
                var table = Random.Range(0f, 1f) > 0.5 ? _spawnTablesData.LeftTable : _spawnTablesData.RightTable;
                
                var obj = Object.Instantiate(table.Prefab, table.SpawnPosition, table.Prefab.transform.rotation);
            }
        }
    }
}
