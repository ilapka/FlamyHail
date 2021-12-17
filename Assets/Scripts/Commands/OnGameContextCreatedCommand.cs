using BehaviourInject;
using UnityEngine;

namespace FlamyHail.Commands
{
    public class OnGameContextCreatedCommand : ICommand
    {
        private readonly Preloader _preloader;
        
        [Inject]
        public OnGameContextCreatedCommand(Preloader sceneLoader)
        {
            _preloader = sceneLoader;
        }
        
        public void Execute()
        {
            
        }
    }
}
