using System.Collections.Generic;
using UnityEngine;

namespace FlamyHail.Pooler
{
    public class Pool
    {
        private readonly PoolData _poolData;
        private readonly Transform _mainRoot;
        private readonly WidePooler _widePooler;
        
        private Transform _poolRoot;
            
        private HashSet<PoolObject> _activePool = new HashSet<PoolObject>();
        private HashSet<PoolObject> _inactivePool = new HashSet<PoolObject>();
            
        public Pool(PoolData poolData, Transform mainRoot, WidePooler widePooler)
        {
            _poolData = poolData;
            _mainRoot = mainRoot;
            _widePooler = widePooler;
            Init();
        }

        private void Init()
        {
            _poolRoot = new GameObject($"Pool: {_poolData.Prefab.GetType()}").transform;
            _poolRoot.parent = _mainRoot;
                
            for (int i = 0; i < _poolData.StartCapacity; i++)
            {
                _inactivePool.Add(Instantiate());
            }
        }

        public PoolObject Create(Vector3? position = null, Quaternion? rotation = null, Vector3? scale = null)
        {
            PoolObject createdObject = HaveInactive() ? PopInactive() : Instantiate();

            var transform = createdObject.transform;
            transform.position = position ?? _poolData.Prefab.transform.position;
            transform.rotation = rotation ?? _poolData.Prefab.transform.rotation;
            transform.localScale = scale ?? _poolData.Prefab.transform.localScale;

            createdObject.ActivateSequence();

            _activePool.Add(createdObject);
            return createdObject;
        }
        
        public void Destroy(PoolObject destroyedObject)
        {
            if (!_activePool.Contains(destroyedObject))
            {
                Debug.LogError($"Can't find this object in pool");
                return;
            }
            
            _activePool.Remove(destroyedObject);
            
            destroyedObject.DeactivateSequence();
            
            _inactivePool.Add(destroyedObject);
        }

        private bool HaveInactive() => _inactivePool.Count > 0;
        
        private PoolObject PopInactive()
        {
            PoolObject target = null;
            
            foreach (PoolObject poolObject in _inactivePool)
            {
                target = poolObject;
                break;
            }

            _inactivePool.Remove(target);

            return target;
        }

        private PoolObject Instantiate()
        {
            PoolObject poolObject = Object.Instantiate(_poolData.Prefab, _poolRoot);
            poolObject.gameObject.SetActive(false);
            return poolObject;
        }
    }
}