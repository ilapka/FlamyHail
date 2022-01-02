using System;
using System.Collections.Generic;
using FlamyHail.Data;
using FlamyHail.DOM.Types;
using UnityEngine;

namespace FlamyHail.DOM
{
    public class LayoutPoint
    {
        public static LayoutPoint MOCK = new LayoutPoint(-1, new Vector3(0, 100, 0),null);
        
        private readonly List<LayoutPointTrigger> _triggers;

        public int Index { get; }
        public Vector3 Position { get; }
        public bool IsEmpty { get; private set; }
        public bool AgentIsMoving { get; private set; }
        
        public event Action<LayoutEvent> OnPointTriggered;
        
        public LayoutPoint(int index, Vector3 position, List<LayoutPointTrigger> triggers, bool isEmpty = true)
        {
            Index = index;
            Position = position;
            IsEmpty = isEmpty;

            _triggers = triggers;
        }

        public void Take()
        {
            IsEmpty = false;
            AgentIsMoving = true;
            CheckTriggers(PointAction.Taken);
        }

        public void Realise()
        {
            IsEmpty = true;
            AgentIsMoving = false;
            CheckTriggers(PointAction.Realised);
        }
        
        public void Arrive()
        {
            AgentIsMoving = false;
            CheckTriggers(PointAction.AgentArrived);
        }

        private void CheckTriggers(PointAction action)
        {
            if(_triggers == null)
                return;
            
            foreach (LayoutPointTrigger trigger in _triggers)
            {
                if (trigger.ListenedAction == action)
                {
                    OnPointTriggered?.Invoke(new LayoutEvent(Index, trigger.DispatchedAction));
                }
            }
        }
    }
}