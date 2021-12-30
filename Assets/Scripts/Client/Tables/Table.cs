using System;
using FlamyHail.Client.SpatialLayout;
using FlamyHail.DOM;
using FlamyHail.Pooler;
using UnityEngine;

namespace FlamyHail.Client.Tables
{
    public class Table : PoolObject
    {
        [SerializeField]
        private SpriteRenderer _spriteBody;
        [SerializeField]
        private LayoutMovement _layoutMovement;
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private Collider _collider;

        private bool _isInit;

        private TableTemplate _currentTemplate;
        public event Action<Table> OnHit;

        public override void ActivateSequence()
        {
            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;
            gameObject.layer = Layers.DEFAULT;
            
            gameObject.SetActive(true);
            _layoutMovement.Activate();
        }

        public override void DeactivateSequence()
        {
            _layoutMovement.Deactivate();
            gameObject.SetActive(false);
        }

        public void Hit(Vector3 position)
        {
            _layoutMovement.Deactivate();

            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;
            gameObject.layer = Layers.IGNORE_RAYCAST;
            
            _rigidbody.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);

            OnHit?.Invoke(this);

            Pooler.Destroy(this, 1.5f);
        }

        public void Install(TableTemplate template)
        {
            _currentTemplate = template;
            _spriteBody.color = _currentTemplate.Color;
        }

        public TableType Type => _currentTemplate.Type;
    }
}
