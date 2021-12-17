using BehaviourInject;
using FlamyHail.Commands;
using FlamyHail.Events;
using UnityEngine;

namespace FlamyHail.Contexts
{
    public class ApplicationContext : MonoBehaviour
    {
        private Context _context;
        private IEventDispatcher _eventDispatcher;
        
        private void Awake()
        {
            _context = Context.Create(ContextNames.Application)
                .RegisterType<SceneLoader>()
                .RegisterType<Preloader>()
                .RegisterCommand<ApplicationContextCreatedEvent, OnApplicationContextCreatedCommand>();
            
            DontDestroyOnLoad(this);

            _eventDispatcher = _context.Resolve<IEventDispatcher>();
            _eventDispatcher.DispatchEvent(new ApplicationContextCreatedEvent());
        }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
        
        private void OnDestroy()
        {
            _context.Destroy();
        }
    }

    public class ContextNames
    {
        public const string Application = "Application";
        public const string Game = "Game";
    }
}
