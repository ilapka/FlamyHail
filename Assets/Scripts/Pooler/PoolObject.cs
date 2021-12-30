using UnityEngine;

namespace FlamyHail.Pooler
{
    public abstract class PoolObject : MonoBehaviour
    {
        protected WidePooler Pooler { get; private set; }

        public void InitPool(WidePooler widePooler)
        {
            Pooler = widePooler;
        }

        public abstract void ActivateSequence();
        public abstract void DeactivateSequence();
        
    }
}
