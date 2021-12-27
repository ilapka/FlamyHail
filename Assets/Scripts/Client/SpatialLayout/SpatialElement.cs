using UnityEngine;

namespace FlamyHail.Client.SpatialLayout
{
    public class SpatialElement
    {
        public static SpatialElement MOCK = new SpatialElement(-1, new Vector3(0, 100, 0));
        
        public int Index { get; }
        public Vector3 Position { get; }
        public bool IsEmpty { get; private set; }
        
        public SpatialElement(int index, Vector3 position, bool isEmpty = true)
        {
            Index = index;
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