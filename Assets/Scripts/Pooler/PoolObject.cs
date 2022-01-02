using UnityEngine;

namespace FlamyHail.Pooler
{
    public abstract class PoolObject : MonoBehaviour
    {
        public abstract void ActivateSequence();
        public abstract void DeactivateSequence();
        
    }
}
