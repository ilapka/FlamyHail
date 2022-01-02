using System;
using FlamyHail.DOM.Types;
using UnityEngine;

namespace FlamyHail.DOM
{
    [Serializable]
    public class TableTemplate
    {
        [SerializeField]
        private Color _color;
        public int StaticId { get; private set; }
        public TableType Type { get; private set; }

        public TableTemplate(int staticId, TableType type, Color color)
        {
            StaticId = staticId;
            Type = type;
            
            _color = color;
        }

        public Color Color => _color;
    }
}
