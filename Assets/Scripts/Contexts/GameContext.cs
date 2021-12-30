using BehaviourInject;
using FlamyHail.Client.Gameplay;
using FlamyHail.Client.Inputs;
using FlamyHail.Client.SpatialLayout;
using FlamyHail.Client.Tables;
using FlamyHail.Commands;
using FlamyHail.Events;
using FlamyHail.Pooler;
using UnityEngine;

namespace FlamyHail.Contexts
{
    public class GameContext : MonoBehaviour
    {
        [SerializeField]
        private WidePooler _widePooler;
        
        private Context _context;
        private IEventDispatcher _eventDispatcher;
        
        private void Awake()
        {
            _context = Context.Create(ContextNames.Game)
                .SetParentContext(ContextNames.Application)
                .RegisterDependency(_widePooler)
                .RegisterType<SpatialLayout>()
                .RegisterType<TableSpawner>()
                .RegisterType<RaycastService>()
                .RegisterType<Shooter>()
                .RegisterCommand<GameContextCreatedEvent, OnGameContextCreatedCommand>();
            
            if(Application.isMobilePlatform)
                _context.RegisterTypeAs<MobileInput, IBaseInput>();
            else
                _context.RegisterTypeAs<CommonInput, IBaseInput>();

            _context.CreateAll();
        }

        private void Start()
        {
            _eventDispatcher = _context.Resolve<IEventDispatcher>();
            _eventDispatcher.DispatchEvent(new GameContextCreatedEvent());
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
        
        private void OnDestroy()
        {
            _context.Destroy();
        }
        
        public Context Context => _context;
    }
}
