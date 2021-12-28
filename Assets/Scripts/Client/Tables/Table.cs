using System;
using FlamyHail.Client.SpatialLayout;
using UnityEngine;

namespace FlamyHail.Client.Tables
{
    public class Table : MonoBehaviour
    {
        private LayoutMovement _layoutMovement;
        private Rigidbody _rigidbody;
        public event Action<Table> OnHit;

        private void Awake()
        {
            _layoutMovement = GetComponent<LayoutMovement>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Hit()
        {
            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;
            gameObject.layer = Layers.IGNORE_RAYCAST;
            _layoutMovement.Dispose();
            Destroy(gameObject, 5f);

            OnHit?.Invoke(this);
        }
    }
}
