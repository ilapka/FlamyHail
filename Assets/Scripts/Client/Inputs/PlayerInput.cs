using System;
using FlamyHail.SupportServices;
using UnityEngine;

namespace FlamyHail.Client.Inputs
{
    public class PlayerInput : IBaseInput, IUpdatable, IDisposable
    {
        private readonly UpdateProvider _updateProvider;
        
        public event Action<MouseInput> OnMouseButtonDown;

        public PlayerInput(UpdateProvider updateProvider)
        {
            _updateProvider = updateProvider;
            
            _updateProvider.Subscribe(this);
        }

        public void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                MouseInput mouseInput = new MouseInput(Input.mousePosition);
                OnMouseButtonDown?.Invoke(mouseInput);
            }
        }

        public void Dispose()
        {
            _updateProvider.Unsubscribe(this);
        }
    }
}
