using System;
using System.Collections;
using System.Collections.Generic;
using BehaviourInject;
using FlamyHail.Data;
using UnityEngine;

namespace FlamyHail.Pooler
{
    public class WidePooler : MonoBehaviour
    {
        private PoolerData _poolerData;

        private Dictionary<Type, Pool> _pooler = new Dictionary<Type, Pool>();

        [Inject]
        public void Init(IStaticData staticData)
        {
            _poolerData = staticData.PoolerData;
            
            CreatePools();
        }

        private void CreatePools()
        {
            foreach (PoolData poolData in _poolerData.Pools)
            {
                Type type = poolData.Prefab.GetType();
                Pool pool = new Pool(poolData, transform, this);
                _pooler.Add(type, pool);
            }
        }

        public T Create<T>(Vector3? position = null, Quaternion? rotation = null, Vector3? scale = null) where T : PoolObject
        {
            Type type = typeof(T);
            
            if (_pooler.ContainsKey(type))
            {
                Pool pool = _pooler[type];
                T poolObject = pool.Create(position, rotation, scale) as T;
                return poolObject;
            }
            
            throw new Exception($"Type of {type} not contains in pooler, set it in PoolerData");
        }
        
        public void Destroy(PoolObject poolObject)
        {
            Type type = poolObject.GetType();
            
            if (_pooler.ContainsKey(type))
            {
                Pool pool = _pooler[type];
                pool.Destroy(poolObject);
                return;
            }
            
            throw new Exception($"Type of {type} not contains in pooler, set it in PoolerData");
        }
        
        public void Destroy(PoolObject poolObject, float delay)
        {
            StartCoroutine(DestroyDelayCoroutine(poolObject, delay));
        }

        private IEnumerator DestroyDelayCoroutine(PoolObject poolObject, float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(poolObject);
        }
    }
}
