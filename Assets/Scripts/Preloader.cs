using BehaviourInject;
using FlamyHail.Events;
using UnityEngine;

namespace FlamyHail
{
    public class Preloader
    {
        private readonly SceneLoader _sceneLoader;
        
        [Inject]
        public Preloader(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void StartLoadingGame()
        {
            _sceneLoader.LoadGame();
        }
    }
}
