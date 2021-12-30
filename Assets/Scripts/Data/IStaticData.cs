using FlamyHail.Pooler;

namespace FlamyHail.Data
{
    public interface IStaticData
    {
        SpatialLayoutData SpatialLayoutData { get; }
        SpawnTablesData SpawnTablesData { get; }
        PoolerData PoolerData { get; }
        TableTemplateList TableTemplateList { get; }
    }
}
