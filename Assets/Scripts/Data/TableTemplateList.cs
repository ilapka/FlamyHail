using System.Collections.Generic;
using FlamyHail.DOM;
using FlamyHail.DOM.Types;
using UnityEngine;

namespace FlamyHail.Data
{
    [CreateAssetMenu(fileName = "TableTemplateList", menuName = "FlamyHail/Data/TableTemplateList", order = 1)]
    public class TableTemplateList : ScriptableObject
    {
        [SerializeField]
        private List<TableTemplate> _goodTemplates;
        [SerializeField]
        private List<TableTemplate> _badTemplates;
        [SerializeField] [Range(0f, 1f)]
        private float _badSpawnChance;
        
        public List<TableTemplate> GoodTemplates => _goodTemplates;
        public List<TableTemplate> BadTemplates => _badTemplates;
        public float BadSpawnChance => _badSpawnChance;

        private void OnValidate()
        {
            for (var index = 0; index < _goodTemplates.Count; index++)
            {
                var template = _goodTemplates[index];
                _goodTemplates[index] = new TableTemplate(index, TableType.Good, template.Color);
            }
            
            for (var index = 0; index < _badTemplates.Count; index++)
            {
                var template = _badTemplates[index];
                _badTemplates[index] = new TableTemplate(index, TableType.Bad, template.Color);
            }
        }
    }
}
