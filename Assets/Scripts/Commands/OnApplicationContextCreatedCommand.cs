using BehaviourInject;

namespace FlamyHail.Commands
{
    public class OnApplicationContextCreatedCommand : ICommand
    {
        private readonly Preloader _preloader;
        
        [Inject]
        public OnApplicationContextCreatedCommand(Preloader sceneLoader)
        {
            _preloader = sceneLoader;
        }
        
        public void Execute()
        {
            _preloader.StartLoadingGame();
        }
    }
}
