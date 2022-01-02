using System.Collections.Generic;
using FlamyHail.DOM;
using UnityEngine;

namespace FlamyHail.Data
{
    [CreateAssetMenu(fileName = "TableTemplateList", menuName = "FlamyHail/Data/TableTemplateList", order = 1)]
    public class TableTemplateList : ScriptableObject
    {
        [SerializeField]
        private List<TableTemplate> _goodTemplates;
        [SerializeField] [Range(0f, 1f)]
        private float _badSpawnChance;
        public List<TableTemplate> Templates => _goodTemplates;
        public float BadSpawnChance => _badSpawnChance;
    }
}
