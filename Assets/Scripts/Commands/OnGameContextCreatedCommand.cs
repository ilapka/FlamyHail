using BehaviourInject;
using FlamyHail.Client;
using FlamyHail.Client.SpatialLayout;

namespace FlamyHail.Commands
{
    public class OnGameContextCreatedCommand : ICommand
    {
        private readonly SpatialLayout _spatialLayout;
        
        [Inject]
        public OnGameContextCreatedCommand(SpatialLayout spatialLayout)
        {
            _spatialLayout = spatialLayout;
        }
        
        public void Execute()
        {
            _spatialLayout.CreateVerticalLayout();
        }
    }
}
