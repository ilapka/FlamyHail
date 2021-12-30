using System;
using UnityEngine;

namespace FlamyHail.Client.Inputs
{
    public class RaycastService : IDisposable
    {
        private readonly IBaseInput _input;
        private readonly CameraController _cameraController;

        public event Action<bool, RaycastHit> RaycastOnMouseDown;
        
        public RaycastService(IBaseInput input, CameraController cameraController)
        {
            _input = input;
            _cameraController = cameraController;

            _input.OnTouchBegan += RaycastOnInput;
        }
        private void RaycastOnInput(Touch touchData)
        {
            Camera camera = _cameraController.GetCurrentCamera();
            Ray ray = camera.ScreenPointToRay(touchData.position);

            bool isHit = Physics.Raycast(ray, out RaycastHit hit, 100);
            RaycastOnMouseDown?.Invoke(isHit, hit);
        }

        public void Dispose()
        {
            _input.OnTouchBegan -= RaycastOnInput;
        }
    }
}
