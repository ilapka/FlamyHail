using System;
using FlamyHail.Data;
using FlamyHail.DOM;
using FlamyHail.DOM.Types;
using FlamyHail.Pooler;
using UnityEngine;

namespace FlamyHail.Client.Views
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
        
        private TableTemplate _tableTemplate;
        public event Action<int, Table> OnPositionChanged;
        
        public override void ActivateSequence()
        {
            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;
            gameObject.layer = Layers.DEFAULT;
            
            gameObject.SetActive(true);
            
            _layoutMovement.OnLayoutPointChanged += OnLayoutPointChangedHandler;
        }
        
        public void Init(TableTemplate template)
        {
            _tableTemplate = template;
            _spriteBody.color = _tableTemplate.Color;
            
            _layoutMovement.Activate();
        }

        public override void DeactivateSequence()
        {
            _layoutMovement.OnLayoutPointChanged -= OnLayoutPointChangedHandler;
            _layoutMovement.Deactivate();
            
            gameObject.SetActive(false);
        }

        public void TakeHit(Vector3 position)
        {
            _layoutMovement.OnLayoutPointChanged -= OnLayoutPointChangedHandler;
            _layoutMovement.Deactivate();

            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;
            gameObject.layer = Layers.IGNORE_RAYCAST;
            
            _rigidbody.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
        }

        private void OnLayoutPointChangedHandler(LayoutPoint layoutPoint)
        {
            OnPositionChanged?.Invoke(layoutPoint.Index, this);
        }

        public TableType Type => _tableTemplate.Type;
    }
}
