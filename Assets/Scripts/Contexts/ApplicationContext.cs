using BehaviourInject;
using FlamyHail.Client;
using FlamyHail.Commands;
using FlamyHail.Data;
using FlamyHail.Events;
using FlamyHail.SupportServices;
using UnityEngine;

namespace FlamyHail.Contexts
{
    public class ApplicationContext : MonoBehaviour
    {
        [SerializeField]
        private StaticData _staticData;
        [SerializeField]
        private UpdateProvider _updateProvider;

        private Context _context;
        private IEventDispatcher _eventDispatcher;
        
        private void Awake()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            
#if !UNITY_EDITOR
            Application.targetFrameRate = 60;
#endif
            
            _context = Context.Create(ContextNames.Application)
                .RegisterDependencyAs<StaticData, IStaticData>(_staticData)
                .RegisterDependency(_updateProvider)
                .RegisterType<SceneLoader>()
                .RegisterType<Preloader>()
                .RegisterType<CameraController>()
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
