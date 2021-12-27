using UnityEngine;

namespace FlamyHail.Client.SpatialLayout
{
    public class SpatialElement
    {
        public Vector3 Position { get; }
        public bool IsEmpty { get; private set; }
        
        public SpatialElement(Vector3 position, bool isEmpty = true)
        {
            Position = position;
            IsEmpty = isEmpty;
        }

        public void Take()
        {
            IsEmpty = false;
        }

        public void Realise()
        {
            IsEmpty = true;
        }
    }
}