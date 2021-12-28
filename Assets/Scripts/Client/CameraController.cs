using UnityEngine;

namespace FlamyHail.Client
{
    public class CameraController
    {
        private Camera _currentCamera;
        
        public CameraController()
        {
            _currentCamera = Camera.main;
        }

        public Camera GetCurrentCamera()
        {
            if (_currentCamera == null || !_currentCamera.gameObject.activeInHierarchy)
            {
                _currentCamera = Camera.main;
            }

            return _currentCamera;
        }
    }
}
