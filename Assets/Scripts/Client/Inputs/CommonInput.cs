using System;
using FlamyHail.SupportServices;
using UnityEngine;

namespace FlamyHail.Client.Inputs
{
    public class CommonInput : IBaseInput, IUpdatable, IDisposable
    {
        private readonly UpdateProvider _updateProvider;
        public event Action<Touch> OnTouchBegan;
        public CommonInput(UpdateProvider updateProvider)
        {
            _updateProvider = updateProvider;
            
            _updateProvider.Subscribe(this);
        }

        public void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Touch touchData = new Touch();
                touchData.position = Input.mousePosition;
                touchData.phase = TouchPhase.Began;
                OnTouchBegan?.Invoke(touchData);
            }
        }

        public void Dispose()
        {
            _updateProvider.Unsubscribe(this);
        }
    }
}
