using System;
using FlamyHail.DOM.Types;
using UnityEngine;

namespace FlamyHail.Data
{
    [Serializable]
    public class LayoutPointTrigger
    {
        [SerializeField]
        private int pointIndex;
        [SerializeField]
        private PointAction _listenedAction;
        [SerializeField]
        private LayoutEventType _dispatchedAction;
        
        public int PointIndex => pointIndex;
        public LayoutEventType DispatchedAction => _dispatchedAction;
        public PointAction ListenedAction => _listenedAction;
    }
}
