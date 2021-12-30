using System;
using UnityEngine;

namespace FlamyHail.DOM
{
    [Serializable]
    public class TableTemplate
    {
        [SerializeField]
        private TableType _type;
        [SerializeField]
        private Color _color;

        public TableTemplate(TableType type, Color color)
        {
            _type = type;
            _color = color;
        }

        public TableType Type => _type;
        public Color Color => _color;
    }
}
