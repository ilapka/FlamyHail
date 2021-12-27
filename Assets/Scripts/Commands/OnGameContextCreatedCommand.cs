using BehaviourInject;
using FlamyHail.Client;
using FlamyHail.Client.SpatialLayout;
using FlamyHail.Client.Tables;

namespace FlamyHail.Commands
{
    public class OnGameContextCreatedCommand : ICommand
    {
        private readonly SpatialLayout _spatialLayout;
        private readonly TableSpawner _tableSpawner;

        [Inject]
        public OnGameContextCreatedCommand(SpatialLayout spatialLayout, TableSpawner tableSpawner)
        {
            _spatialLayout = spatialLayout;
            _tableSpawner = tableSpawner;
        }
        
        public void Execute()
        {
            _spatialLayout.CreateVerticalLayout();
            _tableSpawner.GenerateTables();
        }
    }
}
