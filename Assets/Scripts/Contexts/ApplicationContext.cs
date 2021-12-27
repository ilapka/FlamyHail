using BehaviourInject;
using FlamyHail.Client;
using FlamyHail.Commands;
using FlamyHail.Data;
using FlamyHail.Events;
using UnityEngine;

namespace FlamyHail.Contexts
{
    public class ApplicationContext : MonoBehaviour
    {
        [SerializeField]
        private StaticData _staticData;
        
        private Context _context;
        private IEventDispatcher _eventDispatcher;
        
        private void Awake()
        {
            _context = Context.Create(ContextNames.Application)
                .RegisterDependencyAs<StaticData, IStaticData>(_staticData)
                .RegisterType<SceneLoader>()
                .RegisterType<Preloader>()
                .RegisterCommand<ApplicationContextCreatedEvent, OnApplicationContextCreatedCommand>()
                .CreateAll();

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
}
