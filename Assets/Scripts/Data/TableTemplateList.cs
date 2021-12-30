using System.Collections.Generic;
using FlamyHail.DOM;
using UnityEngine;

namespace FlamyHail.Data
{
    [CreateAssetMenu(fileName = "TableTemplateList", menuName = "FlamyHail/Data/TableTemplateList", order = 1)]
    public class TableTemplateList : ScriptableObject
    {
        [SerializeField]
        private List<TableTemplate> _templates;
        
        public List<TableTemplate> Templates => _templates;
    }
}
