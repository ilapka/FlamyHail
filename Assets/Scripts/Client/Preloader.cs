
namespace FlamyHail.Client
{
    public class Preloader
    {
        private readonly SceneLoader _sceneLoader;
        
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
