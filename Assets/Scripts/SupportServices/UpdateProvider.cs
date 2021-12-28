using System.Collections.Generic;
using UnityEngine;

namespace FlamyHail.SupportServices
{
    public class UpdateProvider : MonoBehaviour
    {
        private List<IUpdatable> _receivers = new List<IUpdatable>();

        private void Update()
        {
            foreach (var receiver in _receivers)
            {
                if(receiver == null)
                    Debug.LogError($"Update receiver is null");
                
                receiver?.Update();
            }
        }

        public void Subscribe(IUpdatable receiver)
        {
            _receivers.Add(receiver);
        }
        
        public void Unsubscribe(IUpdatable receiver)
        {
            _receivers.Remove(receiver);
        }
    }
}
