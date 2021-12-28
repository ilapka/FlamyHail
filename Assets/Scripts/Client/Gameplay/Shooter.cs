using System;
using FlamyHail.Client.Inputs;
using FlamyHail.Client.Tables;
using UnityEngine;

namespace FlamyHail.Client.Gameplay
{
    public class Shooter : IDisposable
    {
        private readonly RaycastService _raycastService;
        
        public Shooter(RaycastService raycastService)
        {
            _raycastService = raycastService;

            _raycastService.RaycastOnMouseDown += Shoot;
        }

        private void Shoot(bool isHit, RaycastHit raycastHit)
        {
            if(!isHit) return;
            
            if (raycastHit.transform.TryGetComponent(out Table table))
            {
                table.Hit();
            }
        }

        public void Dispose()
        {
            _raycastService.RaycastOnMouseDown -= Shoot;
        }
    }
}
