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
        
        private LayoutMovement _layoutMovement;
        private Rigidbody _rigidbody;

        private bool _isInit;

        private TableTemplate _currentTemplate;
        public event Action<Table> OnHit;

        public override void ActivateSequence()
        {
            Init();
            
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

        private void Init()
        {
            if(_isInit) return;
            
            _isInit = true;
            _layoutMovement = GetComponent<LayoutMovement>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Hit()
        {
            _layoutMovement.Deactivate();

            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;
            gameObject.layer = Layers.IGNORE_RAYCAST;

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
