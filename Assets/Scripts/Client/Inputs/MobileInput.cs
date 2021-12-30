using System;
using FlamyHail.SupportServices;
using UnityEngine;

namespace FlamyHail.Client.Inputs
{
    public class MobileInput : IBaseInput, IUpdatable, IDisposable
    {
        private readonly UpdateProvider _updateProvider;
        
        public event Action<Touch> OnTouchBegan;
        
        public MobileInput(UpdateProvider updateProvider)
        {
            _updateProvider = updateProvider;
            
            _updateProvider.Subscribe(this);
        }

        public void Update()
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            OnTouchBegan?.Invoke(touch);
                            break;
                    }
                }
            }
        }

        public void Dispose()
        {
            _updateProvider.Unsubscribe(this);
        }
    }
}
