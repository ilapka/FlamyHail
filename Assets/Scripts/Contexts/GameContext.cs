using BehaviourInject;
using FlamyHail.Client.SpatialLayout;
using FlamyHail.Client.Tables;
using FlamyHail.Commands;
using FlamyHail.Events;
using UnityEngine;

namespace FlamyHail.Contexts
{
    public class GameContext : MonoBehaviour
    {
        private Context _context;
        private IEventDispatcher _eventDispatcher;


        private void Awake()
        {
            _context = Context.Create(ContextNames.Game)
                .SetParentContext(ContextNames.Application)
                .RegisterType<SpatialLayout>()
                .RegisterCommand<GameContextCreatedEvent, OnGameContextCreatedCommand>();

            Debug.Log($"SpatialLayout registered");

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
    }
}
