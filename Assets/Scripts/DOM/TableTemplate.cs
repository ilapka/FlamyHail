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
        [SerializeField]
        private TableType _type;
        public int StaticId { get; set; }

        public TableTemplate(int staticId, TableType type, Color color)
        {
            StaticId = staticId;
            
            _type = type;
            _color = color;
        }

        public Color Color => _color;
        public TableType Type => _type;
    }
}
